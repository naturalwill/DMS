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


    }
    class type
    {
        public string name;
        public List<file> FileList;

        public type(string dir)
        {
            FileList = new List<file>();
            name = dir;
        }

        public void addFile(string file)
        {
            FileList.Add(new file(file));
        }
        public void addFile(string[] files)
        {
            foreach (string file in files)
            {
                FileList.Add(new file(file));
            }
        }
    }

    class file
    {
        public bool isRecord;
        public string name;

        public file(string fileName)
        {
            isRecord = false;
            name = fileName;
        }
    }
}
