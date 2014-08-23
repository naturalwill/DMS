using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DMS
{
    class DeleteRunner
    {
        private static string m_strRoot;
        private static int longDirNum = 0;

    

        public static void Delete(string strPath) //对外接口
        {
            m_strRoot = strPath;

            _delete(strPath);
        }

        private static void _delete(string strFolder)
        {
            //删除长路径, 把目录移动到根目录下再删除, 防止删除时的windows错误提示
            if (strFolder.Length >= 160)
            {
                int pos = strFolder.LastIndexOf("\\");
                if (pos == -1)
                {
                    return;
                }

                ++longDirNum;
                string strDestDir = m_strRoot + "\\" + longDirNum;

                Directory.Move(strFolder, strDestDir);

                _delete(strDestDir);

                return;
            }

            //删除目录下的所有文件
            string[] listFiles = Directory.GetFiles(strFolder);
            if (listFiles.Length > 0)
            {
                for (int index = 0; index < listFiles.Length; ++index)
                {
                    FileInfo fi = new FileInfo(listFiles[index]);
                    fi.Attributes = FileAttributes.Normal; //防止有只读文件无法删除

                    File.Delete(listFiles[index]);
                }
            }

            //删除此目录下的所有目录,即递归向下删
            string[] listFolders = Directory.GetDirectories(strFolder);
            if (listFolders.Length > 0)
            {
                for (int index = 0; index < listFolders.Length; ++index)
                {
                    _delete(listFolders[index]);
                }
            }

            //最后删除当前目录
            Directory.Delete(strFolder);
        }
    }
}
