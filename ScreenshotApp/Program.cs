using System;
using System.Windows.Forms;

namespace ScreenshotApp
{
    public static class Program
    {
        public static ScreenshotClass sc = new ScreenshotClass();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            InterceptKeys.StartIntercept();
        }
    }
}
