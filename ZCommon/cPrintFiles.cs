using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace ZCommon
{
    public class cPrintFiles
    {
        List<string> listWord;
        /// <summary>
        /// 初始化批量打印
        /// </summary>
        /// <param name="lpf">要打印的文件列表</param>
        public cPrintFiles(List<string> lpf)
        {
            listWord = lpf;
        }
        /// <summary>
        /// 批量打印
        /// </summary>
        public void printFiles()
        {
            var wordFiles = new List<object>();
            var docs = new List<Word._Document>();
            
            foreach (string s in listWord)
            {
                if (s != "")
                    wordFiles.Add(s);
                //wordFiles.Add(@"E:\testPrint2.doc");
                //wordFiles.Add(@"E:\testPrint3.doc");                
            }
            object oMissing = System.Reflection.Missing.Value;
            Word._Application app = new Word.Application();
            try
            {
                //Document doc = app.Documents.Add(ref wordFile, ref oMissing, ref oMissing, ref oMissing);
                Word.Dialog dialog = null;
                foreach (var wordFile in wordFiles)
                {
                    object file = wordFile;
                    Word._Document doc = app.Documents.Open(ref file, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
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
                    System.Threading.Thread.Sleep(1000 * listWord.Count);
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
