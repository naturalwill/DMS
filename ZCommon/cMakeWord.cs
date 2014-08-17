using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Word = Microsoft.Office.Interop.Word;


namespace ZCommon
{
    public class cWord
    {
        public string DocTitle, URL, tFilePath, pFilePath, type, rlDate, rlUnit, Note;
        public cWord(string fileName, string _URL, string _type = "", string _rlDate = "", string _rlUnit = "", string note = "")
        {
            DocTitle = fileName;
            URL = _URL;
            type = _type;
            rlDate = _rlDate;
            rlUnit = _rlUnit;
            Note = note;

            tFilePath = cConfig.strWorkPath + "\\" + cConfig.strTemp + "\\" + fileName + ".html";

            if (type == "")
                type = cConfig.strNoType;
            pFilePath = cConfig.strWorkPath + "\\" + type;

            if (!(Directory.Exists(pFilePath)))
                Directory.CreateDirectory(pFilePath);
            pFilePath += "\\" + fileName + ".doc";
        }
    }

    public class cMakeWord
    {
        static string tPath = cConfig.strWorkPath + "\\" + cConfig.strTemp;

        List<cWord> listWord;


        /// <summary>
        /// 生成word文档
        /// </summary>
        /// <param name="lw"></param>
        public cMakeWord(List<cWord> lw)
        {
            if (!(Directory.Exists(tPath)))
            {
                Directory.CreateDirectory(tPath);
                File.SetAttributes(tPath, FileAttributes.Hidden);
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
            cConfig.working = true;

            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            object isVisible = true;

            object format = Word.WdSaveFormat.wdFormatDocument;

            Word.ApplicationClass oWordApp = new Word.ApplicationClass();
            oWordApp.Visible = false;

            for (int i = 0; i < listWord.Count; i++)
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                Byte[] pageData = wc.DownloadData(listWord[i].URL);
                string s = System.Text.Encoding.Default.GetString(pageData);
                //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码

                using (StreamWriter sw = new StreamWriter(listWord[i].tFilePath, false, Encoding.Unicode))
                {
                    sw.Write(s);
                }

                object file1 = listWord[i].tFilePath;
                object file2 = listWord[i].pFilePath;

                Word.Document oWordDoc = oWordApp.Documents.Open(ref file1, ref format, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
                oWordDoc.SaveAs(ref file2, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);

                oWordDoc.Close(ref missing, ref missing, ref missing);
                oWordDoc = null;

                cAccess.add(listWord[i].DocTitle, listWord[i].URL, listWord[i].pFilePath, listWord[i].type, listWord[i].rlDate, listWord[i].rlUnit, listWord[i].Note);
            }
            cAccess.DtAdapter.Update(cAccess.DtTable);

            oWordApp.Application.Quit(ref missing, ref missing, ref missing);
            oWordApp = null;
            cConfig.needFlash = true;
        }


    }
}
