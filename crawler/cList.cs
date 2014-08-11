using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace crawler
{
    class cList
    {
        public int ID;
        public string URL;
        public List<string> listInfo;

        public cList(int _ID, ref string formatURL, ref List<string> listURL, ref List<string> _listInfo)
        {
            ID = _ID;

            URL = formatURL;
            for (int i = 0; i < listURL.Count; i++)
            {
                URL = System.Text.RegularExpressions.Regex.Replace(URL, @"\|<" + i + @">\|", listURL[i], System.Text.RegularExpressions.RegexOptions.IgnoreCase);
            }
            
            listInfo = _listInfo;
        }

    }
}
