namespace DaddyRecoveryBuilder.ExForms
{
    partial class AssFrm
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
            this.components = new System.ComponentModel.Container();
            this.FilePathBox = new System.Windows.Forms.TextBox();
            this.PathToFileText = new System.Windows.Forms.Label();
            this.OriginalBox = new System.Windows.Forms.TextBox();
            this.FilenameText = new System.Windows.Forms.Label();
            this.FileVerBox = new System.Windows.Forms.TextBox();
            this.ProdVerBox = new System.Windows.Forms.TextBox();
            this.InternalBox = new System.Windows.Forms.TextBox();
            this.TrademarksBox = new System.Windows.Forms.TextBox();
            this.CopyrightBox = new System.Windows.Forms.TextBox();
            this.CompanyBox = new System.Windows.Forms.TextBox();
            this.DescriptBox = new System.Windows.Forms.TextBox();
            this.ProductBox = new System.Windows.Forms.TextBox();
            this.FileVerText = new System.Windows.Forms.Label();
            this.ProdVerText = new System.Windows.Forms.Label();
            this.NameText = new System.Windows.Forms.Label();
            this.TrademarksText = new System.Windows.Forms.Label();
            this.CopyRightText = new System.Windows.Forms.Label();
            this.CompanyText = new System.Windows.Forms.Label();
            this.DescriptText = new System.Windows.Forms.Label();
            this.ProdText = new System.Windows.Forms.Label();
            this.DragIcoText = new System.Windows.Forms.Label();
            this.IcoViewer = new System.Windows.Forms.PictureBox();
            this.MessageProperties = new System.Windows.Forms.Label();
            this.MessageData = new System.Windows.Forms.Label();
            this.LsizeIco = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.CloneDataButton = new DaddyRecoveryBuilder.Design.NewButton();
            this.RndAssButton = new DaddyRecoveryBuilder.Design.NewButton();
            this.GenAssButton = new DaddyRecoveryBuilder.Design.NewButton();
            this.ToDicData = new DaddyRecoveryBuilder.Design.NewButton();
            this.EditAssAppOther = new DaddyRecoveryBuilder.Design.NewButton();
            this.OtherAppChangeBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.ActiveBoxBuild = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.IconBox = new DaddyRecoveryBuilder.Design.NewCheckBox();
            this.AppChoice = new DaddyRecoveryBuilder.Design.NewButton();
            ((System.ComponentModel.ISupportInitialize)(this.IcoViewer)).BeginInit();
            this.SuspendLayout();
            // 
            // FilePathBox
            // 
            this.FilePathBox.AllowDrop = true;
            this.FilePathBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.FilePathBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FilePathBox.ForeColor = System.Drawing.SystemColors.Window;
            this.FilePathBox.Location = new System.Drawing.Point(120, 247);
            this.FilePathBox.MaxLength = 99;
            this.FilePathBox.Name = "FilePathBox";
            this.FilePathBox.ReadOnly = true;
            this.FilePathBox.Size = new System.Drawing.Size(269, 20);
            this.FilePathBox.TabIndex = 95;
            this.FilePathBox.TabStop = false;
            this.FilePathBox.Visible = false;
            this.FilePathBox.TextChanged += new System.EventHandler(this.FilePathBox_TextChanged);
            // 
            // PathToFileText
            // 
            this.PathToFileText.AutoSize = true;
            this.PathToFileText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold);
            this.PathToFileText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.PathToFileText.Location = new System.Drawing.Point(2, 249);
            this.PathToFileText.Name = "PathToFileText";
            this.PathToFileText.Size = new System.Drawing.Size(112, 15);
            this.PathToFileText.TabIndex = 94;
            this.PathToFileText.Text = "Path to Application:";
            this.PathToFileText.Visible = false;
            // 
            // OriginalBox
            // 
            this.OriginalBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.OriginalBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.OriginalBox.ForeColor = System.Drawing.SystemColors.Window;
            this.OriginalBox.Location = new System.Drawing.Point(120, 171);
            this.OriginalBox.MaxLength = 99;
            this.OriginalBox.Name = "OriginalBox";
            this.OriginalBox.Size = new System.Drawing.Size(269, 20);
            this.OriginalBox.TabIndex = 93;
            this.OriginalBox.TabStop = false;
            this.OriginalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FilenameText
            // 
            this.FilenameText.AutoSize = true;
            this.FilenameText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FilenameText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FilenameText.Location = new System.Drawing.Point(2, 174);
            this.FilenameText.Name = "FilenameText";
            this.FilenameText.Size = new System.Drawing.Size(99, 15);
            this.FilenameText.TabIndex = 92;
            this.FilenameText.Text = "OriginalFilename:";
            // 
            // FileVerBox
            // 
            this.FileVerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.FileVerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileVerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(116)))), ((int)(((byte)(52)))));
            this.FileVerBox.Location = new System.Drawing.Point(120, 221);
            this.FileVerBox.MaxLength = 9;
            this.FileVerBox.Name = "FileVerBox";
            this.FileVerBox.Size = new System.Drawing.Size(269, 20);
            this.FileVerBox.TabIndex = 91;
            this.FileVerBox.TabStop = false;
            this.FileVerBox.Text = "1.0.0.0";
            // 
            // ProdVerBox
            // 
            this.ProdVerBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.ProdVerBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProdVerBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(137)))), ((int)(((byte)(116)))), ((int)(((byte)(52)))));
            this.ProdVerBox.Location = new System.Drawing.Point(120, 196);
            this.ProdVerBox.MaxLength = 9;
            this.ProdVerBox.Name = "ProdVerBox";
            this.ProdVerBox.Size = new System.Drawing.Size(269, 20);
            this.ProdVerBox.TabIndex = 90;
            this.ProdVerBox.TabStop = false;
            this.ProdVerBox.Text = "1.0.0.0";
            // 
            // InternalBox
            // 
            this.InternalBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.InternalBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.InternalBox.ForeColor = System.Drawing.SystemColors.Window;
            this.InternalBox.Location = new System.Drawing.Point(120, 147);
            this.InternalBox.MaxLength = 99;
            this.InternalBox.Name = "InternalBox";
            this.InternalBox.Size = new System.Drawing.Size(269, 20);
            this.InternalBox.TabIndex = 89;
            this.InternalBox.TabStop = false;
            this.InternalBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // TrademarksBox
            // 
            this.TrademarksBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.TrademarksBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TrademarksBox.ForeColor = System.Drawing.SystemColors.Window;
            this.TrademarksBox.Location = new System.Drawing.Point(120, 123);
            this.TrademarksBox.MaxLength = 99;
            this.TrademarksBox.Name = "TrademarksBox";
            this.TrademarksBox.Size = new System.Drawing.Size(269, 20);
            this.TrademarksBox.TabIndex = 88;
            this.TrademarksBox.TabStop = false;
            this.TrademarksBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CopyrightBox
            // 
            this.CopyrightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.CopyrightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CopyrightBox.ForeColor = System.Drawing.SystemColors.Window;
            this.CopyrightBox.Location = new System.Drawing.Point(120, 99);
            this.CopyrightBox.MaxLength = 99;
            this.CopyrightBox.Name = "CopyrightBox";
            this.CopyrightBox.Size = new System.Drawing.Size(269, 20);
            this.CopyrightBox.TabIndex = 87;
            this.CopyrightBox.TabStop = false;
            this.CopyrightBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CompanyBox
            // 
            this.CompanyBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.CompanyBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CompanyBox.ForeColor = System.Drawing.SystemColors.Window;
            this.CompanyBox.Location = new System.Drawing.Point(120, 75);
            this.CompanyBox.MaxLength = 99;
            this.CompanyBox.Name = "CompanyBox";
            this.CompanyBox.Size = new System.Drawing.Size(269, 20);
            this.CompanyBox.TabIndex = 86;
            this.CompanyBox.TabStop = false;
            this.CompanyBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // DescriptBox
            // 
            this.DescriptBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.DescriptBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptBox.ForeColor = System.Drawing.SystemColors.Window;
            this.DescriptBox.Location = new System.Drawing.Point(120, 51);
            this.DescriptBox.MaxLength = 99;
            this.DescriptBox.Name = "DescriptBox";
            this.DescriptBox.Size = new System.Drawing.Size(269, 20);
            this.DescriptBox.TabIndex = 85;
            this.DescriptBox.TabStop = false;
            this.DescriptBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ProductBox
            // 
            this.ProductBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(28)))), ((int)(((byte)(34)))));
            this.ProductBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ProductBox.ForeColor = System.Drawing.SystemColors.Window;
            this.ProductBox.Location = new System.Drawing.Point(120, 27);
            this.ProductBox.MaxLength = 99;
            this.ProductBox.Name = "ProductBox";
            this.ProductBox.Size = new System.Drawing.Size(269, 20);
            this.ProductBox.TabIndex = 84;
            this.ProductBox.TabStop = false;
            this.ProductBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FileVerText
            // 
            this.FileVerText.AutoSize = true;
            this.FileVerText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FileVerText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.FileVerText.Location = new System.Drawing.Point(2, 223);
            this.FileVerText.Name = "FileVerText";
            this.FileVerText.Size = new System.Drawing.Size(68, 15);
            this.FileVerText.TabIndex = 83;
            this.FileVerText.Text = "FileVersion:";
            // 
            // ProdVerText
            // 
            this.ProdVerText.AutoSize = true;
            this.ProdVerText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProdVerText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProdVerText.Location = new System.Drawing.Point(2, 200);
            this.ProdVerText.Name = "ProdVerText";
            this.ProdVerText.Size = new System.Drawing.Size(92, 15);
            this.ProdVerText.TabIndex = 82;
            this.ProdVerText.Text = "ProductVersion:";
            // 
            // NameText
            // 
            this.NameText.AutoSize = true;
            this.NameText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.NameText.Location = new System.Drawing.Point(2, 151);
            this.NameText.Name = "NameText";
            this.NameText.Size = new System.Drawing.Size(81, 15);
            this.NameText.TabIndex = 81;
            this.NameText.Text = "InternalName:";
            // 
            // TrademarksText
            // 
            this.TrademarksText.AutoSize = true;
            this.TrademarksText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TrademarksText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.TrademarksText.Location = new System.Drawing.Point(2, 126);
            this.TrademarksText.Name = "TrademarksText";
            this.TrademarksText.Size = new System.Drawing.Size(98, 15);
            this.TrademarksText.TabIndex = 80;
            this.TrademarksText.Text = "LegalTrademarks:";
            // 
            // CopyRightText
            // 
            this.CopyRightText.AutoSize = true;
            this.CopyRightText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CopyRightText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CopyRightText.Location = new System.Drawing.Point(2, 102);
            this.CopyRightText.Name = "CopyRightText";
            this.CopyRightText.Size = new System.Drawing.Size(90, 15);
            this.CopyRightText.TabIndex = 79;
            this.CopyRightText.Text = "LegalCopyright:";
            // 
            // CompanyText
            // 
            this.CompanyText.AutoSize = true;
            this.CompanyText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CompanyText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CompanyText.Location = new System.Drawing.Point(2, 78);
            this.CompanyText.Name = "CompanyText";
            this.CompanyText.Size = new System.Drawing.Size(91, 15);
            this.CompanyText.TabIndex = 78;
            this.CompanyText.Text = "CompanyName:";
            // 
            // DescriptText
            // 
            this.DescriptText.AutoSize = true;
            this.DescriptText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.DescriptText.Location = new System.Drawing.Point(2, 54);
            this.DescriptText.Name = "DescriptText";
            this.DescriptText.Size = new System.Drawing.Size(88, 15);
            this.DescriptText.TabIndex = 77;
            this.DescriptText.Text = "FileDescription:";
            // 
            // ProdText
            // 
            this.ProdText.AutoSize = true;
            this.ProdText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProdText.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ProdText.Location = new System.Drawing.Point(2, 29);
            this.ProdText.Name = "ProdText";
            this.ProdText.Size = new System.Drawing.Size(83, 15);
            this.ProdText.TabIndex = 76;
            this.ProdText.Text = "ProductName:";
            // 
            // DragIcoText
            // 
            this.DragIcoText.AutoSize = true;
            this.DragIcoText.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DragIcoText.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.DragIcoText.Location = new System.Drawing.Point(589, 146);
            this.DragIcoText.Name = "DragIcoText";
            this.DragIcoText.Size = new System.Drawing.Size(134, 15);
            this.DragIcoText.TabIndex = 98;
            this.DragIcoText.Text = "[Drag and Drop or Click]";
            this.DragIcoText.Visible = false;
            // 
            // IcoViewer
            // 
            this.IcoViewer.Image = global::DaddyRecoveryBuilder.Properties.Resources.drag_and_drop_icon;
            this.IcoViewer.Location = new System.Drawing.Point(564, 164);
            this.IcoViewer.Name = "IcoViewer";
            this.IcoViewer.Size = new System.Drawing.Size(178, 103);
            this.IcoViewer.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.IcoViewer.TabIndex = 97;
            this.IcoViewer.TabStop = false;
            this.IcoViewer.Visible = false;
            this.IcoViewer.Click += new System.EventHandler(this.IcoViewer_Click);
            this.IcoViewer.DragDrop += new System.Windows.Forms.DragEventHandler(this.IcoViewer_DragDrop);
            this.IcoViewer.DragEnter += new System.Windows.Forms.DragEventHandler(this.IcoViewer_DragEnter);
            // 
            // MessageProperties
            // 
            this.MessageProperties.AutoSize = true;
            this.MessageProperties.ForeColor = System.Drawing.Color.Yellow;
            this.MessageProperties.Location = new System.Drawing.Point(117, 273);
            this.MessageProperties.Name = "MessageProperties";
            this.MessageProperties.Size = new System.Drawing.Size(0, 13);
            this.MessageProperties.TabIndex = 107;
            // 
            // MessageData
            // 
            this.MessageData.AutoSize = true;
            this.MessageData.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(5)))), ((int)(((byte)(179)))));
            this.MessageData.Location = new System.Drawing.Point(429, 198);
            this.MessageData.Name = "MessageData";
            this.MessageData.Size = new System.Drawing.Size(0, 13);
            this.MessageData.TabIndex = 108;
            // 
            // LsizeIco
            // 
            this.LsizeIco.AutoSize = true;
            this.LsizeIco.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LsizeIco.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.LsizeIco.Location = new System.Drawing.Point(604, 271);
            this.LsizeIco.Name = "LsizeIco";
            this.LsizeIco.Size = new System.Drawing.Size(0, 15);
            this.LsizeIco.TabIndex = 109;
            this.LsizeIco.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutoPopDelay = 7000;
            this.toolTip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(5)))), ((int)(((byte)(179)))));
            this.toolTip1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.toolTip1.InitialDelay = 1000;
            this.toolTip1.ReshowDelay = 50;
            // 
            // CloneDataButton
            // 
            this.CloneDataButton.BackColor = System.Drawing.Color.Transparent;
            this.CloneDataButton.BGColor = "#20262C";
            this.CloneDataButton.FontColor = "#ffffff";
            this.CloneDataButton.Location = new System.Drawing.Point(394, 96);
            this.CloneDataButton.Name = "CloneDataButton";
            this.CloneDataButton.Size = new System.Drawing.Size(166, 31);
            this.CloneDataButton.TabIndex = 101;
            this.CloneDataButton.TabStop = false;
            this.CloneDataButton.Text = "Clone data Application";
            this.toolTip1.SetToolTip(this.CloneDataButton, "[Eng]\r\nCollects properties from another file\r\n[Rus]\r\nСобирает свойства из другого" +
        " файла");
            this.CloneDataButton.Click += new System.EventHandler(this.CloneDataButton_Click);
            // 
            // RndAssButton
            // 
            this.RndAssButton.BackColor = System.Drawing.Color.Transparent;
            this.RndAssButton.BGColor = "#20262C";
            this.RndAssButton.FontColor = "#ffffff";
            this.RndAssButton.Location = new System.Drawing.Point(395, 62);
            this.RndAssButton.Name = "RndAssButton";
            this.RndAssButton.Size = new System.Drawing.Size(165, 31);
            this.RndAssButton.TabIndex = 100;
            this.RndAssButton.TabStop = false;
            this.RndAssButton.Text = "Random Assembly";
            this.toolTip1.SetToolTip(this.RndAssButton, "[Eng]\r\nGenerates random properties for a file\r\n[Rus]\r\nГенерирует рандомное свойст" +
        "ва для файла\r\n");
            this.RndAssButton.Click += new System.EventHandler(this.RndAssButton_Click);
            // 
            // GenAssButton
            // 
            this.GenAssButton.BackColor = System.Drawing.Color.Transparent;
            this.GenAssButton.BGColor = "#20262C";
            this.GenAssButton.FontColor = "#ffffff";
            this.GenAssButton.Location = new System.Drawing.Point(394, 27);
            this.GenAssButton.Name = "GenAssButton";
            this.GenAssButton.Size = new System.Drawing.Size(166, 31);
            this.GenAssButton.TabIndex = 99;
            this.GenAssButton.TabStop = false;
            this.GenAssButton.Text = "Generate Assembly";
            this.toolTip1.SetToolTip(this.GenAssButton, "[Eng]\r\nGenerates random properties for a file from an embedded list\r\n[Rus]\r\nГенер" +
        "ирует рандомное свойства для файла из встроенного списка");
            this.GenAssButton.Click += new System.EventHandler(this.GenAssButton_Click);
            // 
            // ToDicData
            // 
            this.ToDicData.BackColor = System.Drawing.Color.Transparent;
            this.ToDicData.BGColor = "120; 5; 179";
            this.ToDicData.FontColor = "#ffffff";
            this.ToDicData.Location = new System.Drawing.Point(395, 161);
            this.ToDicData.Name = "ToDicData";
            this.ToDicData.Size = new System.Drawing.Size(165, 31);
            this.ToDicData.TabIndex = 96;
            this.ToDicData.TabStop = false;
            this.ToDicData.Text = "Add Data to Build";
            this.toolTip1.SetToolTip(this.ToDicData, "[Eng]\r\nAdds data to a dictionary\r\n[Rus]\r\nДобавляет данные в словарь");
            this.ToDicData.Visible = false;
            this.ToDicData.Click += new System.EventHandler(this.ToDicData_Click);
            // 
            // EditAssAppOther
            // 
            this.EditAssAppOther.BackColor = System.Drawing.Color.Transparent;
            this.EditAssAppOther.BGColor = "#20262C";
            this.EditAssAppOther.FontColor = "#ffffff";
            this.EditAssAppOther.Location = new System.Drawing.Point(394, 130);
            this.EditAssAppOther.Name = "EditAssAppOther";
            this.EditAssAppOther.Size = new System.Drawing.Size(166, 28);
            this.EditAssAppOther.TabIndex = 106;
            this.EditAssAppOther.TabStop = false;
            this.EditAssAppOther.Text = "Edit Assembly Application";
            this.EditAssAppOther.Visible = false;
            this.EditAssAppOther.Click += new System.EventHandler(this.EditAssAppOther_Click);
            // 
            // OtherAppChangeBox
            // 
            this.OtherAppChangeBox.AutoSize = true;
            this.OtherAppChangeBox.BackColor = System.Drawing.Color.Transparent;
            this.OtherAppChangeBox.Location = new System.Drawing.Point(564, 64);
            this.OtherAppChangeBox.Name = "OtherAppChangeBox";
            this.OtherAppChangeBox.Size = new System.Drawing.Size(126, 20);
            this.OtherAppChangeBox.TabIndex = 105;
            this.OtherAppChangeBox.TabStop = false;
            this.OtherAppChangeBox.Text = "Change another app";
            this.OtherAppChangeBox.UseVisualStyleBackColor = false;
            this.OtherAppChangeBox.CheckedChanged += new System.EventHandler(this.OtherAppChangeBox_CheckedChanged);
            // 
            // ActiveBoxBuild
            // 
            this.ActiveBoxBuild.AutoSize = true;
            this.ActiveBoxBuild.BackColor = System.Drawing.Color.Transparent;
            this.ActiveBoxBuild.Location = new System.Drawing.Point(564, 38);
            this.ActiveBoxBuild.Name = "ActiveBoxBuild";
            this.ActiveBoxBuild.Size = new System.Drawing.Size(176, 20);
            this.ActiveBoxBuild.TabIndex = 104;
            this.ActiveBoxBuild.TabStop = false;
            this.ActiveBoxBuild.Text = "Add properties for the build file";
            this.ActiveBoxBuild.UseVisualStyleBackColor = false;
            this.ActiveBoxBuild.CheckedChanged += new System.EventHandler(this.ActiveBoxBuild_CheckedChanged);
            // 
            // IconBox
            // 
            this.IconBox.AutoSize = true;
            this.IconBox.BackColor = System.Drawing.Color.Transparent;
            this.IconBox.Location = new System.Drawing.Point(564, 90);
            this.IconBox.Name = "IconBox";
            this.IconBox.Size = new System.Drawing.Size(147, 20);
            this.IconBox.TabIndex = 103;
            this.IconBox.TabStop = false;
            this.IconBox.Text = "Add icon for the build file";
            this.IconBox.UseVisualStyleBackColor = false;
            this.IconBox.CheckedChanged += new System.EventHandler(this.IconBox_CheckedChanged);
            // 
            // AppChoice
            // 
            this.AppChoice.BackColor = System.Drawing.Color.Transparent;
            this.AppChoice.BGColor = "#20262C";
            this.AppChoice.FontColor = "#ffffff";
            this.AppChoice.Location = new System.Drawing.Point(394, 247);
            this.AppChoice.Name = "AppChoice";
            this.AppChoice.Size = new System.Drawing.Size(77, 20);
            this.AppChoice.TabIndex = 102;
            this.AppChoice.TabStop = false;
            this.AppChoice.Text = "...";
            this.AppChoice.Visible = false;
            this.AppChoice.Click += new System.EventHandler(this.AppChoice_Click);
            // 
            // AssFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.Controls.Add(this.LsizeIco);
            this.Controls.Add(this.MessageData);
            this.Controls.Add(this.MessageProperties);
            this.Controls.Add(this.EditAssAppOther);
            this.Controls.Add(this.OtherAppChangeBox);
            this.Controls.Add(this.ActiveBoxBuild);
            this.Controls.Add(this.IconBox);
            this.Controls.Add(this.AppChoice);
            this.Controls.Add(this.CloneDataButton);
            this.Controls.Add(this.RndAssButton);
            this.Controls.Add(this.GenAssButton);
            this.Controls.Add(this.DragIcoText);
            this.Controls.Add(this.IcoViewer);
            this.Controls.Add(this.ToDicData);
            this.Controls.Add(this.FilePathBox);
            this.Controls.Add(this.PathToFileText);
            this.Controls.Add(this.OriginalBox);
            this.Controls.Add(this.FilenameText);
            this.Controls.Add(this.FileVerBox);
            this.Controls.Add(this.ProdVerBox);
            this.Controls.Add(this.InternalBox);
            this.Controls.Add(this.TrademarksBox);
            this.Controls.Add(this.CopyrightBox);
            this.Controls.Add(this.CompanyBox);
            this.Controls.Add(this.DescriptBox);
            this.Controls.Add(this.ProductBox);
            this.Controls.Add(this.FileVerText);
            this.Controls.Add(this.ProdVerText);
            this.Controls.Add(this.NameText);
            this.Controls.Add(this.TrademarksText);
            this.Controls.Add(this.CopyRightText);
            this.Controls.Add(this.CompanyText);
            this.Controls.Add(this.DescriptText);
            this.Controls.Add(this.ProdText);
            this.Name = "AssFrm";
            this.Size = new System.Drawing.Size(745, 304);
            this.Load += new System.EventHandler(this.AssFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.IcoViewer)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePathBox;
        private System.Windows.Forms.Label PathToFileText;
        private System.Windows.Forms.TextBox OriginalBox;
        private System.Windows.Forms.Label FilenameText;
        private System.Windows.Forms.TextBox FileVerBox;
        private System.Windows.Forms.TextBox ProdVerBox;
        private System.Windows.Forms.TextBox InternalBox;
        private System.Windows.Forms.TextBox TrademarksBox;
        private System.Windows.Forms.TextBox CopyrightBox;
        private System.Windows.Forms.TextBox CompanyBox;
        private System.Windows.Forms.TextBox DescriptBox;
        private System.Windows.Forms.TextBox ProductBox;
        private System.Windows.Forms.Label FileVerText;
        private System.Windows.Forms.Label ProdVerText;
        private System.Windows.Forms.Label NameText;
        private System.Windows.Forms.Label TrademarksText;
        private System.Windows.Forms.Label CopyRightText;
        private System.Windows.Forms.Label CompanyText;
        private System.Windows.Forms.Label DescriptText;
        private System.Windows.Forms.Label ProdText;
        private Design.NewButton ToDicData;
        private System.Windows.Forms.Label DragIcoText;
        private System.Windows.Forms.PictureBox IcoViewer;
        private Design.NewButton GenAssButton;
        private Design.NewButton RndAssButton;
        private Design.NewButton CloneDataButton;
        private Design.NewButton AppChoice;
        private Design.NewCheckBox IconBox;
        private Design.NewCheckBox ActiveBoxBuild;
        private Design.NewCheckBox OtherAppChangeBox;
        private Design.NewButton EditAssAppOther;
        private System.Windows.Forms.Label MessageProperties;
        private System.Windows.Forms.Label MessageData;
        private System.Windows.Forms.Label LsizeIco;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
