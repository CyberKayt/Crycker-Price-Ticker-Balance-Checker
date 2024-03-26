namespace DaddyRecoveryBuilder
{
    using System;
    using System.Windows.Forms;
    using ExForms;
    using Helpers;

    public partial class DaddyFrm : Form
    {
        protected void Controls_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button.Equals(MouseButtons.Left))
            {
                ((Control)sender).Capture = false;
                var m = Message.Create(Handle, 0xa1, new IntPtr(0x2), IntPtr.Zero);
                WndProc(ref m);
            }
        }

        public DaddyFrm()
        {
            InitializeComponent();
            LogoText.MouseDown += Controls_MouseDown;
            UPanel.MouseDown += Controls_MouseDown;
        }

        private void ShowAssembly_Click(object sender, EventArgs e)
        {
            ControlActive.ControlVisible(MainFrm, new AssFrm());
        }

        private void ShowFunctions_Click(object sender, EventArgs e)
        {
            ControlActive.ControlVisible(MainFrm, new FuncFrm());
        }

        private void ShowBuild_Click(object sender, EventArgs e)
        {
            ControlActive.ControlVisible(MainFrm, new BuildFrm());
        }

        private void ExClose_Click(object sender, EventArgs e)
        {
            AnimationEx.Show(Handle, 500, Enums.AnimateWindowFlags.AW_VER_POSITIVE | Enums.AnimateWindowFlags.AW_HIDE);
            Application.Exit();
        }

        private void DaddyFrm_Load(object sender, EventArgs e)
        {
            AnimationEx.Show(Handle, 500, Enums.AnimateWindowFlags.AW_VER_POSITIVE | Enums.AnimateWindowFlags.AW_ACTIVATE);
        }
    }
}