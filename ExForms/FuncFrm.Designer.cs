namespace DaddyRecoveryBuilder.ExForms
{
    partial class FuncFrm
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.OutBuildBox = new System.Windows.Forms.TextBox();
            this.BuildText = new System.Windows.Forms.Label();
            this.ArchiveTagBox = new System.Windows.Forms.TextBox();
            this.TagText = new System.Windows.Forms.Label();
            this.HostBox = new System.Windows.Forms.TextBox();
            this.LinkText = new System.Windows.Forms.Label();
            this.MessageData = new System.Windows.Forms.Label();
            this.MessageConnect = new System.Windows.Forms.Label();
            this.LoggerBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.DeactiveBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.ConnectHost = new DaddyRecoveryBuilder.Design.NewButton();
            this.OutFormsBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.OutConsoleBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.StringEncBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.AntiDumpBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.CountryCISBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.VirtualBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.ToDicData = new DaddyRecoveryBuilder.Design.NewButton();
            this.SuspendLayout();
            // 
            // OutBuildBox
            // 
            this.OutBuildBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.OutBuildBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OutBuildBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.OutBuildBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.OutBuildBox.Location = new System.Drawing.Point(222, 223);
            this.OutBuildBox.MaxLength = 20;
            this.OutBuildBox.Name = "OutBuildBox";
            this.OutBuildBox.Size = new System.Drawing.Size(379, 20);
            this.OutBuildBox.TabIndex = 65;
            this.OutBuildBox.TabStop = false;
            this.OutBuildBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OutBuildBox_KeyPress);
            // 
            // BuildText
            // 
            this.BuildText.AutoSize = true;
            this.BuildText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.BuildText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.BuildText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.BuildText.Location = new System.Drawing.Point(88, 226);
            this.BuildText.Name = "BuildText";
            this.BuildText.Size = new System.Drawing.Size(100, 15);
            this.BuildText.TabIndex = 64;
            this.BuildText.Text = "Output file name:";
            // 
            // ArchiveTagBox
            // 
            this.ArchiveTagBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.ArchiveTagBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ArchiveTagBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.ArchiveTagBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ArchiveTagBox.Location = new System.Drawing.Point(222, 195);
            this.ArchiveTagBox.MaxLength = 10;
            this.ArchiveTagBox.Name = "ArchiveTagBox";
            this.ArchiveTagBox.Size = new System.Drawing.Size(379, 20);
            this.ArchiveTagBox.TabIndex = 63;
            this.ArchiveTagBox.TabStop = false;
            // 
            // TagText
            // 
            this.TagText.AutoSize = true;
            this.TagText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.TagText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TagText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.TagText.Location = new System.Drawing.Point(88, 195);
            this.TagText.Name = "TagText";
            this.TagText.Size = new System.Drawing.Size(71, 15);
            this.TagText.TabIndex = 62;
            this.TagText.Text = "Archive tag:";
            // 
            // HostBox
            // 
            this.HostBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.HostBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HostBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.HostBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.HostBox.Location = new System.Drawing.Point(222, 166);
            this.HostBox.MaxLength = 50;
            this.HostBox.Name = "HostBox";
            this.HostBox.Size = new System.Drawing.Size(379, 20);
            this.HostBox.TabIndex = 61;
            this.HostBox.TabStop = false;
            this.HostBox.TextChanged += new System.EventHandler(this.HostBox_TextChanged);
            // 
            // LinkText
            // 
            this.LinkText.AutoSize = true;
            this.LinkText.Font = new System.Drawing.Font("Lucida Sans Unicode", 8.25F);
            this.LinkText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LinkText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.LinkText.Location = new System.Drawing.Point(88, 167);
            this.LinkText.Name = "LinkText";
            this.LinkText.Size = new System.Drawing.Size(118, 15);
            this.LinkText.TabIndex = 60;
            this.LinkText.Text = "Link to your hosting:";
            // 
            // MessageData
            // 
            this.MessageData.AutoSize = true;
            this.MessageData.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageData.ForeColor = System.Drawing.Color.Firebrick;
            this.MessageData.Location = new System.Drawing.Point(363, 282);
            this.MessageData.Name = "MessageData";
            this.MessageData.Size = new System.Drawing.Size(0, 13);
            this.MessageData.TabIndex = 109;
            // 
            // MessageConnect
            // 
            this.MessageConnect.AutoSize = true;
            this.MessageConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MessageConnect.ForeColor = System.Drawing.Color.ForestGreen;
            this.MessageConnect.Location = new System.Drawing.Point(620, 189);
            this.MessageConnect.Name = "MessageConnect";
            this.MessageConnect.Size = new System.Drawing.Size(0, 13);
            this.MessageConnect.TabIndex = 113;
            // 
            // LoggerBox
            // 
            this.LoggerBox.AutoSize = true;
            this.LoggerBox.BackColor = System.Drawing.Color.Transparent;
            this.LoggerBox.Location = new System.Drawing.Point(434, 83);
            this.LoggerBox.Name = "LoggerBox";
            this.LoggerBox.Size = new System.Drawing.Size(92, 20);
            this.LoggerBox.TabIndex = 112;
            this.LoggerBox.TabStop = false;
            this.LoggerBox.Text = "Active Logger";
            this.LoggerBox.UseVisualStyleBackColor = false;
            // 
            // DeactiveBox
            // 
            this.DeactiveBox.AutoSize = true;
            this.DeactiveBox.BackColor = System.Drawing.Color.Transparent;
            this.DeactiveBox.Location = new System.Drawing.Point(434, 57);
            this.DeactiveBox.Name = "DeactiveBox";
            this.DeactiveBox.Size = new System.Drawing.Size(107, 20);
            this.DeactiveBox.TabIndex = 111;
            this.DeactiveBox.TabStop = false;
            this.DeactiveBox.Text = "Self Delete Build";
            this.DeactiveBox.UseVisualStyleBackColor = false;
            // 
            // ConnectHost
            // 
            this.ConnectHost.BackColor = System.Drawing.Color.Transparent;
            this.ConnectHost.BGColor = "Firebrick";
            this.ConnectHost.FontColor = "#ffffff";
            this.ConnectHost.Location = new System.Drawing.Point(606, 166);
            this.ConnectHost.Name = "ConnectHost";
            this.ConnectHost.Size = new System.Drawing.Size(135, 20);
            this.ConnectHost.TabIndex = 110;
            this.ConnectHost.TabStop = false;
            this.ConnectHost.Text = "Check connect";
            this.ConnectHost.Visible = false;
            this.ConnectHost.Click += new System.EventHandler(this.ConnectHost_Click);
            // 
            // OutFormsBox
            // 
            this.OutFormsBox.AutoSize = true;
            this.OutFormsBox.BackColor = System.Drawing.Color.Transparent;
            this.OutFormsBox.Location = new System.Drawing.Point(434, 31);
            this.OutFormsBox.Name = "OutFormsBox";
            this.OutFormsBox.Size = new System.Drawing.Size(167, 20);
            this.OutFormsBox.TabIndex = 72;
            this.OutFormsBox.TabStop = false;
            this.OutFormsBox.Text = "Output Winforms Application";
            this.OutFormsBox.UseVisualStyleBackColor = false;
            this.OutFormsBox.CheckedChanged += new System.EventHandler(this.OutFormsBox_CheckedChanged);
            // 
            // OutConsoleBox
            // 
            this.OutConsoleBox.AutoSize = true;
            this.OutConsoleBox.BackColor = System.Drawing.Color.Transparent;
            this.OutConsoleBox.Location = new System.Drawing.Point(434, 5);
            this.OutConsoleBox.Name = "OutConsoleBox";
            this.OutConsoleBox.Size = new System.Drawing.Size(160, 20);
            this.OutConsoleBox.TabIndex = 71;
            this.OutConsoleBox.TabStop = false;
            this.OutConsoleBox.Text = "Output Console Application";
            this.OutConsoleBox.UseVisualStyleBackColor = false;
            this.OutConsoleBox.CheckedChanged += new System.EventHandler(this.OutConsoleBox_CheckedChanged);
            // 
            // StringEncBox
            // 
            this.StringEncBox.AutoSize = true;
            this.StringEncBox.BackColor = System.Drawing.Color.Transparent;
            this.StringEncBox.Location = new System.Drawing.Point(91, 83);
            this.StringEncBox.Name = "StringEncBox";
            this.StringEncBox.Size = new System.Drawing.Size(117, 20);
            this.StringEncBox.TabIndex = 70;
            this.StringEncBox.TabStop = false;
            this.StringEncBox.Text = "Add String Encrypt";
            this.StringEncBox.UseVisualStyleBackColor = false;
            // 
            // AntiDumpBox
            // 
            this.AntiDumpBox.AutoSize = true;
            this.AntiDumpBox.BackColor = System.Drawing.Color.Transparent;
            this.AntiDumpBox.Location = new System.Drawing.Point(91, 57);
            this.AntiDumpBox.Name = "AntiDumpBox";
            this.AntiDumpBox.Size = new System.Drawing.Size(96, 20);
            this.AntiDumpBox.TabIndex = 69;
            this.AntiDumpBox.TabStop = false;
            this.AntiDumpBox.Text = "Add AntiDump";
            this.AntiDumpBox.UseVisualStyleBackColor = false;
            // 
            // CountryCISBox
            // 
            this.CountryCISBox.AutoSize = true;
            this.CountryCISBox.BackColor = System.Drawing.Color.Transparent;
            this.CountryCISBox.Checked = true;
            this.CountryCISBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CountryCISBox.Location = new System.Drawing.Point(91, 31);
            this.CountryCISBox.Name = "CountryCISBox";
            this.CountryCISBox.Size = new System.Drawing.Size(268, 20);
            this.CountryCISBox.TabIndex = 68;
            this.CountryCISBox.TabStop = false;
            this.CountryCISBox.Text = "Anti CIS (Commonwealth of Independent States)";
            this.CountryCISBox.UseVisualStyleBackColor = false;
            // 
            // VirtualBox
            // 
            this.VirtualBox.AutoSize = true;
            this.VirtualBox.BackColor = System.Drawing.Color.Transparent;
            this.VirtualBox.Location = new System.Drawing.Point(91, 5);
            this.VirtualBox.Name = "VirtualBox";
            this.VirtualBox.Size = new System.Drawing.Size(157, 20);
            this.VirtualBox.TabIndex = 67;
            this.VirtualBox.TabStop = false;
            this.VirtualBox.Text = "Anti VM ( Virtual Machine )";
            this.VirtualBox.UseVisualStyleBackColor = false;
            // 
            // ToDicData
            // 
            this.ToDicData.BackColor = System.Drawing.Color.Transparent;
            this.ToDicData.BGColor = "120; 5; 179";
            this.ToDicData.FontColor = "#ffffff";
            this.ToDicData.Location = new System.Drawing.Point(321, 251);
            this.ToDicData.Name = "ToDicData";
            this.ToDicData.Size = new System.Drawing.Size(143, 27);
            this.ToDicData.TabIndex = 66;
            this.ToDicData.TabStop = false;
            this.ToDicData.Text = "Add Data to Build";
            this.ToDicData.Click += new System.EventHandler(this.ToDicData_Click);
            // 
            // FuncFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.MessageConnect);
            this.Controls.Add(this.LoggerBox);
            this.Controls.Add(this.DeactiveBox);
            this.Controls.Add(this.ConnectHost);
            this.Controls.Add(this.MessageData);
            this.Controls.Add(this.OutFormsBox);
            this.Controls.Add(this.OutConsoleBox);
            this.Controls.Add(this.StringEncBox);
            this.Controls.Add(this.AntiDumpBox);
            this.Controls.Add(this.CountryCISBox);
            this.Controls.Add(this.VirtualBox);
            this.Controls.Add(this.ToDicData);
            this.Controls.Add(this.OutBuildBox);
            this.Controls.Add(this.BuildText);
            this.Controls.Add(this.ArchiveTagBox);
            this.Controls.Add(this.TagText);
            this.Controls.Add(this.HostBox);
            this.Controls.Add(this.LinkText);
            this.DoubleBuffered = true;
            this.Name = "FuncFrm";
            this.Size = new System.Drawing.Size(745, 304);
            this.Load += new System.EventHandler(this.FuncFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox OutBuildBox;
        private System.Windows.Forms.Label BuildText;
        public System.Windows.Forms.TextBox ArchiveTagBox;
        private System.Windows.Forms.Label TagText;
        public System.Windows.Forms.TextBox HostBox;
        private System.Windows.Forms.Label LinkText;
        private Design.NewButton ToDicData;
        private Design.NewCheckBox VirtualBox;
        private Design.NewCheckBox CountryCISBox;
        private Design.NewCheckBox AntiDumpBox;
        private Design.NewCheckBox OutFormsBox;
        private Design.NewCheckBox OutConsoleBox;
        private Design.NewCheckBox StringEncBox;
        private System.Windows.Forms.Label MessageData;
        private Design.NewButton ConnectHost;
        private Design.NewCheckBox DeactiveBox;
        private Design.NewCheckBox LoggerBox;
        private System.Windows.Forms.Label MessageConnect;
    }
}
