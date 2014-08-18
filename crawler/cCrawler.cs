using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace crawler
{
    class cCrawler
    {
        #region 私有字段



        #endregion

        #region 公共字段
        /// <summary>
        /// URL格式
        /// </summary>
        public static string formatUrl = "http://oa.gdmc.edu.cn:8083/ggxx_new/detail_show.jsp?notemplate&seq=|<0>|&boardid=|<1>|&classcode=|<1>|&pageno=";

        /// <summary>
        /// 二维列表
        /// </summary>
        public static List<cList> lcl;

        public static int pages = 1;
        #endregion

        /// <summary>
        /// 在网页源码中搜索信息，包括公文名称，发布者，发布时间和公文网址
        /// </summary>
        /// <param name="URL">URL</param>
        public static void getInformation(string URL)
        {
            string s;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                Byte[] pageData = wc.DownloadData(URL);
                s = System.Text.Encoding.Default.GetString(pageData);
                //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码
            }
            lcl = new List<cList>();

            string seq, classcode, strName, strTime;

            string regPages = @"共\d+页";
            Regex rp = new Regex(regPages);
            Match mp = rp.Match(s);
            pages = Convert.ToInt32(Regex.Replace(mp.Value, "[共|页]*", string.Empty, RegexOptions.IgnoreCase));

            string strRegex = "onclick=\"this.href=SendComplexUrl\\('[0-9]+','[0-9]+'\\);\">\\s*\\S+\\s*</td>\\s*<.*>\\s*.*\\s*</.*>\\s*<.*>\\s*.*";
            //string strRegex = @"httpk://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex r = new Regex(strRegex, RegexOptions.IgnoreCase);
            MatchCollection m = r.Matches(s);

            for (int i = 0; i < m.Count; i++)
            {
                string str = m[i].ToString();
                seq = str.Substring(str.IndexOf("SendComplexUrl") + 16, str.IndexOf(",") - str.IndexOf("SendComplexUrl") - 17);
                classcode = str.Substring(str.IndexOf(",") + 2, str.IndexOf(";") - str.IndexOf(",") - 4);
                strName = str.Substring(str.IndexOf(">") + 1, str.IndexOf("<") - str.IndexOf(">") - 1).Trim();
                strTime = str.Substring(str.Length - 20).Trim();
                str = System.Text.RegularExpressions.Regex.Replace(str, "onclick=\"this.href=SendComplexUrl\\('[0-9]+','[0-9]+'\\);\">\\s*\\S+\\s*</td>\\s*<.*>\\s*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                str = System.Text.RegularExpressions.Regex.Replace(str, "\\s+</.*>\\s*<.*>\\s*.*", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase).Trim();

                List<string> lsUrl = new List<string>(), lsInfo = new List<string>();
                lsUrl.Add(seq); lsUrl.Add(classcode);
                lsInfo.Add(strName); lsInfo.Add(strTime); lsInfo.Add(str);
                //cList cl = new cList(i, ref formatUrl, ref lsUrl, ref lsInfo);
                lcl.Add(new cList(i, ref formatUrl, ref lsUrl, ref lsInfo));
            }
        }

        /// <summary>
        /// 根据输入的链接地址，下载网页源码
        /// </summary>
        /// <param name="URL">链接地址</param>
        /// <returns>返回网页源码</returns>
        public static string getWebCode(string URL)
        {
            string s;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                Byte[] pageData = wc.DownloadData(URL);
                s = System.Text.Encoding.Default.GetString(pageData);
                //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码
            }
            return s;
        }

        /// <summary>
        /// 下载网页
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="path"></param>
        public static void downWeb(string URL, string path)
        {
            string s;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                Byte[] pageData = wc.DownloadData(URL);
                s = System.Text.Encoding.Default.GetString(pageData);
                //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码
            }
            using (StreamWriter sw = new StreamWriter(path, false, Encoding.Unicode))
            {
                sw.Write(s);
            }
        }

        /// <summary>
        /// 在网页源码中查找总页数
        /// </summary>
        /// <returns></returns>
        public static int findPages(string strWeb)
        {
            string strNum = System.Text.RegularExpressions.Regex.Match(strWeb, @"共[\d]+页", System.Text.RegularExpressions.RegexOptions.None).ToString();
            return Convert.ToInt32(strNum.Substring(1, strNum.Length - 2));
        }

        /// <summary>
        /// 下载网页，同时删除表格和图片
        /// </summary>
        /// <param name="URL"></param>
        /// <param name="table"></param>
        /// <returns></returns>
        public static string downloadWeb(string URL, bool table)
        {
            string s;
            using (System.Net.WebClient wc = new System.Net.WebClient())
            {
                Byte[] pageData = wc.DownloadData(URL);
                s = System.Text.Encoding.Default.GetString(pageData);
                //s = System.Text.Encoding.UTF8.GetString(pageData);去除中文乱码
            }
            s = System.Text.RegularExpressions.Regex.Replace(s, @"<table.*>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            s = System.Text.RegularExpressions.Regex.Replace(s, @"</table>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            s = System.Text.RegularExpressions.Regex.Replace(s, @"<[IMGimg]{3}.*>", "", System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            return s;
        }



    }

}
