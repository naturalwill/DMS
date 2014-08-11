using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;

namespace ZCommon
{
    public class cAccess
    {
        static string connString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Environment.CurrentDirectory + @"\DMS.mdb";

        static OleDbConnection conn = new OleDbConnection(connString);
        static OleDbCommand cmd;
        public static OleDbDataAdapter DtAdapter;
        static OleDbCommandBuilder CoBuilder;

        public static DataTable DtTable;


        /// <summary>
        /// 加载数据库
        /// </summary>
        public static void load()
        {
            //                if (!(File.Exists(Environment.CurrentDirectory + @"\DMS.mdb")))
            //                {
            //                    ADOX.CatalogClass cat = new ADOX.CatalogClass();
            //                    cat.Create(connString);
            //                    System.Diagnostics.Debug.Write("Database Created Successfully");
            //                    cat = null;
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
            //                }
            if (conn.State != ConnectionState.Open)
                conn.Open();
            DtAdapter = new OleDbDataAdapter("Select * From OfficialDocument", conn);
            CoBuilder = new OleDbCommandBuilder(DtAdapter);
            DtTable = new DataTable();
            DtAdapter.Fill(DtTable);
            conn.Close();
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
    }
}
