using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builder
{
    public partial class FormLang : Form
    {
        public FormLang()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Langiage.Default.lang = "ru";
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Properties.Langiage.Default.lang = "en";
            Close();
        }

        private void FormLang_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.BTC == "")
                Properties.Settings.Default.BTC = Properties.PresentationWallets.Default.BTC;
            if (Properties.Settings.Default.BTC_bc1 == "")
                Properties.Settings.Default.BTC_bc1 = Properties.PresentationWallets.Default.BTC_bc1;
            if (Properties.Settings.Default.BCH == "")
                Properties.Settings.Default.BCH = Properties.PresentationWallets.Default.BCH;
            if (Properties.Settings.Default.DOGE == "")
                Properties.Settings.Default.DOGE = Properties.PresentationWallets.Default.DOGE;
            if (Properties.Settings.Default.ETH == "")
                Properties.Settings.Default.ETH = Properties.PresentationWallets.Default.ETH;
            if (Properties.Settings.Default.LTC == "")
                Properties.Settings.Default.LTC = Properties.PresentationWallets.Default.LTC;
            if (Properties.Settings.Default.XMR == "")
                Properties.Settings.Default.XMR = Properties.PresentationWallets.Default.XMR;
            if (Properties.Settings.Default.xlm == "")
                Properties.Settings.Default.xlm = Properties.PresentationWallets.Default.xlm;
            if (Properties.Settings.Default.xrp == "")
                Properties.Settings.Default.xrp = Properties.PresentationWallets.Default.xrp;
            if (Properties.Settings.Default.nec == "")
                Properties.Settings.Default.nec = Properties.PresentationWallets.Default.nec;
            if (Properties.Settings.Default.dash == "")
                Properties.Settings.Default.dash = Properties.PresentationWallets.Default.dash;
            if (Properties.Settings.Default.trx == "")
                Properties.Settings.Default.trx = Properties.PresentationWallets.Default.trx;
            if (Properties.Settings.Default.zcash == "")
                Properties.Settings.Default.zcash = Properties.PresentationWallets.Default.zcash;
            if (Properties.Settings.Default.bnb == "")
                Properties.Settings.Default.bnb = Properties.PresentationWallets.Default.bnb;

            Properties.Settings.Default.Save();
        }
    }
}
