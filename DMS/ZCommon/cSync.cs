using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace DMS
{
    class cSync
    {
        static FtpFileStruct FtpFS;
        static FTPHelper fh;

        /// <summary>
        /// 从来源获取公文
        /// </summary>
        /// <param name="Title">标题</param>
        /// <param name="Url">来源</param>
        /// <param name="type">公文类型</param>
        /// <param name="rlDate"></param>
        /// <param name="provider"></param>
        /// <param name="notes"></param>
        /// <param name="isAddRecord">是否记录进数据库</param>
        public static void GetDoc(string Title, string Url, string type = "", string rlDate = "", string provider = "", string notes = "", bool isAddRecord = true)
        {
            if (Url.IndexOf('/') > 0)
            {//网址
                List<cWord> lw = new List<cWord>();

                lw.Add(new cWord(Title, Url, type, rlDate, provider, notes, isAddRecord));
                cMakeWord mw = new cMakeWord(lw);
                Thread th = new Thread(new System.Threading.ThreadStart(mw.makeWord));
                th.Start();
            }
            else if (Url.IndexOf('\\') >= 0)
            {//本地文件
                string HouZui = Url.Substring(Url.LastIndexOf('.'));

                string pFilePath;
                if (type == "")
                    type = cConfig.strNoType;
                pFilePath = cConfig.strWorkPath + "\\" + type;

                if (!(Directory.Exists(pFilePath)))
                    Directory.CreateDirectory(pFilePath);

                pFilePath += "\\" + Title + HouZui;

                if (File.Exists(pFilePath))
                {
                    MessageBox.Show("公文库中已有同名公文，请修改公文标题或类型！");
                    return;
                }
                File.Copy(Url, pFilePath);
                if (isAddRecord)
                    cAccess.add(Title, Url, pFilePath, type, rlDate, provider, notes);
                cConfig.working = false;
                cConfig.needFlash = true;
            }
        }


        static List<string> filePath = new List<string>();
        /// <summary>
        /// 遍历文件夹，搜索符合条件的文件，添加进filePath列表中
        /// </summary>
        /// <param name="path"></param>
        private static void searchFile(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (FileInfo f in dir.GetFiles("*.*"))
            {
                filePath.Add(f.FullName);
            }
            foreach (DirectoryInfo f in dir.GetDirectories())
            {
                if (f.Name != cConfig.strTemp)
                {
                    searchFile(f.FullName);
                }
            }
        }

        /// <summary>
        /// 检测工作目录下的文件，
        /// 如发现数据库中没记录，添加进数据库
        /// </summary>
        public static void AddRecord()
        {
            filePath.Clear();
            searchFile(cConfig.strWorkPath);
            foreach (string url in filePath)
            {
                int titleStart = url.LastIndexOf('\\');
                int typeStart = url.Substring(0, titleStart).LastIndexOf('\\');
                int end = url.LastIndexOf('.');
                string title = url.Substring(titleStart + 1, end - titleStart - 1);
                string type = url.Substring(typeStart + 1, titleStart - typeStart - 1);
                if (type == cConfig.strWorkFolder) continue;
                bool no = true;
                for (int i = 0; i < cAccess.DtTable.Rows.Count; i++)
                {
                    if (url == cAccess.DtTable.Rows[i]["LocalPath"].ToString())
                    {
                        no = false;
                        break;
                    }
                }
                if (no)
                    cAccess.add(title, url, url, type, "", Environment.UserName, "自工作目录中检测出的文档");
            }
        }

        /// <summary>
        /// 获取FTP中的文件列表
        /// </summary>
        public static void getFtpFileList()
        {
            fh = new FTPHelper(cConfig.FTP_IP, cConfig.strFtpRoot, cConfig.FTP_user, cConfig.FTP_password);
            if (!fh.FtpIsExistsFile(""))
                if (fh.MakeDir(""))
                    System.Diagnostics.Debug.Write("OK");

            FtpFS = new FtpFileStruct();
            FtpFS.addType(fh.GetDirList());
            for (int i = 0; i < FtpFS.typeList.Count; i++)
            {
                fh.GotoDirectory(cConfig.strFtpRoot + FtpFS.typeList[i].name, true);

                FtpFS.typeList[i].addFile(fh.GetFileList());
            }

        }
        /// <summary>
        /// 将本地文件上传至ftp，并标记ftp中没有被记录的文件
        /// </summary>
        public void LocalToFtp()
        {
            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                for (int i = 0; i < FtpFS.typeList.Count; i++)
                {
                    if (FtpFS.typeList[i].name == cAccess.DtTable.Rows[row]["DocType"].ToString())
                    {
                        bool no = true;
                        for (int j = 0; j < FtpFS.typeList[i].FileList.Count; j++)
                        {
                            int start = cAccess.DtTable.Rows[row]["LocalPath"].ToString().LastIndexOf("\\");
                            if (FtpFS.typeList[i].FileList[j].name == cAccess.DtTable.Rows[row]["LocalPath"].ToString().Substring(start + 1))
                            {
                                no = false;
                                FtpFS.typeList[i].FileList[j].isRecord = true;
                                break;
                            }
                        }
                        if (no)
                        {
                            //将本地文件上传至ftp
                            fh.GotoDirectory(cConfig.strFtpRoot + "/" + FtpFS.typeList[i].name, true);
                            fh.Upload(cAccess.DtTable.Rows[row]["LocalPath"].ToString());
                        }
                    }
                }


            }
        }
        /// <summary>
        /// 将缺少的本地文件从ftp上下载，并标记ftp中没有被记录的文件
        /// </summary>
        public void FtpToLocal()
        {
            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                if (!File.Exists(cAccess.DtTable.Rows[row]["LocalPath"].ToString()))
                {
                    for (int i = 0; i < FtpFS.typeList.Count; i++)
                    {
                        if (FtpFS.typeList[i].name == cAccess.DtTable.Rows[row]["DocType"].ToString())
                        {
                            for (int j = 0; j < FtpFS.typeList[i].FileList.Count; j++)
                            {
                                int start = cAccess.DtTable.Rows[row]["LocalPath"].ToString().LastIndexOf("\\");
                                if (FtpFS.typeList[i].FileList[j].name == cAccess.DtTable.Rows[row]["LocalPath"].ToString().Substring(start + 1))
                                {
                                    FtpFS.typeList[i].FileList[j].isRecord = true;

                                    fh.Download(cConfig.strWorkPath + "\\" + FtpFS.typeList[i].name, FtpFS.typeList[i].FileList[j].name);
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// 将FTP上被标记的文件下载下来
        /// </summary>
        public void record()
        {
            for (int i = 0; i < FtpFS.typeList.Count; i++)
            {
                for (int j = 0; j < FtpFS.typeList[i].FileList.Count; j++)
                {
                    if (!FtpFS.typeList[i].FileList[j].isRecord)
                    {
                        if (File.Exists(cConfig.strWorkPath + FtpFS.typeList[i].name + FtpFS.typeList[i].FileList[j].name))
                            continue;
                        fh.Download(cConfig.strWorkPath + "\\" + FtpFS.typeList[i].name, FtpFS.typeList[i].FileList[j].name);
                        
                        cAccess.add(FtpFS.typeList[i].FileList[j].name, "",
                            cConfig.strWorkPath + FtpFS.typeList[i].name + FtpFS.typeList[i].FileList[j].name,
                            FtpFS.typeList[i].name, "", cConfig.FTP_IP, "从FTP上下载的文件");

                        FtpFS.typeList[i].FileList[j].isRecord = true;
                    }
                }
            }
        }



    }
}
