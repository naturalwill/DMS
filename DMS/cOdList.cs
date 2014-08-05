using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS
{
    class cOdList
    {
        public cOdList(int _ID, DateTime _AddTime, string _DocTitle, string _Source, string _DocType = "",  string _ReleaseDate = "", string _Provider = "", string _Notes = "")
        {
            ID = _ID;
            AddTime = _AddTime;
            DocTitle = _DocTitle;
            Source = _Source;
            DocTitle = _DocType;          
            ReleaseDate = _ReleaseDate;
            Provider = _Provider;
            Notes = _Notes;
        }
        public int ID;
        public DateTime AddTime;
        public string DocTitle,  Source, DocType, ReleaseDate, Provider, Notes;
    }
}
