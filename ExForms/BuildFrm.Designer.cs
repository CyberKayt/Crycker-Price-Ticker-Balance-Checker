namespace DaddyRecoveryBuilder.ExForms
{
    partial class BuildFrm
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
            this.InfoViewer = new System.Windows.Forms.TextBox();
            this.CopyRightText = new System.Windows.Forms.Label();
            this.VerInfoText = new System.Windows.Forms.Label();
            this.BuildStart = new DaddyRecoveryBuilder.Design.NewButton();
            this.SuspendLayout();
            // 
            // InfoViewer
            // 
            this.InfoViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.InfoViewer.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InfoViewer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoViewer.ForeColor = System.Drawing.SystemColors.Window;
            this.InfoViewer.Location = new System.Drawing.Point(59, 62);
            this.InfoViewer.Multiline = true;
            this.InfoViewer.Name = "InfoViewer";
            this.InfoViewer.ReadOnly = true;
            this.InfoViewer.Size = new System.Drawing.Size(627, 181);
            this.InfoViewer.TabIndex = 68;
            this.InfoViewer.TabStop = false;
            // 
            // CopyRightText
            // 
            this.CopyRightText.AutoSize = true;
            this.CopyRightText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CopyRightText.ForeColor = System.Drawing.Color.DarkOrchid;
            this.CopyRightText.Location = new System.Drawing.Point(56, 44);
            this.CopyRightText.Name = "CopyRightText";
            this.CopyRightText.Size = new System.Drawing.Size(60, 15);
            this.CopyRightText.TabIndex = 80;
            this.CopyRightText.Text = "Log Build:";
            // 
            // VerInfoText
            // 
            this.VerInfoText.AutoSize = true;
            this.VerInfoText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.VerInfoText.ForeColor = System.Drawing.Color.DarkOrchid;
            this.VerInfoText.Location = new System.Drawing.Point(633, 273);
            this.VerInfoText.Name = "VerInfoText";
            this.VerInfoText.Size = new System.Drawing.Size(0, 15);
            this.VerInfoText.TabIndex = 81;
            // 
            // BuildStart
            // 
            this.BuildStart.BackColor = System.Drawing.Color.Transparent;
            this.BuildStart.BGColor = "DarkOrchid";
            this.BuildStart.Font = new System.Drawing.Font("Plantagenet Cherokee", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.BuildStart.FontColor = "#ffffff";
            this.BuildStart.Location = new System.Drawing.Point(218, 261);
            this.BuildStart.Name = "BuildStart";
            this.BuildStart.Size = new System.Drawing.Size(322, 27);
            this.BuildStart.TabIndex = 67;
            this.BuildStart.TabStop = false;
            this.BuildStart.Text = "Create a build stealer";
            this.BuildStart.Click += new System.EventHandler(this.BuildStart_Click);
            // 
            // BuildFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.VerInfoText);
            this.Controls.Add(this.CopyRightText);
            this.Controls.Add(this.InfoViewer);
            this.Controls.Add(this.BuildStart);
            this.Name = "BuildFrm";
            this.Size = new System.Drawing.Size(745, 304);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Design.NewButton BuildStart;
        public System.Windows.Forms.TextBox InfoViewer;
        private System.Windows.Forms.Label CopyRightText;
        private System.Windows.Forms.Label VerInfoText;
    }
}
