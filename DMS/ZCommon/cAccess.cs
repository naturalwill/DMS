using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace DMS
{
    public class cAccess
    {
        static string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + cConfig.strDatabasePath;

        static OleDbConnection conn = new OleDbConnection(connString);
        //static OleDbCommand cmd;
        //static OleDbDataReader DtReader;

        public static OleDbDataAdapter DtAdapter;
        static OleDbCommandBuilder CoBuilder;

        public static DataTable basicDt;
        public static DataTable newDt;

        /// <summary>
        /// 加载数据库
        /// </summary>
        public static bool load()
        {
            if (!(File.Exists(cConfig.strDatabasePath)))
            {
                FileStream fs = new FileStream(cConfig.strDatabasePath, FileMode.OpenOrCreate, FileAccess.Write);
                try
                {
                    Byte[] b = DMS.Properties.Resources.DMS;
                    fs.Write(b, 0, b.Length);
                    if (fs != null)
                        fs.Close();
                }
                catch
                {
                    if (fs != null)
                        fs.Close();
                    return false;
                }


                //ADOX.CatalogClass cat = new ADOX.CatalogClass();
                //cat.Create(connString);
                //System.Diagnostics.Debug.Write("Database Created Successfully");
                //cat = null;
                ////                    conn.Open();
                ////                    string sql = @"CREATE TABLE [OfficialDocument] 
                ////(
                ////[ID] int NOT NULL,
                ////[AddTime] datetime NOT NULL,
                ////[DocTitle] varchar(255) NOT NULL,
                ////[ReleaseDate] datetime,
                ////[Provider] varchar(255),
                ////[Source] varchar(max),
                ////[DocType] varchar(255),
                ////[LocalPath] varchar(max),
                ////[Notes] varchar(max)
                ////)";
                ////                    cmd = new OleDbCommand(sql, conn);
                ////                    cmd.ExecuteNonQuery();
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter = new OleDbDataAdapter("Select * From OfficialDocument", conn);

            CoBuilder = new OleDbCommandBuilder(DtAdapter);
            basicDt = new DataTable();
            DtAdapter.Fill(basicDt);
            newDt = new DataTable();
            newDt = basicDt.Clone();
            foreach (DataRow drs in basicDt.Select("", "ID desc"))
            {
                newDt.ImportRow(drs);
            }
            //newDt = basicDt.Copy();
            conn.Close();
            return true;

        }


        /// <summary>
        /// 添加记录
        /// </summary>
        /// <param name="_DocTitle"></param>
        /// <param name="_Source"></param>
        /// <param name="_LocalPath"></param>
        /// <param name="_DocType"></param>
        /// <param name="_ReleaseDate"></param>
        /// <param name="_Provider"></param>
        /// <param name="_Notes"></param>
        public static void add(string _DocTitle, string _Source, string _LocalPath,
                                string _DocType = cConfig.strNoType, string _ReleaseDate = "",
                                string _Provider = "", string _Notes = "")
        {
            DataRow drNewRow = basicDt.NewRow();//声明 DataRow 集合的变量  drNewRow。用于单行的操作

            drNewRow["ID"] = getMaxID();
            drNewRow["AddTime"] = System.DateTime.Now;

            drNewRow["DocTitle"] = _DocTitle;

            drNewRow["Source"] = _Source;
            drNewRow["LocalPath"] = _LocalPath;

            drNewRow["DocType"] = _DocType;

            try
            {
                drNewRow["ReleaseDate"] = Convert.ToDateTime(_ReleaseDate);
            }
            catch { }
            drNewRow["Provider"] = _Provider;

            drNewRow["Notes"] = _Notes;
            basicDt.Rows.InsertAt(drNewRow, 0);//增加到 DtTable变量，临时保存

            if (conn.State != ConnectionState.Open)
                conn.Open();

            DtAdapter.Update(basicDt);//用Update（）方法更新数据库
            conn.Close();
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        static int getMaxID()
        {
            int max = 0;
            for (int i = 0; i < basicDt.Rows.Count; i++)
            {
                if (max < Convert.ToInt32(basicDt.Rows[i]["ID"]))
                    max = Convert.ToInt32(basicDt.Rows[i]["ID"]);
            }
            return max + 1;
        }
        public static void delect(string id)
        {
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                if (id == cAccess.basicDt.Rows[row]["ID"].ToString())
                {
                    try
                    {
                        File.Delete(basicDt.Rows[row]["LocalPath"].ToString());
                    }
                    catch { }
                    basicDt.Rows[row].Delete();

                }
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(basicDt);//用Update（）方法更新数据库
            conn.Close();
        }



        /// <summary>
        /// 修改公文属性
        /// </summary>
        /// <param name="id"></param>
        /// <param name="_DocTitle"></param>
        /// <param name="_Source"></param>
        /// <param name="_LocalPath"></param>
        /// <param name="_DocType"></param>
        /// <param name="_ReleaseDate"></param>
        /// <param name="_Provider"></param>
        /// <param name="_Notes"></param>
        //public static void Modify(string id, string _DocTitle, string _Source,
        //                        string _LocalPath, string _DocType = "",
        //                        string _ReleaseDate = "", string _Provider = "",
        //                        string _Notes = "")
        //{
        //    for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
        //    {
        //        if (id == cAccess.basicDt.Rows[row]["ID"].ToString())
        //        {
        //            cAccess.basicDt.Rows[row]["DocTitle"] = _DocTitle;

        //            try
        //            {
        //                cAccess.basicDt.Rows[row]["ReleaseDate"] = Convert.ToInt32(_ReleaseDate);
        //            }
        //            catch { }

        //            cAccess.basicDt.Rows[row]["Provider"] = _Provider;

        //            cAccess.basicDt.Rows[row]["DocType"] = _DocType;
        //            cAccess.basicDt.Rows[row]["Source"] = _Source;
        //            cAccess.basicDt.Rows[row]["Note"] = _Notes;
        //            cAccess.basicDt.Rows[row]["LocalPath"] = _LocalPath;
        //        }
        //    }
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    DtAdapter.Update(basicDt);//用Update（）方法更新数据库
        //    conn.Close();
        //}

        /// <summary>
        /// 更改同一类型公文的类型
        /// </summary>
        /// <param name="currentType"></param>
        /// <param name="newType"></param>
        public static void ModifyType(string currentType, string newType)
        {
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                if (currentType == cAccess.basicDt.Rows[row]["DocType"].ToString())
                {
                    basicDt.Rows[row]["LocalPath"] = basicDt.Rows[row]["LocalPath"].ToString().Replace("\\" + currentType + "\\", "\\" + newType + "\\");
                    basicDt.Rows[row]["DocType"] = newType;
                }
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            Directory.Move(cConfig.strWorkPath + "\\" + currentType, cConfig.strWorkPath + "\\" + newType);
            DtAdapter.Update(basicDt);//用Update（）方法更新数据库
            conn.Close();
        }

        /// <summary>
        /// 更改指定ID的类型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newType"></param>
        public static void ModifyTheType(string id, string newType)
        {
            for (int row = 0; row < cAccess.basicDt.Rows.Count; row++)
            {
                if (id == cAccess.basicDt.Rows[row]["ID"].ToString())
                {
                    basicDt.Rows[row]["LocalPath"] = basicDt.Rows[row]["LocalPath"].ToString().Replace('\\' + basicDt.Rows[row]["DocType"].ToString() + '\\', '\\' + newType + '\\');
                    basicDt.Rows[row]["DocType"] = newType;
                }
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(basicDt);//用Update（）方法更新数据库
            conn.Close();
        }
        //修改公文属性
        public static void ChangePermissions(string txtTitle, string txtreleasetime, string cobTypeText, string txtunit, string txtnote, int Row)
        {
            try
            {
                basicDt.Rows[Row]["ReleaseDate"] = Convert.ToDateTime(txtreleasetime);
            }
            catch { }
            basicDt.Rows[Row]["Provider"] = txtunit;
            basicDt.Rows[Row]["Notes"] = txtnote;
            basicDt.Rows[Row]["LocalPath"] = basicDt.Rows[Row]["LocalPath"].ToString().Replace('\\' + basicDt.Rows[Row]["DocType"].ToString() + '\\', '\\' + cobTypeText + '\\');
            basicDt.Rows[Row]["LocalPath"] = basicDt.Rows[Row]["LocalPath"].ToString().Replace('\\' + basicDt.Rows[Row]["DocTitle"].ToString(), '\\' + txtTitle);
            basicDt.Rows[Row]["DocType"] = cobTypeText;
            basicDt.Rows[Row]["DocTitle"] = txtTitle;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(basicDt);//用Update（）方法更新数据库
            conn.Close();
        }

        //public static void searchDoc(string key)
        //{
        //    string cmdText = "SELECT * FROM OfficialDocument WHERE DocTitle LIKE '%" + key + "%'";
        //    if (!string.IsNullOrEmpty(cmdText))
        //    {
        //        cmdText += "Notes='" + cmdText + "' or ";
        //    }
        //    if (!string.IsNullOrEmpty(cmdText))
        //    {
        //        cmdText += "Notes='" + cmdText + "' or ";
        //    }
        //    if (cmdText.EndsWith(" or "))
        //    {
        //        int indexOfAnd = cmdText.LastIndexOf(" or ");
        //        cmdText = cmdText.Substring(0, indexOfAnd);
        //    }

        //    cmd = new OleDbCommand(cmdText, conn);

        //    conn.Open();
        //    DtReader = cmd.ExecuteReader();


        //    while (DtReader.Read())
        //    {
        //        for (int i = 0; i < DtReader.FieldCount; i++)
        //        {
        //            Console.Write(Convert.ToString(DtReader.GetValue(i)) + '\t');
        //        } Console.Write('\n');
        //    }
        //}


        /// <summary>
        /// 搜索数据库
        /// </summary>
        /// <param name="key">关键词</param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="dateType"></param>
        public static void search(string key, string startDate, string endDate, int dateType = 0)
        {
            List<string> ls = new List<string>();

            foreach (string s in key.Trim().Split(' '))
            {
                if (!string.IsNullOrWhiteSpace(s))
                    ls.Add(s);
            }

            string filterExpression = "";

            for (int i = 0; i < ls.Count; i++)
            {
                filterExpression += "( DocTitle LIKE '%" + ls[i] + "%' or ";
                filterExpression += "Provider LIKE '%" + ls[i] + "%' or ";
                filterExpression += "Notes LIKE '%" + ls[i] + "%' ) and ";
            }

            if (dateType == 0)
                filterExpression += "(( AddTime > '" + startDate + "' and AddTime < '" + endDate +
                                    "') or ( ReleaseDate > '" + startDate + "' and ReleaseDate < '" + endDate + "' ))";
            else if (dateType == 1)
                filterExpression += "(( AddTime > '" + startDate + "' and AddTime < '" + endDate + "')";
            else if (dateType == 2)
                filterExpression += "( ReleaseDate > '" + startDate + "' and ReleaseDate < '" + endDate + "' ))";


            if (filterExpression.EndsWith(" and "))
            {
                int indexOfAnd = filterExpression.LastIndexOf(" and ");
                filterExpression = filterExpression.Substring(0, indexOfAnd);
            }
            else if (filterExpression.EndsWith(" or "))
            {
                int indexOfAnd = filterExpression.LastIndexOf(" or ");
                filterExpression = filterExpression.Substring(0, indexOfAnd);
            }

            newDt.Clear();

            foreach (DataRow drs in basicDt.Select(filterExpression, "ID desc"))
            {
                newDt.ImportRow(drs);
            }
        }

        public static List<string> selectType(string _type = "")
        {
            List<string> ls = new List<string>();
            if (string.IsNullOrWhiteSpace(_type))
            {
                foreach (DataRow drs in newDt.Rows)
                {
                    ls.Add(drs["ID"].ToString());
                }
            }
            else
            {
                string filterExpression = "DocType = '" + _type + "'";
                foreach (DataRow drs in newDt.Select(filterExpression))
                {
                    ls.Add(drs["ID"].ToString());
                }
            }
            return ls;
        }


    }
}
