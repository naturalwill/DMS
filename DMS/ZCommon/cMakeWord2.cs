using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Forms;

namespace DMS
{
    public class cWord2
    {
        public string DocTitle, URL, tFilePath, pFilePath, type, rlDate, rlUnit, Note;
        public bool AddRecord;
        public cWord2(string fileName, string _URL, string _type = "", string _rlDate = "", string _rlUnit = "", string note = "", bool isAddRecord = true)
        {
            DocTitle = fileName;
            URL = _URL;
            type = _type;
            rlDate = _rlDate;
            rlUnit = _rlUnit;
            Note = note;
            AddRecord = isAddRecord;

            tFilePath = cConfig.TempPath + "\\" + fileName + ".html";

            if (type == "")
                type = cConfig.strNoType;
            pFilePath = cConfig.strWorkPath + "\\" + type;

            if (!(Directory.Exists(pFilePath)))
                Directory.CreateDirectory(pFilePath);
            pFilePath += "\\" + fileName + ".doc";
        }
    }

    public class cMakeWord2
    {
        static string tPath = cConfig.TempPath;

        List<cWord2> listWord;


        /// <summary>
        /// 生成word文档
        /// </summary>
        /// <param name="lw"></param>
        public cMakeWord2(List<cWord2> lw)
        {
            if (!(Directory.Exists(tPath)))
            {
                Directory.CreateDirectory(tPath);
                //File.SetAttributes(tPath, FileAttributes.Hidden);
            }
            listWord = lw;
        }

        /// <summary>
        /// 根据输入的链接地址，下载网页源码，并生成word文档
        /// </summary>
        /// <param name="URL">链接地址</param>
        /// <returns>返回网页源码</returns>
        public void makeWord()
        {

            object missing = System.Reflection.Missing.Value;
            object readOnly = true;
            object isVisible = false;

            object format = Word.WdSaveFormat.wdFormatDocument;

            Word._Application oWordApp = new Word.Application();
            oWordApp.Visible = false;

            int intExist = 0, intSuccess = 0;
            bool isAccess = false;

            for (int i = 0; i < listWord.Count; i++)
            {
                GC.Collect();

                if (File.Exists(listWord[i].pFilePath)) { intExist++; continue; }

                //DMS.SaveWebPage.SaveOaWebPageToMHTFile(listWord[i].URL, listWord[i].tFilePath);

                using (System.Net.WebClient wc = new System.Net.WebClient())
                {
                    Byte[] pageData = wc.DownloadData(listWord[i].URL);
                    string s = System.Text.Encoding.GetEncoding("GBK").GetString(pageData);
                    int start = s.IndexOf("<html");
                    s = s.Remove(0, start + 5);
                    start = s.IndexOf("<html");
                    int stop = s.IndexOf("</html>");

                    byte[] arr = Encoding.GetEncoding("GBK").GetBytes(s.Substring(start, stop - start + 7));
                    File.WriteAllBytes(listWord[i].tFilePath, arr);

                }
                object file1 = listWord[i].tFilePath;
                object file2 = listWord[i].pFilePath;

                Word._Document oWordDoc = oWordApp.Documents.Open(ref file1, ref format, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                oWordDoc.SaveAs(ref file2, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
                //oWordDoc.SaveAs2(ref file2, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                oWordDoc.Close(ref missing, ref missing, ref missing);
                oWordDoc = null;
                if (listWord[i].AddRecord)
                {
                    cAccess.add(listWord[i].DocTitle, listWord[i].URL, listWord[i].pFilePath, listWord[i].type, listWord[i].rlDate, listWord[i].rlUnit, listWord[i].Note);
                    isAccess = true;
                }
                intSuccess++;

            }
            if (isAccess)
                cAccess.DtAdapter.Update(cAccess.basicDt);

            oWordApp.Quit(ref missing, ref missing, ref missing);
            oWordApp = null;

            if (listWord.Count > 1)
                MessageBox.Show("批量下载完成！共选择了" + listWord.Count + "个。成功下载" + intSuccess + "个，有" + intExist + "个文档在此之前已下载，有" + (listWord.Count - intSuccess - intExist) + "个下载失败");
            else if (listWord.Count == 1)
                MessageBox.Show("添加成功");
            frmMain.fm.initialize();
        }


    }
}
