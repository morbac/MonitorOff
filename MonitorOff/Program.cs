using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices;

namespace MonitorOff
{
    internal class Program
    {
        const int SC_MONITORPOWER = 0xF170;
        const int WM_SYSCOMMAND = 0x0112;
        const int MONITOR_ON = -1;
        const int MONITOR_OFF = 2;
        const int MONITOR_STANBY = 1;

        int HWND_BROADCAST = 0xffff;
        //the message is sent to all
        //top-level windows in the system

        int HWND_TOPMOST = -1;
        //the message is sent to one
        //top-level window in the system

        int HWND_TOP = 0; //
        int HWND_BOTTOM = 1; //limited use
        int HWND_NOTOPMOST = -2; //
        [DllImport("msvcrt.dll")]
        public static extern int puts(string c);
        [DllImport("msvcrt.dll")]
        internal static extern int _flushall();

        static void Main(string[] args)
        {

            Program pugrama = new Program();
            pugrama.prova1();
            //


        }
        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg,
        IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        //Or
        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindowEx(IntPtr hwndParent,
        IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        [DllImport("user32.dll")]
        static extern IntPtr PostMessage(int hWnd, int msg, int wParam, int lParam);
        [DllImport("kernel32")]
        static extern IntPtr GetConsoleWindow();

        public void prova1()
        {
            //SendMessage(ValidHWND, WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
            System.IntPtr intTemp = GetConsoleWindow();
            PostMessage(intTemp.ToInt32(), WM_SYSCOMMAND, SC_MONITORPOWER, MONITOR_OFF);
        }
    }
}
