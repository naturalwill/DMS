using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.IO;

namespace ZCommon
{
    public class cAccess
    {
        static string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + cConfig.strDatabasePath;

        static OleDbConnection conn = new OleDbConnection(connString);
        //static OleDbCommand cmd;
        //static OleDbDataReader DtReader;

        public static OleDbDataAdapter DtAdapter;
        static OleDbCommandBuilder CoBuilder;

        public static DataTable DtTable;


        /// <summary>
        /// 加载数据库
        /// </summary>
        public static bool load()
        {
            if (!(File.Exists(cConfig.strDatabasePath)))
            {
                FileStream fs = new FileStream(cConfig.strDatabasePath, FileMode.OpenOrCreate);
                try
                {
                    Byte[] b = ZCommon.Properties.Resources.DMS;
                    fs.Write(b, 0, b.Length);
                }
                catch
                {
                    if (fs != null)
                        fs.Close();
                    return false;
                }
                finally
                {
                    if (fs != null)
                        fs.Close();
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
            DtTable = new DataTable();
            DtAdapter.Fill(DtTable);
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
                                string _DocType = "", string _ReleaseDate = "",
                                string _Provider = "", string _Notes = "")
        {
            DataRow drNewRow = DtTable.NewRow();//声明 DataRow 集合的变量  drNewRow。用于单行的操作

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

            DtTable.Rows.Add(drNewRow);//增加到 DtTable变量，临时保存

            if (conn.State != ConnectionState.Open)
                conn.Open();

            DtAdapter.Update(DtTable);//用Update（）方法更新数据库
            conn.Close();
        }

        /// <summary>
        /// 获取最大ID
        /// </summary>
        /// <returns></returns>
        static int getMaxID()
        {
            int max = 0;
            for (int i = 0; i < DtTable.Rows.Count; i++)
            {
                if (max < Convert.ToInt32(DtTable.Rows[i]["ID"]))
                    max = Convert.ToInt32(DtTable.Rows[i]["ID"]);
            }
            return max + 1;
        }
        public static void delect(string id)
        {
            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                if (id == cAccess.DtTable.Rows[row]["ID"].ToString())
                {
                    File.Delete(DtTable.Rows[row]["LocalPath"].ToString());
                    DtTable.Rows[row].Delete();

                }
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(DtTable);//用Update（）方法更新数据库
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
        //    for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
        //    {
        //        if (id == cAccess.DtTable.Rows[row]["ID"].ToString())
        //        {
        //            cAccess.DtTable.Rows[row]["DocTitle"] = _DocTitle;

        //            try
        //            {
        //                cAccess.DtTable.Rows[row]["ReleaseDate"] = Convert.ToInt32(_ReleaseDate);
        //            }
        //            catch { }

        //            cAccess.DtTable.Rows[row]["Provider"] = _Provider;

        //            cAccess.DtTable.Rows[row]["DocType"] = _DocType;
        //            cAccess.DtTable.Rows[row]["Source"] = _Source;
        //            cAccess.DtTable.Rows[row]["Note"] = _Notes;
        //            cAccess.DtTable.Rows[row]["LocalPath"] = _LocalPath;
        //        }
        //    }
        //    if (conn.State != ConnectionState.Open)
        //        conn.Open();
        //    DtAdapter.Update(DtTable);//用Update（）方法更新数据库
        //    conn.Close();
        //}

        /// <summary>
        /// 更改同一类型公文的类型
        /// </summary>
        /// <param name="currentType"></param>
        /// <param name="newType"></param>
        public static void ModifyType(string currentType, string newType)
        {
            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                if (currentType == cAccess.DtTable.Rows[row]["DocType"].ToString())
                {
                    DtTable.Rows[row]["LocalPath"] = DtTable.Rows[row]["LocalPath"].ToString().Replace(currentType, newType);
                    DtTable.Rows[row]["DocType"] = newType;
                }
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(DtTable);//用Update（）方法更新数据库
            conn.Close();
        }

        /// <summary>
        /// 更改指定ID的类型
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newType"></param>
        public static void ModifyTheType(string id, string newType)
        {
            for (int row = 0; row < cAccess.DtTable.Rows.Count; row++)
            {
                if (id == cAccess.DtTable.Rows[row]["ID"].ToString())
                {
                    DtTable.Rows[row]["LocalPath"] = DtTable.Rows[row]["LocalPath"].ToString().Replace('\\' + DtTable.Rows[row]["DocType"].ToString() + '\\', '\\' + newType + '\\');
                    DtTable.Rows[row]["DocType"] = newType;
                }
            }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(DtTable);//用Update（）方法更新数据库
            conn.Close();
        }
        //修改公文属性
        public static void ChangePermissions(string txtTitle, string txtreleasetime, string cobTypeText, string txtunit, string txtnote, int Row)
        {
            DtTable.Rows[Row]["ReleaseDate"] = txtreleasetime;
            DtTable.Rows[Row]["Provider"] = txtunit;
            DtTable.Rows[Row]["Notes"] = txtnote;
            DtTable.Rows[Row]["LocalPath"] = DtTable.Rows[Row]["LocalPath"].ToString().Replace('\\' + DtTable.Rows[Row]["DocType"].ToString() + '\\', '\\' + cobTypeText + '\\');
            DtTable.Rows[Row]["LocalPath"] = DtTable.Rows[Row]["LocalPath"].ToString().Replace('\\' + DtTable.Rows[Row]["DocTitle"].ToString(), '\\' + txtTitle);
            DtTable.Rows[Row]["DocType"] = cobTypeText;
            DtTable.Rows[Row]["DocTitle"] = txtTitle;
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter.Update(DtTable);//用Update（）方法更新数据库
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
        /// 搜索数据库，返回ID列表
        /// </summary>
        /// <param name="key">关键词</param>
        /// <returns>ID列表</returns>
        public static List<string> search(string key)
        {
            if (string.IsNullOrEmpty(key)) return null;

            string filterExpression = "";
            filterExpression += "DocTitle LIKE '%" + key + "%'" + " or ";
            //filterExpression += "AddTime LIKE '%" + key + "%'" + " or ";
            //filterExpression += "ReleaseDate LIKE '%" + key + "%'" + " or ";
            filterExpression += "Provider LIKE '%" + key + "%'" + " or ";
            filterExpression += "Notes LIKE '%" + key + "%'" + " or ";
            if (filterExpression.EndsWith(" or "))
            {
                int indexOfAnd = filterExpression.LastIndexOf(" or ");
                filterExpression = filterExpression.Substring(0, indexOfAnd);
            }
            List<string> ls = new List<string>();
            foreach (DataRow drs in DtTable.Select(filterExpression))
            {
                ls.Add(drs["ID"].ToString());
            }
            return ls;
        }

    }
}
