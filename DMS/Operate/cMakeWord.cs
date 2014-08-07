using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DMS.Common;
using System.IO;
using Word = Microsoft.Office.Interop.Word;

namespace DMS.Operate
{
    class cMakeWord
    {
        public string fileName, type, tPath, pPath;
        string URL;

        public cMakeWord(string _fileName, string _type, string _URL)
        {
            fileName = _fileName;

            type = _type;
            URL = _URL;

            tPath = cConfig.strWorkPath + "\\.temp";
            if (type != "")
                pPath = cConfig.strWorkPath + "\\" + type;
            else
                pPath = cConfig.strWorkPath;

            if (!(Directory.Exists(tPath))) Directory.CreateDirectory(tPath);
            if (!(Directory.Exists(pPath))) Directory.CreateDirectory(pPath);

            tPath += "\\" + fileName + ".html";
            pPath += "\\" + fileName + ".doc";
        }

        /// <summary>
        /// 根据输入的链接地址，下载网页源码
        /// </summary>
        /// <param name="URL">链接地址</param>
        /// <returns>返回网页源码</returns>
        public void makeWord()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            Byte[] pageData = wc.DownloadData(URL);
            string s = System.Text.Encoding.Default.GetString(pageData);
            //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码

            using (StreamWriter sw = new StreamWriter(tPath, false, Encoding.Unicode))
            {
                sw.Write(s);
            }
            SaveAsWord(tPath, pPath);
        }


        /// <summary>
        /// html转换成word
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="pFileName"></param>
        public void SaveAsWord(string fileName, string pFileName)
        {
            object missing = System.Reflection.Missing.Value;
            object readOnly = false;
            object isVisible = true;
            object file1 = fileName;
            object file2 = pFileName;

            object format = Word.WdSaveFormat.wdFormatDocument;

            Word.ApplicationClass oWordApp = new Word.ApplicationClass();
            oWordApp.Visible = false;


            Word.Document oWordDoc = oWordApp.Documents.Open(ref file1, ref format, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
            oWordDoc.SaveAs(ref file2, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);


            oWordDoc.Close(ref missing, ref missing, ref missing);
            oWordDoc = null;


            oWordApp.Application.Quit(ref missing, ref missing, ref missing);
            oWordApp = null;
        }
    }
}
