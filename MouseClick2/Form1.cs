using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MouseClick2
{
    public partial class Form1 : Form
    {
        //设置鼠标进制数
        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        //声明线程及其运行、启动
        private Thread KeyPressListening = null;
        private bool isRunning = true;
        bool isStar = false;
        //声明自动化线程的运行、启动
        private Thread AutoMouseThread = null;
        private bool isAutoSart = false;
        private bool isAutoRunning = false;
        //键盘业务
        private bool isQ = false;
        private bool isW = false;
        private bool isE = false;
        private bool isR = false;
        private bool isA = false;
        private bool isS = false;
        private bool isD = false;
        private bool isL = false;
        private bool isP = false;
        //按键间隔时间
        int keySleepTimer = 500;
        int autoSleepTimer = 100;
        //声明数组
        int[,] allPosition = { };
        int[,] chifan = { { 1399, 346 }, { 1424, 421 }, { 1388, 496 }, { 1467, 619 }, { 1399, 691 }, { 1515, 770 }, { 1565, 847 }, { 1591, 924 }, { 1394, 988 } };
        int[,] shuijiao = { { 1398, 343 }, { 1425, 416 }, { 1763, 496 }, { 1426, 622 }, { 1494, 692 }, { 1776, 771 }, { 1563, 844 }, { 1586, 924 }, { 1395, 986 } };
        int[,] shangke1 = { { 1401, 345 }, { 1424, 416 }, { 1561, 494 }, { 1632, 494 }, { 1469, 615 }, { 1401, 693 }, { 1518, 770 }, { 1566, 847 }, { 1589, 924 }, { 1395, 987 } };
        int[,] shangke2 = { { 1399, 341 }, { 1424, 418 }, { 1563, 493 }, { 1632, 494 }, { 1469, 613 }, { 1489, 694 }, { 1387, 769 }, { 1565, 846 }, { 1590, 925 }, { 1402, 985 } };
        int[,] jiaoshirenshao = { { 1488, 342 }, { 1422, 418 }, { 1633, 490 }, { 1380, 617 }, { 1490, 692 }, { 1775, 769 }, { 1564, 847 }, { 1587, 924 }, { 1395, 991 } };
        int[,] wuren = { { 1557, 343 }, { 1401, 990 }, { 783, 815 } };
        int[,] xiayiye = { { 1397, 988 }, { 783, 815 } };

        public Form1()
        {
            InitializeComponent();
        }

        //指示WinApi动态链接库导入
        [DllImport("user32.dll")]
        private static extern short GetKeyState(int key);

        //声明WinApi属性的mouse方法
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        //声明WinApi属性的bool与c#bool属性的转化，并且声明鼠标定位方法
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(int X, int Y);


        public static void MoveAndClick(int x, int y)
        {
            // 移动鼠标到指定位置  
            SetCursorPos(x, y);

            // 模拟鼠标左键按下  
            mouse_event(MOUSEEVENTF_LEFTDOWN, x, y, 0, 0);
            // 模拟鼠标左键抬起  
            mouse_event(MOUSEEVENTF_LEFTUP, x, y, 0, 0);
        }


        //创建按键获取函数
        private bool IsKeyPressed(Keys key)
        {
            return (GetKeyState((int)key) & 0x8000) != 0;
        }


        //线程函数
        private void KeyListenedThread()
        {
            try
            {
                while (isRunning)
                {
                    //
                    if (IsKeyPressed(Keys.Q))
                    {
                        if (!isQ)
                        {
                            for (int i = 0; i < shuijiao.GetLength(0); i++)
                            {
                                int x = shuijiao[i, 0]; // 获取 X 坐标
                                int y = shuijiao[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isQ = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.W))
                    {
                        if (!isW)
                        {
                            for (int i = 0; i < chifan.GetLength(0); i++)
                            {
                                int x = chifan[i, 0]; // 获取 X 坐标
                                int y = chifan[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isW = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.E))
                    {
                        if (!isE)
                        {
                            for (int i = 0; i < shangke1.GetLength(0); i++)
                            {
                                int x = shangke1[i, 0]; // 获取 X 坐标
                                int y = shangke1[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isE = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.R))
                    {
                        if (!isR)
                        {
                            for (int i = 0; i < shangke2.GetLength(0); i++)
                            {
                                int x = shangke2[i, 0]; // 获取 X 坐标
                                int y = shangke2[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isR = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.A))
                    {
                        if (!isA)
                        {
                            for (int i = 0; i < jiaoshirenshao.GetLength(0); i++)
                            {
                                int x = jiaoshirenshao[i, 0]; // 获取 X 坐标
                                int y = jiaoshirenshao[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isA = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.S))
                    {
                        if (!isS)
                        {
                            for (int i = 0; i < wuren.GetLength(0); i++)
                            {
                                int x = wuren[i, 0]; // 获取 X 坐标
                                int y = wuren[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isS = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.D))
                    {
                        if (!isD)
                        {
                            for (int i = 0; i < xiayiye.GetLength(0); i++)
                            {
                                int x = xiayiye[i, 0]; // 获取 X 坐标
                                int y = xiayiye[i, 1]; // 获取 Y 坐标
                                MoveAndClick(x, y);
                            }
                        }
                        else
                        {
                            isD = false;
                        }
                        Thread.Sleep(keySleepTimer);
                    }
                    //
                    if (IsKeyPressed(Keys.L))
                    {
                        if (!isL)
                        {
                            if (!isAutoRunning)
                            {
                                button1.ForeColor = Color.Green;
                                Thread AutoMouseThread = new Thread(AutoThread);
                                AutoMouseThread.Start();
                                isAutoRunning = true;
                            }
                            else
                            {
                                button1.ForeColor = Color.Black;
                                isL = false;
                                isAutoRunning = false;
                                if (AutoMouseThread != null && AutoMouseThread.IsAlive)
                                {
                                    AutoMouseThread.Join();
                                }
                            }
                        }
                        else
                        {
                            button1.ForeColor = Color.Black;
                            isL = false;
                        }
                        Thread.Sleep(1000);
                    }
                    Application.DoEvents();
                }
            }
            catch (ThreadAbortException)
            {

            }

        }


        //自动化函数
        private void AutoThread()
        {
            try
            {
                while (isAutoRunning)
                {
                    for (int i = 0; i < wuren.GetLength(0); i++)
                    {
                        int x = wuren[i, 0]; // 获取 X 坐标
                        int y = wuren[i, 1]; // 获取 Y 坐标
                        MoveAndClick(x, y);
                    }
                    Thread.Sleep(autoSleepTimer);
                }
            }
            catch (ThreadAbortException)
            {

            }
        }

        //窗体加载函数
        private void Form1_Load(object sender, EventArgs e)
        {
            KeyPressListening = new Thread(KeyListenedThread);
            KeyPressListening.Start();

            this.FormClosing += Form1_FormClosing;
        }


        //窗体关闭函数
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            isAutoRunning = false;
            if (AutoMouseThread != null && AutoMouseThread.IsAlive)
            {
                AutoMouseThread.Join();
            }

            isRunning = false;
            if (KeyPressListening != null && KeyPressListening.IsAlive)
            {
                KeyPressListening.Join();
            }

        }


        //P按钮函数
        private void button1_Click(object sender, EventArgs e)
        {
            isStar = !isStar;
            if (isStar)
            {
                button1.ForeColor = Color.Red;
            }
            else
            {
                button1.ForeColor = Color.Green;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            label15.Text = autoSleepTimer.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;

            // 检查输入是否是有效数字，如果不是则清除文本框内容
            if (!string.IsNullOrEmpty(text) && !int.TryParse(text, out _))
            {
                textBox.Text = ""; // 清除文本框内容
            }
            else if (!string.IsNullOrEmpty(text))
            {
                int number;
                if (int.TryParse(text, out number))
                {
                    autoSleepTimer = number;
                }
            }
        }
    }
}
