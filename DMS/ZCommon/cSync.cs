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
        FtpFileStruct FtpFS;
        FTPHelper fh;


        public cSync()
        {
            fh = new FTPHelper(cConfig.FTP_IP, cConfig.strFtpRoot, cConfig.FTP_user, cConfig.FTP_password);
            if (!fh.FtpIsExistsFile(""))
                if (fh.MakeDir(""))
                    System.Diagnostics.Debug.Write("OK");

            getFtpFileList();
        }

        /// <summary>
        /// 获取FTP中的文件列表
        /// </summary>
        public void getFtpFileList()
        {
            FtpFS = new FtpFileStruct();
            FtpFS.addType(fh.GetDirList());
            for (int i = 0; i < FtpFS.typeList.Count; i++)
            {
                fh.GotoDirectory(cConfig.strFtpRoot + '/' + FtpFS.typeList[i].name, true);

                FtpFS.typeList[i].addFile(fh.GetFileList());
            }
        }

        #region 在字符数组中找字符串是否存在
        private bool isExist(string[] array, string str)
        {
            bool exist = false;
            foreach (string s in array)
            {
                if (s == str)
                    exist = true;
            }
            return exist;
        }
        #endregion


        public List<string> listNotInFtp;
        public FtpFileStruct listNotRecord;
        /// <summary>
        /// 对比，得出2个列表
        /// </summary>
        public void Contrast()
        {
            listNotInFtp = new List<string>();
            listNotRecord = new FtpFileStruct();
            //遍历数据库
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                bool notInFtp = true;
                for (int i = 0; i < FtpFS.typeList.Count; i++)
                {
                    if (FtpFS.typeList[i].name == cAccess.basicDt.Rows[row]["DocType"].ToString())
                    {
                        for (int j = 0; j < FtpFS.typeList[i].files.Count; j++)
                        {
                            int start = cAccess.basicDt.Rows[row]["LocalPath"].ToString().LastIndexOf("\\");
                            if (FtpFS.typeList[i].files[j].name ==
                                cAccess.basicDt.Rows[row]["LocalPath"].ToString().Substring(start + 1))
                            {
                                notInFtp = false;
                                FtpFS.typeList[i].files[j].isNotRecord = false;

                                break;
                            }
                        }
                    }
                }
                if (notInFtp)
                {
                    listNotInFtp.Add(cAccess.basicDt.Rows[row]["LocalPath"].ToString());
                }
            }
            for (int i = 0, k = 0; i < FtpFS.typeList.Count; i++)
            {
                for (int j = 0; j < FtpFS.typeList[i].files.Count; j++)
                {
                    if (FtpFS.typeList[i].files[j].isNotRecord)
                    {
                        if (listNotRecord.typeList.Count == 0)
                        {
                            listNotRecord.typeList.Add(new type(FtpFS.typeList[i].name));
                        }
                        else
                        {
                            if (listNotRecord.typeList[k].name == FtpFS.typeList[i].name)
                                listNotRecord.typeList[k].addFile(FtpFS.typeList[i].files[j].name);
                            else
                            {
                                listNotRecord.typeList.Add(new type(FtpFS.typeList[i].name));
                                k++;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 将没在记录之中的文件从FTP上下载
        /// </summary>
        public void FtpToLocal()
        {
            for (int i = 0; i < listNotRecord.typeList.Count; i++)
            {
                for (int j = 0; j < listNotRecord.typeList[i].files.Count; j++)
                {
                    fh.GotoDirectory(cConfig.strFtpRoot + "/" + listNotRecord.typeList[i].name, true);
                    fh.Download(cConfig.strWorkPath + "\\" + listNotRecord.typeList[i].name, listNotRecord.typeList[i].files[j].name);
                    cAccess.add(listNotRecord.typeList[i].files[j].name, "",
                            cConfig.strWorkPath + "\\" + listNotRecord.typeList[i].name + "\\" + listNotRecord.typeList[i].files[j].name,
                            listNotRecord.typeList[i].name, "", cConfig.FTP_IP, "从FTP上下载的文件");
                }
            }
        }
        /// <summary>
        /// 将本地文件上传至ftp
        /// </summary>
        public void LocalToFtp()
        {
            //遍历数据库
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                bool typeExist = false;
                for (int i = 0; i < FtpFS.typeList.Count; i++)
                {
                    if (FtpFS.typeList[i].name == cAccess.basicDt.Rows[row]["DocType"].ToString())
                    {
                        typeExist = true;
                        bool fileExist = false;
                        for (int j = 0; j < FtpFS.typeList[i].files.Count; j++)
                        {
                            int start = cAccess.basicDt.Rows[row]["LocalPath"].ToString().LastIndexOf("\\");
                            if (FtpFS.typeList[i].files[j].name ==
                                cAccess.basicDt.Rows[row]["LocalPath"].ToString().Substring(start + 1))
                            {
                                fileExist = true;
                                break;
                            }
                        }
                        if (!fileExist)
                        {//FTP上文件不存在，将本地文件上传至ftp
                            fh.GotoDirectory(cConfig.strFtpRoot + "/" + FtpFS.typeList[i].name, true);
                            if (fh.Upload(cAccess.basicDt.Rows[row]["LocalPath"].ToString()))
                            {//success
                            }
                        }
                    }
                }
                if (!typeExist)
                {
                    //Ftp上类型不存在
                    fh.GotoDirectory(cConfig.strFtpRoot + "/" + cAccess.basicDt.Rows[row]["DocType"].ToString(), true);
                    if (fh.Upload(cAccess.basicDt.Rows[row]["LocalPath"].ToString()))
                    {//success
                    }
                }

            }
        }

        /// <summary>
        /// 将缺少的本地文件从ftp或来源上下载，
        /// </summary>
        public void LocalReplenish()
        {
            List<string> ls = new List<string>();
            List<string> lst = new List<string>();
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                if (!File.Exists(cAccess.basicDt.Rows[row]["LocalPath"].ToString()))
                {
                    bool noFileOnFtp = true;
                    if (!string.IsNullOrWhiteSpace(cConfig.FTP_IP))
                    {
                        //本地文件不存在

                        for (int i = 0; i < FtpFS.typeList.Count; i++)
                        {
                            if (FtpFS.typeList[i].name == cAccess.basicDt.Rows[row]["DocType"].ToString())
                            {
                                for (int j = 0; j < FtpFS.typeList[i].files.Count; j++)
                                {
                                    int start = cAccess.basicDt.Rows[row]["LocalPath"].ToString().LastIndexOf("\\");
                                    if (FtpFS.typeList[i].files[j].name ==
                                        cAccess.basicDt.Rows[row]["LocalPath"].ToString().Substring(start + 1))
                                    {
                                        fh.GotoDirectory(cConfig.strFtpRoot + "/" + FtpFS.typeList[i].name, true);
                                        try
                                        {
                                            fh.Download(cConfig.strWorkPath + "\\" + FtpFS.typeList[i].name,
                                                FtpFS.typeList[i].files[j].name);
                                            noFileOnFtp = false;
                                        }
                                        catch { }
                                        break;
                                    }
                                    if (noFileOnFtp)
                                    { //从来源下载

                                        if (GetDoc(cAccess.basicDt.Rows[row]["DocTitle"].ToString(), cAccess.basicDt.Rows[row]["Source"].ToString(),
                                              cAccess.basicDt.Rows[row]["DocType"].ToString(), "", "", "", false))
                                        { }
                                        else
                                        {
                                            ls.Add(cAccess.basicDt.Rows[row]["ID"].ToString());
                                            lst.Add(cAccess.basicDt.Rows[row]["DocTitle"].ToString());
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (noFileOnFtp)
                    { //从来源下载

                        if (GetDoc(cAccess.basicDt.Rows[row]["DocTitle"].ToString(), cAccess.basicDt.Rows[row]["Source"].ToString(),
                              cAccess.basicDt.Rows[row]["DocType"].ToString(), "", "", "", false))
                        { }
                        else
                        {
                            ls.Add(cAccess.basicDt.Rows[row]["ID"].ToString());
                            lst.Add(cAccess.basicDt.Rows[row]["DocTitle"].ToString());
                        }
                    }
                }
            }
            if (ls.Count > 0)
            {
                string s = "";
                foreach (string str in lst)
                {
                    s += str + "\n";
                }
                if (MessageBox.Show("有" + ls.Count + "个文件丢失，并且通过来源重新获取失败，是否从数据库中排除这些文件？\n" + s, "", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    foreach (string str in ls)
                    {
                        cAccess.delect(str);
                    }
            }
        }

        ///// <summary>
        ///// 将FTP上被标记的文件下载下来
        ///// </summary>
        //public void record()
        //{
        //    for (int i = 0; i < FtpFS.typeList.Count; i++)
        //    {
        //        for (int j = 0; j < FtpFS.typeList[i].FileList.Count; j++)
        //        {
        //            if (!FtpFS.typeList[i].FileList[j].isRecord)
        //            {
        //                if (File.Exists(cConfig.strWorkPath + FtpFS.typeList[i].name + FtpFS.typeList[i].FileList[j].name))
        //                    continue;
        //                fh.Download(cConfig.strWorkPath + "\\" + FtpFS.typeList[i].name, FtpFS.typeList[i].FileList[j].name);

        //                cAccess.add(FtpFS.typeList[i].FileList[j].name, "",
        //                    cConfig.strWorkPath + FtpFS.typeList[i].name + FtpFS.typeList[i].FileList[j].name,
        //                    FtpFS.typeList[i].name, "", cConfig.FTP_IP, "从FTP上下载的文件");

        //                FtpFS.typeList[i].FileList[j].isRecord = true;
        //            }
        //        }
        //    }
        //}

        #region 静态方法

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
        public static bool GetDoc(string Title, string Url, string type = "", string rlDate = "",
            string provider = "", string notes = "", bool isAddRecord = true)
        {
            try
            {
                Uri u = new Uri(Url);
                if (u.Scheme.ToLower() == "http")
                {//网址
                    List<cWord> lw = new List<cWord>();
                    lw.Add(new cWord(Title, u.AbsoluteUri, type, rlDate, provider, notes, isAddRecord));
                    cMakeWord mw = new cMakeWord(lw);
                    Thread th = new Thread(new System.Threading.ThreadStart(mw.makeWord));
                    th.Start();
                }
                else if (u.Scheme.ToLower() == "ftp")
                {
                    string ap = u.AbsolutePath.Substring(0, u.AbsolutePath.LastIndexOf('/'));
                    string file = u.AbsolutePath.Replace(ap, "");
                    //暂时不提供ftp文件的下载
                    FTPHelper _fh = new FTPHelper(u.Authority, ap, "", "");

                    _fh.Download(cConfig.strWorkPath + "\\" + type, file);
                    if (isAddRecord)
                        cAccess.add(Title, u.AbsoluteUri, cConfig.strWorkPath + "\\" + type + "\\" + file, type, rlDate, provider, notes);
                }
                else if (u.Scheme.ToLower() == "file")
                {//本地文件
                    string HouZui = u.LocalPath.Substring(u.LocalPath.LastIndexOf('.'));

                    string pFilePath;
                    if (type == "")
                        type = cConfig.strNoType;
                    pFilePath = cConfig.strWorkPath + "\\" + type;

                    if (!(Directory.Exists(pFilePath)))
                        Directory.CreateDirectory(pFilePath);

                    pFilePath += "\\" + Title + HouZui;
                    if (File.Exists(pFilePath))
                    {
                        //MessageBox.Show("公文库中已有同名公文，请修改公文标题或类型！");
                        return true;
                    }
                    File.Copy(Url, pFilePath);
                    if (isAddRecord)
                        cAccess.add(Title, u.LocalPath, pFilePath, type, rlDate, provider, notes);
                }
                else { return false; }
                frmMain.fm.flash();
                return true;
            }
            catch
            {
                return false;
                throw;
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
                    searchFile(f.FullName);
            }
        }
        private static void delectFiles(string[] path)
        {
            foreach (string f in path)
            {
                File.Delete(f);
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
                string title;
                if (end > titleStart)
                    title = url.Substring(titleStart + 1, end - titleStart - 1);
                else
                    title = url.Substring(titleStart + 1);
                string type = url.Substring(typeStart + 1, titleStart - typeStart - 1);
                if (type == cConfig.strWorkFolder) continue;
                bool isNotRecord = true;
                for (int i = 0; i < cAccess.basicDt.Rows.Count; i++)
                {
                    if (url == cAccess.basicDt.Rows[i]["LocalPath"].ToString())
                    {
                        isNotRecord = false;
                        break;
                    }
                }
                if (isNotRecord)
                    cAccess.add(title, url, url, type, "", Environment.UserName, "自工作目录中检测出的文档");
            }
        }

        #endregion




    }
}
