using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Xml.Linq;
using Microsoft.Office.Interop.Word;
namespace DMS
{
    /// <summary>
    /// 生成Work文档
    /// </summary>
    class cMakeWork
    {
        public string fileName, type, tPath, pPath;
        string URL;

        public cMakeWork(string _fileName, string _type, string _URL)
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

            object format = WdSaveFormat.wdFormatDocument;

            ApplicationClass oWordApp = new ApplicationClass();
            oWordApp.Visible = false;


            Document oWordDoc = oWordApp.Documents.Open(ref file1, ref format, ref readOnly, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref isVisible, ref missing, ref missing, ref missing, ref missing);
            oWordDoc.SaveAs(ref file2, ref format, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing, ref missing);
            

            oWordDoc.Close(ref missing, ref missing, ref missing);
            oWordDoc = null;


            oWordApp.Application.Quit(ref missing, ref missing, ref missing);
            oWordApp = null;
        }
    }

    /// <summary>
    /// 批量打印
    /// </summary>
    class cPrintFiles
    {
        public static string paths;
        /// <summary>
        /// 批量打印
        /// </summary>
        /// <param name="paths">要打印的文件的路径，以“|”分隔</param>
        public static void printFiles()
        {
            var wordFiles = new List<object>();
            var docs = new List<Word.Document>();

            string[] p = paths.Split('|');
            foreach (string s in p)
            {
                if (s != "")
                    wordFiles.Add(s);
                //wordFiles.Add(@"E:\testPrint2.doc");
                //wordFiles.Add(@"E:\testPrint3.doc");                
            }
            object oMissing = System.Reflection.Missing.Value;
            var app = new Word.Application();
            try
            {
                //Document doc = app.Documents.Add(ref wordFile, ref oMissing, ref oMissing, ref oMissing);
                Word.Dialog dialog = null;
                foreach (var wordFile in wordFiles)
                {
                    object file = wordFile;
                    Word.Document doc = app.Documents.Open(ref file, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                      ref oMissing, ref oMissing, ref oMissing,
                                                      ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                                      ref oMissing,
                                                      ref oMissing, ref oMissing, ref oMissing);
                    docs.Add(doc);
                    //doc.Activate();
                    if (dialog == null)
                    {
                        dialog = app.Dialogs[Word.WdWordDialog.wdDialogFilePrint];
                        //第一次弹出打印设置窗体单击确定默认就会打印了。
                        //所以这里就判断flag为0，就单击的是取消，就退出；否则就默认打印了
                        int flag = dialog.Show(ref oMissing);
                        if (flag == 0)
                            break;
                        //if ( flag == 1)
                        //{
                        //    dialog.Execute();
                        //    doc.PrintOut(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        //                 ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        //                 ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        //                 ref oMissing, ref oMissing);  
                        //}
                    }
                    else
                    {
                        dialog.Execute();
                        //doc.PrintOut(ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        //             ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        //             ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                        //             ref oMissing, ref oMissing);
                    }
                    System.Threading.Thread.Sleep(1000 * p.Length);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                object saveChange = Microsoft.Office.Interop.Word.WdSaveOptions.wdDoNotSaveChanges;
                foreach (var doc in docs)
                {
                    if (doc != null)
                        doc.Close(ref saveChange, ref oMissing, ref oMissing);
                }
                app.Quit(ref oMissing, ref oMissing, ref oMissing);
            }
        }

    }
}
