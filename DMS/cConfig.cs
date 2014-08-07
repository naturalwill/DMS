using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace DMS
{
    class cConfig
    {
        #region 字段

        /// <summary>
        /// 是否默认工作目录
        /// 1为是；
        /// 0为否；
        /// </summary>
        public static char defaultPath = '1';
        /// <summary>
        /// 工作目录
        /// </summary>
        public static string strWorkPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DMS";

        /// <summary>
        /// FTP设置
        /// </summary>
        public static string FTP_IP = "", FTP_user = "", FTP_password = "";

        /// <summary>
        /// 每页的条目数量
        /// </summary>
        public static int paginalItems = 10;

        #endregion


        #region 方法
        /// <summary>
        /// 保存配置
        /// </summary>
        public static void SaveConfig()
        {
            XElement xe = new XElement("Config",
                new XElement("defaultPath", defaultPath.ToString()),
                new XElement("WorkPath", strWorkPath),
                new XElement("FTP_IP", FTP_IP),
                new XElement("FTP_user", FTP_user),
                new XElement("FTP_password", FTP_password),
                new XElement("paginalItems", paginalItems)
                );
            xe.Save(".\\Config.xml");
            xe.RemoveAll();
        }

        /// <summary>
        /// 读取配置
        /// </summary>
        public static void ReadConfig()
        {
            if (File.Exists(".\\Config.xml"))
            {
                XElement xe = XElement.Load(".\\Config.xml");

                if (xe.Element("defaultPath").Value != "0")
                {
                    strWorkPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\DMS";
                }
                else
                {
                    defaultPath = '0';
                    strWorkPath = xe.Element("WorkPath").Value;
                }
                FTP_IP = xe.Element("FTP_IP").Value;
                FTP_user = xe.Element("FTP_user").Value;
                FTP_password = xe.Element("FTP_password").Value;
                paginalItems = Convert.ToInt32(xe.Element("paginalItems").Value);

                xe.RemoveAll();
            }
            else
            {
                SaveConfig();
            }
        }

        #endregion
    }
}
