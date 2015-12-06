using Crawler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.XPath;

namespace Crawler
{
   public class CrawlerNew
    {
        private static List<cList> lcl;

        /// <summary>
        /// 在网页源码中搜索信息，包括公文名称，发布者，发布时间和公文网址
        /// </summary>
        /// <param name="URL">URL</param>
        public static void getinfo(string URL)
        {
            XPathDocument doc = new XPathDocument(URL);
            XPathNavigator xPathNav = doc.CreateNavigator();
       
            string s = xPathNav.SelectSingleNode(@"//*[@id=""spanId_pages""]").Value;
            
            string regPages = @"\d";
            Regex rp = new Regex(regPages);
            Match mp = rp.Match(s);
            int pages= Convert.ToInt32(mp.Value);

            XPathNodeIterator nodeIterator = xPathNav.Select(@"//*[@id=""tdId_newslist""]/table/tbody/tr");

            while (nodeIterator.MoveNext())
            {
                XPathNavigator itemNav = nodeIterator.Current;
                string title = itemNav.SelectSingleNode("title").Value;
                string url = itemNav.SelectSingleNode("/td[3]/span").Value;
                System.Diagnostics.Debug.WriteLine("{0} = {1}", title, url);
            }

            string strRegex = "onclick=\"this.href=SendComplexUrl\\('[0-9]+','[0-9]+'\\);\">\\s*\\S+\\s*</td>\\s*<.*>\\s*.*\\s*</.*>\\s*<.*>\\s*.*";
            //string strRegex = @"httpk://([\w-]+\.)+[\w-]+(/[\w- ./?%&=]*)?";
            Regex r = new Regex(strRegex, RegexOptions.IgnoreCase);
            MatchCollection m = r.Matches(s);

            string seq, classcode, strName, strTime;
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
              //  lcl.Add(new cList(i, ref formatUrl, ref lsUrl, ref lsInfo));
            }
        }

    }
}
