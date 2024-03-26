using Crycker.Helper;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Crycker
{
    static class Program
    {                
        [STAThread]
        static void Main(string[] args)
        {
            foreach (var arg in args)
            {
                if (arg.ToLower() == "/log")
                    Logger.Enabled = true;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.ThreadException += new ThreadExceptionEventHandler(MyCommonExceptionHandlingMethod);

            Application.Run(new App());
        }
        private static void MyCommonExceptionHandlingMethod(object sender, ThreadExceptionEventArgs t)
        {
            Logger.Error($"Application Exception: {t.Exception.Message}");
            Logger.Error(t.Exception.ToString());
        }

    }
}