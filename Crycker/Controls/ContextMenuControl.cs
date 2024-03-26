using Crycker.Helper;
using Crycker.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Crycker.Controls
{
    public partial class ContextMenuControl : UserControl
    {
        public ContextMenuControl()
        {
            InitializeComponent();
        }

        public event EventHandler OpenUrlClicked = delegate { };
        public event EventHandler<StringEventArgs> NewVersionAvailableClicked = delegate { };

        public event EventHandler<StringEventArgs> ProviderChanged = delegate { };
        public event EventHandler<StringEventArgs> CoinChanged = delegate { };
        public event EventHandler<StringEventArgs> CurrencyChanged = delegate { };
        
        public event EventHandler<IntEventArgs> RefreshIntervalChanged = delegate { };
        public event EventHandler<IntEventArgs> PercentageNotificationChanged = delegate { };


        public event EventHandler AutorunChanged = delegate { };
        public event EventHandler HighlightChanged = delegate { };
        public event EventHandler DarkModeChanged = delegate { };
        public event EventHandler ExitClicked = delegate { };


        private void newVersionIsAvailableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            Logger.Info($"New version available clicked ({menu.Tag})");            
            NewVersionAvailableClicked(sender, new StringEventArgs((string)menu.Tag));
        }

        private void RefreshIntervalClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            var value = Convert.ToInt32(menu.Tag);
            Logger.Info($"Refresh Interval menu clicked -> {value}");
            
            RefreshIntervalChanged(sender, new IntEventArgs(value));
        }

        private void PercentageNotificationClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            var value = Convert.ToInt32(menu.Tag);
            Logger.Info($"Percentage notification menu clicked -> {value}");

            PercentageNotificationChanged(sender, new IntEventArgs(value));
        }

        private void CoinClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;            
            UncheckOtherToolStripMenuItems(menu);

            string value = (string)menu.Tag;
            Logger.Info($"Coin menu clicked -> {value}");

            CoinChanged(sender, new StringEventArgs(value));
        }

        private void CurrencyClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;            

            UncheckOtherToolStripMenuItems(menu);

            string value = (string)menu.Tag;
            Logger.Info($"Currency menu clicked -> {value}");

            CurrencyChanged(sender, new StringEventArgs(value));
        }

        private void ProviderClick(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            UncheckOtherToolStripMenuItems(menu);

            string value = (string)menu.Tag;
            Logger.Info($"Provider menu clicked -> {value}");

            ProviderChanged(sender, new StringEventArgs(value));
        }

        internal void SetCurrentVersion()
        {
            var updateCheck = new UpdateCheckHelper("davidvidmar", "Crycker");
            var version = updateCheck.GetCurrentVersion();
            var versionString = 
                $"v{version.Major}.{version.Minor}" + 
                (version.Build > 0 ? "." + version.Build + (version.Revision > 0 ? "." + version.Revision : "") : "");
            versionToolStripMenuItem.Text = $"Crycker {versionString}";
        }

        private void AutorunClick(object sender, EventArgs e)
        {
            Logger.Info($"Autorun menu clicked");
            AutorunChanged(sender, e);
        }

        private void colorHighlightIconToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Info($"Color highlight menu clicked");
            HighlightChanged(sender, e);
        }

        private void darkModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Info($"Dark mode menu clicked");
            DarkModeChanged(sender, e);
        }

        private void ExitClick(object sender, EventArgs e)
        {
            Logger.Info($"Exit menu clicked");
            ExitClicked(sender, e);
        }

        private void clickToOpenWebPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Logger.Info($"Open URL menu clicked");
            OpenUrlClicked(sender, e);
        }

        public void SetNewVersionAvailable(string version, string url)
        {
            Logger.Info($"New version {version} is available at {url}");
            newVersionIsAvailableToolStripMenuItem.Text = $"Hey, lucky you! New version is available: v{version}";
            newVersionIsAvailableToolStripMenuItem.Tag = url;
            newVersionIsAvailableToolStripMenuItem.Visible = true;
        }

        public void SetProvider(string value)
        {
            SelectDropDownItem(providerToolStripMenuItem, value);
        }

        internal void SetValidCoins(string[] supportedCoins)
        {
            var list = new List<string>(supportedCoins);
            foreach (ToolStripMenuItem item in coinToolStripMenuItem.DropDownItems)
            {
                item.Visible = list.Contains(item.Tag);
            }
        }

        internal void SetValidCurrencies(string[] supportedCurrencies)
        {
            var list = new List<string>(supportedCurrencies);
            foreach (ToolStripMenuItem item in currencyToolStripMenuItem.DropDownItems)
            {
                item.Visible = list.Contains(item.Tag);
            }
        }

        public void SetCoin(string value)
        {
            SelectDropDownItem(coinToolStripMenuItem, value);
        }

        public void SetCurrency(string value)
        {
            SelectDropDownItem(currencyToolStripMenuItem, value);
        }

        public void SetRefreshInterval(int value)
        {
            SelectDropDownItem(refreshIntervalToolStripMenuItem, value.ToString());
        }

        public void SetPercentageNotification(int value)
        {
            SelectDropDownItem(priceChangeNotificationToolStripMenuItem, value.ToString());
        }

        internal void SetHighlight(bool value)
        {
            colorHighlightIconToolStripMenuItem.Checked = value;
        }

        internal void SetDarkMode(bool value)
        {
            darkModeToolStripMenuItem.Checked = value;
        }

        internal void SetAutorun(bool value)
        {
            autoRunToolStripMenuItem.Checked = value;
        }

        private void SelectDropDownItem(ToolStripMenuItem toolStripMenuItem, string tagValue)
        {
            foreach (var item in toolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>())
            {
                item.Checked = item.Tag?.ToString() == tagValue;
            }            
        }       

        private void UncheckOtherToolStripMenuItems(ToolStripMenuItem selectedMenuItem)
        {
            selectedMenuItem.Checked = true;
            // Select the other MenuItens from the ParentMenu(OwnerItens) and unchecked this,
            // The current Linq Expression verify if the item is a real ToolStripMenuItem
            // and if the item is a another ToolStripMenuItem to uncheck this.  
            // It only looks for items inside the same separator zone.
            ToolStripSeparator separator1 = null, separator2 = null;
            bool itemFound = false;
            foreach (ToolStripItem item in selectedMenuItem.Owner.Items)
                if (item is ToolStripSeparator sep)
                    if (itemFound)
                    {
                        separator2 = sep;
                        break;
                    }
                    else
                        separator1 = sep;
                else if (item == selectedMenuItem)
                    itemFound = true;

            var e = selectedMenuItem.Owner.Items.GetEnumerator();
            while (e.MoveNext())
                if (separator1 == null || separator1 == e.Current && e.MoveNext())
                    do
                    {
                        if (e.Current == separator2)
                            return;

                        if(e.Current != selectedMenuItem)
                          ((ToolStripMenuItem)e.Current).Checked = false;
                    } while (e.MoveNext());               
        }

        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://vidmar.net/crycker");
        }
    }
}
