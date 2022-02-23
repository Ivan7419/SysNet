using System;
using System.Runtime.InteropServices;
using System.Text;
using static System.Console;

namespace SysNet_Console
{
    class Program
    {
        [DllImport("user32.dll")]
        public static extern int MessageBox(IntPtr hWnd, String text, String caption, int options);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //[DllImport("user32.dll")]
        //public static extern IntPtr SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, StringBuilder lParam);

        static void Main(string[] args)
        {
            //Task 1
            //int result = MessageBox(IntPtr.Zero, "Hello World", "Try", 0x0000004 | 0x00000030);                                                      

            //WriteLine(result);
            //ReadKey();

            //Task 2
            //Random random = new Random();
            //int tryCheck;
            //int result;
            //do
            //{
            //    tryCheck = random.Next(0, 100);
            //    result = MessageBox(IntPtr.Zero, "Is it " + tryCheck + "?", "Game", 0x0000004 | 0x00000030);

            //} while (result != 6);

            //Task 3
            //IntPtr fw = FindWindow("Notepad", "FindWindow — Блокнот");
            //if (fw != IntPtr.Zero)
            //{

            //    IntPtr res = SendMessage(fw, 0x0010, IntPtr.Zero, IntPtr.Zero);
            //    if(res == IntPtr.Zero) WriteLine("Окно закрыто");
            //}

            //Task 4
            IntPtr fw = FindWindow("Notepad", "FindWindow — Блокнот");
            if (fw != IntPtr.Zero)
            {
                StringBuilder sb = new StringBuilder();
                while (true)
                {
                    sb.Clear();
                    sb.Append("Time: ");
                    sb.Append(DateTime.Now.Hour);
                    sb.Append(":");
                    sb.Append(DateTime.Now.Minute);
                    sb.Append(":");
                    sb.Append(DateTime.Now.Second);
                    IntPtr res = SendMessage(fw, 0x000C, IntPtr.Zero, sb);
                    System.Threading.Thread.Sleep(1000);
                }
            }

            ReadKey();


        }
    }
}                        
    