using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
namespace DMS
{
    class SaveWebPage
    {

        /// <summary>
        /// 专门针对办公网的下载web方法
        /// </summary>
        /// <param name="url">url是要保存的网页地址</param>
        /// <param name="filePath">filePath是保存到的文件路径</param>
        /// <returns></returns>
        public static bool SaveOaWebPageToMHTFile(string url, string filePath)
        {
            bool result = false;
            CDO.Message msg = new CDO.Message();
            ADODB.Stream stm = null;
            msg.Configuration = new CDO.Configuration();
            try
            {
                msg.MimeFormatted = true;
                msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressNone, "", "");

                if (url.Substring(0,cConfig.strOaURL.Length) == cConfig.strOaURL)
                {
                    stm = msg.GetStream();
                    stm.Charset = "GB2312";

                    using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                    {
                        string s = Regex.Replace(stm.ReadText(), "<img width=\\\"100%\\\" height=\\\"100\\\"(.[^>]*)>", "", RegexOptions.IgnoreCase);
                        s = Regex.Replace(s, "<P(.[^>]*)>", "<P>", RegexOptions.IgnoreCase);
                        s = Regex.Replace(s, "<a(.[^>]*)javascript:window.close(.[^>]*)><img src=(.[^>]*)>", "", RegexOptions.IgnoreCase);
                        s = Regex.Replace(s, "<table width=\\\"98%\\\"(.[^>]*)>", "", RegexOptions.IgnoreCase);
                        byte[] array = Encoding.Default.GetBytes(s);
                        fs.Write(array, 0, array.Length);
                        //fs.Close();
                    }
                    stm.Close();
                }
                else
                {
                    msg.GetStream().SaveToFile(filePath, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
                }

                msg = null;
                result = true;
            }
            catch //(Exception ex)
            {
            }
            finally
            {
                //cleanup here  
            }
            return result;
        }

        /// <summary>
        /// 下载web方法
        /// </summary>
        /// <param name="url">url是要保存的网页地址</param>
        /// <param name="filePath">filePath是保存到的文件路径</param>
        /// <returns></returns>
        public static bool SaveWebPageToMHTFile(string url, string filePath)
        {
            bool result = false;
            //CDO.Message msg = new CDO.MessageClass();
            CDO.Message msg = new CDO.Message();
            //ADODB.Stream stm = null;

            try
            {
                msg.MimeFormatted = true;
                msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressNone, "", "");

                //stm = msg.GetStream();
                //stm.SaveToFile(filePath, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
                msg.GetStream().SaveToFile(filePath, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
                msg = null;
                //stm.Close();
                result = true;
            }
            catch //(Exception ex)
            {
            }
            finally
            {
                //cleanup here  
            }
            return result;
        }

        public static void SaveWebPageToMHTFile2(string url, string filePath)
        {
            try
            {
                CDO.Message msg = new CDO.Message();
                CDO.Configuration cfg = new CDO.Configuration();

                msg.Configuration = cfg;
                // 第一参数为url，第二参数为支持格式，第三参数为用户ID，第四参数为用户密码
                msg.CreateMHTMLBody(url, CDO.CdoMHTMLFlags.cdoSuppressAll, "", "");
                msg.GetStream().SaveToFile(filePath, ADODB.SaveOptionsEnum.adSaveCreateOverWrite);
                msg = null;
                //MessageBox.Show("Save OK!!!");
            }
            catch //(Exception ex)
            {
                //MessageBox.Show("Error:" + ex.Message);
            }
        }
    }
}
