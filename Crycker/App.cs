using System;
using System.Windows.Forms;

using Crycker.Controls;
using Crycker.Data;
using Crycker.Helper;
using Crycker.Types;
using Crycker.Settings;

namespace Crycker
{
    class App : ApplicationContext
    {
        private NotifyIcon TrayIcon;
        private ContextMenuControl contextMenuControl = new ContextMenuControl();
        private TickerController tickerController;

        private UserSettings settings;
        
        private DateTime lastUpdateCheck;

        public App()
        {
            Logger.Info("App starting...");

            settings = UserSettings.Load();

            tickerController = new TickerController(settings.Provider, settings.Coin, settings.Currency, settings.RefreshInterval);
            tickerController.DataUpdated += DataUpdated;

            InitializeComponent(settings);
        }

        private async void DataUpdated(object sender, TickerEventArgs e)
        {
            TaskbarIconHelper.SetPrice(e.LastPrice, e.PreviousPrice, e.Coin, e.Currency, e.Provider, e.LastUpdated);

            // when changing providers, coin and currency might change and we need to reflect that in UI
            contextMenuControl.SetCoin(e.Coin);
            contextMenuControl.SetCurrency(e.Currency);

            await CheckForUpdates();
        }

        private async System.Threading.Tasks.Task CheckForUpdates()
        {
            if (!settings.CheckForUpdates) return;

            if (lastUpdateCheck != null && DateTime.Now.Subtract(lastUpdateCheck).Days > 1)
            {
                Logger.Info("Checking for updates.");
                try
                {
                    var updateCheck = new UpdateCheckHelper("davidvidmar", "Crycker");
                    var updateAvailable = await updateCheck.UpdateAvailable();

                    if (!String.IsNullOrEmpty(updateAvailable))
                    {
                        Logger.Info($"Update is available: {updateAvailable}");
                        contextMenuControl.SetNewVersionAvailable(updateAvailable, updateCheck.LatestVersionUrl);
                    }
                    lastUpdateCheck = DateTime.Now;
                }
                catch (Exception ex)
                {
                    Logger.Error($"Update check failed: {ex.Message}");
                }
            }
        }

        private void InitializeComponent(UserSettings settings)
        {
            Application.ApplicationExit += Application_ApplicationExit;

            // init Context Menu
            contextMenuControl.SetProvider(settings.Provider);
            contextMenuControl.SetCoin(settings.Coin);
            contextMenuControl.SetCurrency(settings.Currency);
            contextMenuControl.SetValidCurrencies(tickerController.SupportedCurrencies);
            contextMenuControl.SetValidCoins(tickerController.SupportedCoins);
            contextMenuControl.SetRefreshInterval(settings.RefreshInterval);
            contextMenuControl.SetPercentageNotification(settings.PercentageNotification);
            contextMenuControl.SetDarkMode(settings.DarkMode);
            contextMenuControl.SetAutorun(AutoRunHelper.Get());
            contextMenuControl.SetHighlight(settings.Highlight);
            contextMenuControl.SetCurrentVersion();

            // init Event fired from Context Menu
            contextMenuControl.OpenUrlClicked += ContextMenuControl_OpenUrlClicked;
            contextMenuControl.NewVersionAvailableClicked += ContextMenuControl_NewVersionAvailableClicked;
            contextMenuControl.ProviderChanged += ContextMenuControl_ProviderChanged;
            contextMenuControl.CoinChanged += ContextMenuControl_CoinChanged;
            contextMenuControl.CurrencyChanged += ContextMenuControl_CurrencyChanged;
            contextMenuControl.RefreshIntervalChanged += ContextMenuControl_RefreshIntervalChanged;
            contextMenuControl.PercentageNotificationChanged += ContextMenuControl_PercentageNotificationChanged;
            contextMenuControl.HighlightChanged += ContextMenuControl_HighlightChanged;
            contextMenuControl.DarkModeChanged += ContextMenuControl_DarkModeChanged;
            contextMenuControl.AutorunChanged += ContextMenuControl_AutorunChanged;
            contextMenuControl.ExitClicked += ContextMenuControl_ExitClicked;

            // Init Tray Icon
            TrayIcon = new NotifyIcon
            {
                ContextMenuStrip = contextMenuControl.ContextMenuStrip
            };
            
            TaskbarIconHelper.notifyIcon = TrayIcon;
            TaskbarIconHelper.DarkMode = settings.DarkMode;
            TaskbarIconHelper.Highlight = settings.Highlight;

            TrayIcon.Click += TrayIcon_Click;
            TrayIcon.DoubleClick += TrayIcon_DoubleClick;

            TrayIcon.Visible = true;
        }


        private void ContextMenuControl_OpenUrlClicked(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(tickerController.TickerUrl);
        }

        private void ContextMenuControl_NewVersionAvailableClicked(object sender, StringEventArgs e)
        {
            System.Diagnostics.Process.Start(e.Value);
        }

        private void ContextMenuControl_ProviderChanged(object sender, StringEventArgs e)
        {
            tickerController.SetProvider(e.Value);

            contextMenuControl.SetValidCurrencies(tickerController.SupportedCurrencies);
            contextMenuControl.SetValidCoins(tickerController.SupportedCoins);
            
            tickerController.UpdateData();

            var settings = UserSettings.Load();
            settings.Provider = e.Value;
            settings.Save();
        }

        private void ContextMenuControl_CoinChanged(object sender, StringEventArgs e)
        {
            tickerController.SetCoin(e.Value);
            tickerController.UpdateData();

            var settings = UserSettings.Load();
            settings.Coin = e.Value;
            settings.Save();
        }

        private void ContextMenuControl_CurrencyChanged(object sender, StringEventArgs e)
        {
            tickerController.SetCurrency(e.Value);
            tickerController.UpdateData();

            var settings = UserSettings.Load();
            settings.Currency = e.Value;
            settings.Save();
        }

        private void ContextMenuControl_RefreshIntervalChanged(object sender, IntEventArgs e)
        {
            tickerController.SetRefreshInterval(e.Value);
            tickerController.UpdateData();

            var settings = UserSettings.Load();
            settings.RefreshInterval = e.Value;
            settings.Save();
        }

        private void ContextMenuControl_PercentageNotificationChanged(object sender, IntEventArgs e)
        {
            var settings = UserSettings.Load();
            settings.PercentageNotification= e.Value;
            settings.Save();
        }

        private void ContextMenuControl_HighlightChanged(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;

            var settings = UserSettings.Load();
            settings.Highlight = !settings.Highlight;
            settings.Save();

            contextMenuControl.SetHighlight(settings.Highlight);
            TaskbarIconHelper.Highlight = settings.Highlight;

            tickerController.UpdateData();
        }

        private void ContextMenuControl_DarkModeChanged(object sender, EventArgs e)
        {
            var settings = UserSettings.Load();
            settings.DarkMode = !settings.DarkMode;
            settings.Save();
            
            contextMenuControl.SetDarkMode(settings.DarkMode);
            TaskbarIconHelper.DarkMode = settings.DarkMode;

            tickerController.UpdateData();
        }

        private void ContextMenuControl_AutorunChanged(object sender, EventArgs e)
        {
            var menu = sender as ToolStripMenuItem;
            if (AutoRunHelper.Get())
            {
                AutoRunHelper.Clear();
                menu.Checked = false;
            }
            else
            {
                AutoRunHelper.Set();
                menu.Checked = true;
            }
        }

        private void ContextMenuControl_ExitClicked(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you really want to exit?", "Crycker",
                MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void Application_ApplicationExit(object sender, EventArgs e)
        {            
            TrayIcon.Visible = false;
        }

        private void TrayIcon_Click(object sender, EventArgs e)
        {
            // TODO - show chart
        }

        private void TrayIcon_DoubleClick(object sender, EventArgs e)
        {
            ContextMenuControl_OpenUrlClicked(sender, e);
        }

    }

}