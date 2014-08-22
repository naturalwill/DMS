using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DMS
{
    class FtpFileStruct
    {
        public List<type> typeList;

        public FtpFileStruct()
        {
            typeList = new List<type>();
        }

        public void addType(string dir)
        {
            typeList.Add(new type(dir));
        }
        public void addType(string[] dirs)
        {
            foreach (string dir in dirs)
            {
                typeList.Add(new type(dir));
            }
        }
        public int count
        {
            get
            {
                int cou = 0;
                for (int i = 0; i < typeList.Count; i++)
                {
                    cou += typeList[i].files.Count;
                }
                return cou;
            }
        }

    }

    //class type
    //{
    //    public string name;
    //    public List<string> files;
    //     public type(string dir)
    //    {
    //        files = new List<string>();
    //        name = dir;
    //    }
    //     public void addFile(string file)
    //     {
    //         files.Add(file);
    //     }
    //     public void addFile(string[] _files)
    //     {
    //         foreach (string file in _files)
    //         {
    //             files.Add(file);
    //         }
    //     }
    //}
    class type
    {
        public string name;
        public List<file> files;

        public type(string dir)
        {
            files = new List<file>();
            name = dir;
        }

        public void addFile(string file)
        {
            files.Add(new file(file));
        }
        public void addFile(string[] _files)
        {
            foreach (string file in _files)
            {
                files.Add(new file(file));
            }
        }
      

    }

    class file
    {
        public bool isNotRecord;
        public string name;

        public file(string fileName)
        {
            isNotRecord = true;
            name = fileName;
        }
    }
}
