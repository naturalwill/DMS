using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing.Imaging;

namespace DMS
{
    public partial class frmScan : Form
    {
        public frmScan()
        {
            InitializeComponent();
        }
        #region 字段
        //常量
        const short WM_CAP = 1024;
        const int WM_CAP_DRIVER_CONNECT = WM_CAP + 10;
        const int WM_CAP_DRIVER_DISCONNECT = WM_CAP + 11;
        const int WM_CAP_EDIT_COPY = WM_CAP + 30;
        const int WM_CAP_SET_PREVIEW = WM_CAP + 50;
        const int WM_CAP_SET_PREVIEWRATE = WM_CAP + 52;
        const int WM_CAP_SET_SCALE = WM_CAP + 53;
        const int WS_CHILD = 1073741824;
        const int WS_VISIBLE = 268435456;
        const short SWP_NOMOVE = 2;
        const short SWP_NOSIZE = 1;
        const short SWP_NOZORDER = 4;
        const short HWND_BOTTOM = 1;
        int iDevice = 0;//it's 0 generally.
        int hHwnd;
        Bitmap bit = new Bitmap(313, 266);
        Image img2;
        string photopath;
        #endregion
        #region 调用API
        //视频API调用。
        [DllImport("user32", EntryPoint = "SendMessageA")]
        static extern int SendMessage(int hwnd, int wMsg, int wParam, [MarshalAs(UnmanagedType.AsAny)]
            object lParam);
        [DllImport("user32", EntryPoint = "SetWindowPos")]
        static extern int SetWindowPos(int hwnd, int hWndInsertAfter, int x, int y, int cx, int cy, int wFlags);
        [DllImport("user32")]
        static extern bool DestroyWindow(int hndw);
        [DllImport("avicap32.dll")]
        static extern int capCreateCaptureWindowA(string lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int nID);
        [DllImport("avicap32.dll")]
        static extern bool capGetDriverDescriptionA(short wDriver, string lpszName, int cbName, string lpszVer, int cbVer);
        #endregion
        //初始化摄像头
        private void start()
        {
            //在picturebox上打开预览窗口。
            hHwnd = capCreateCaptureWindowA(pictureBox1.Handle.ToString(), (WS_CHILD | WS_VISIBLE), 0, 0, pictureBox1.Width, pictureBox1.Height, pictureBox1.Handle.ToInt32(), 0);
            //连接到设备。
            if (SendMessage(hHwnd, WM_CAP_DRIVER_CONNECT, iDevice, 0) == 1)
            {
                //设置预览的规模
                SendMessage(hHwnd, WM_CAP_SET_SCALE, 1, 0);
                //设置预览每毫秒的比率
                SendMessage(hHwnd, WM_CAP_SET_PREVIEWRATE, 66, 0);
                //开始预览来自摄像头的图片
                SendMessage(hHwnd, WM_CAP_SET_PREVIEW, 1, 0);
                //调整在picturebox预览窗口的大小。
                SetWindowPos(hHwnd, HWND_BOTTOM, 12, 12, pictureBox1.Width, pictureBox1.Height, (SWP_NOMOVE | SWP_NOZORDER));
            }
            else
            {
                //错误连接时断开
                DestroyWindow(hHwnd);
            }
        }
        private void close()
        {
            //断开设备
            SendMessage(hHwnd, WM_CAP_DRIVER_DISCONNECT, iDevice, 0);
            //关闭预览
            DestroyWindow(hHwnd);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            iDevice = 0;
            start();
        }

     
        //拍照
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SendMessage(hHwnd, 0x41e, 0, 0);
                close();
                //把图片显示在picturebox上
                IDataObject obj = Clipboard.GetDataObject();
                Image photo = null;
                if (obj.GetDataPresent(typeof(Bitmap)))
                {
                    photo = (Image)obj.GetData(typeof(Bitmap));
                    Graphics g = Graphics.FromImage(bit);
                    g.DrawImage(photo, new Rectangle(0, 0, bit.Width, bit.Height), new Rectangle(0, 0, photo.Width, photo.Height), GraphicsUnit.Pixel);
                    pictureBox1.Image = bit;
                    img2 = pictureBox1.Image;
                    photo.Dispose();
                    g.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //使用两个进程，进程一是本地缓存，进程二是储存在ftp服务器上。
        bool singal = false;
        void thead_1()
        {

            /*储存到本地磁盘。*/
            Directory.CreateDirectory(cConfig.strWorkPath + "\\扫描文档");
            if (Directory.Exists(cConfig.strWorkPath + "\\扫描文档"))
            {
                if (MessageBox.Show("确定要储存照片吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    pictureBox1.Image.Save(cConfig.strWorkPath + "\\扫描文档\\" + textBox1.Text + ".jpg", ImageFormat.Jpeg);
                    photopath = cConfig.strWorkPath + "\\扫描文档\\" + textBox1.Text + ".jpg";
                }
            }
            else Directory.CreateDirectory(cConfig.strWorkPath + "\\扫描文档");
            singal = true;
        }
        void thead_2()
        {
            while (singal)
            {
                FTPHelper FTP = new FTPHelper("222.16.97.150", "", "code", "123");
                FTP.Upload(photopath);
                break;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            thead_1();
            thead_2();
        }

        private void frmScan_Load(object sender, EventArgs e)
        {
            iDevice = 0;
            start();
        }

    }
}
