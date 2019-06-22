using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace ComboSuiteRemastered
{
    public partial class DupeTab : UserControl
    {
        private static HashSet<string> List = new HashSet<string>();

        private static HashSet<string> DuplicateList = new HashSet<string>();

        private static HashSet<string> ReferenceList = new HashSet<string>();

        public static string[] filenames = new string[] { };

        public static string[] RefFilenames = new string[] { };

        private static int load, loadref;

        public DupeTab()
        {
            InitializeComponent();
            Globals.LogWriter(DupeConsole, "Waiting for user input...");
        }


        private void LoadFiles_Click(object sender, EventArgs e)
        {
            List.Clear();
            if (load == 1)
            {
                Array.Clear(filenames, 0, filenames.Length);
                load--; LoadFiles.Text = "Load";
                Globals.LogWriter(DupeConsole, "Cleared all loaded files!");
            }
            else if (load == 0)
            {
                filenames = Globals.OpenFileDialog();
                if (filenames.Length == 0)
                {
                    Globals.LogWriter(DupeConsole, $"No file(s) loaded!");
                }
                else
                {
                    Globals.LogWriter(DupeConsole, $"Loaded {filenames.Length} file(s)!");
                    load++; LoadFiles.Text = "Clear";
                }
            }
        }

        private void LoadRefFiles_Click(object sender, EventArgs e)
        {
            if (loadref == 1)
            {
                Array.Clear(RefFilenames, 0, RefFilenames.Length);
                loadref--; LoadRefFiles.Text = "Load";
                Globals.LogWriter(DupeConsole, "Cleared all loaded reference files!");
            }
            else if (loadref == 0)
            {
                RefFilenames = Globals.OpenFileDialog();
                if (RefFilenames.Length == 0)
                {
                    Globals.LogWriter(DupeConsole, $"No reference file(s) loaded!");
                }
                else
                {
                    Task t = Task.Factory.StartNew(() =>
                    {
                        ReadReference(RefFilenames);
                    });
                    loadref++;  LoadRefFiles.Text = "Clear";
                }
            }
        }


        private void ReadReference(string[] RefFilenames)
        {
            foreach (var file in RefFilenames)
            {
                using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (BufferedStream bs = new BufferedStream(fs))
                    {
                        using (StreamReader sr = new StreamReader(bs))
                        {
                            string refline = string.Empty;
                            while ((refline = sr.ReadLine()) != null)
                            {
                                if (!ReferenceList.Contains(refline))
                                {
                                    ReferenceList.Add(refline);
                                }
                            }
                        }
                    }
                }
            }
            Globals.LogWriter(DupeConsole, $"Loaded {RefFilenames.Length} reference file(s)");
        }

        private void StartProcess()
        {
            DupeConsole.Clear();
            Globals.LogWriter(DupeConsole, "Removing Duplicates...");
            try
            {
                foreach (var file in filenames)
                {
                    var file_name = Path.GetFileName(file);
                    HashSet<string> SaveEachList = new HashSet<string>();

                    using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (BufferedStream bs = new BufferedStream(fs))
                        {
                            using (StreamReader sr = new StreamReader(bs))
                            {
                                string line = string.Empty;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    if (DuplicateGlobal.UseRefFiles)
                                    {
                                        if (!ReferenceList.Contains(line))
                                        {
                                            if (DuplicateGlobal.SaveToEachFile)
                                            {
                                                SaveEachList.Add(line);
                                            }
                                            List.Add(line);
                                        }
                                        else
                                        {
                                            DuplicateList.Add(line);
                                            DuplicateGlobal.Duplicates++;
                                        }
                                    }
                                    else
                                    {
                                        if (!List.Contains(line))
                                        {
                                            if (DuplicateGlobal.SaveToEachFile)
                                            {
                                                SaveEachList.Add(line);
                                            }
                                            List.Add(line);

                                        }
                                        else
                                        {
                                            DuplicateList.Add(line);
                                            DuplicateGlobal.Duplicates++;
                                        }
                                    }

                                }
                            }
                        }
                    }
                    if (DuplicateGlobal.SaveToEachFile)
                    {
                        if (DuplicateGlobal.UseRefFiles)
                        {
                            File.AppendAllText($"Reference-Each-output-{file_name}", string.Join(Environment.NewLine, SaveEachList));
                        }
                        else
                        {
                            File.AppendAllText($"output-Each-{file_name}", string.Join(Environment.NewLine, SaveEachList));
                        }
                    }
                }
                if (DuplicateGlobal.UseRefFiles)
                {
                    File.AppendAllText("Reference-" + OutputFileTxt.Text, string.Join(Environment.NewLine, List));
                    Globals.LogWriter(DupeConsole, $"Reference Duplicates found: {DuplicateGlobal.Duplicates}");
                    Globals.LogWriter(DupeConsole, "Successfully removed reference duplicates...");
                    Globals.LogWriter(DupeConsole, $"Saved {List.Count} lines to Reference-{OutputFileTxt.Text}");
                    if (DuplicateGlobal.SaveDuplicates)
                    {
                        File.AppendAllText("Reference-" + SaveOutputTxt.Text, string.Join(Environment.NewLine, DuplicateList));
                        Globals.LogWriter(DupeConsole, $"Saved {DuplicateGlobal.Duplicates} reference duplicates to Reference-{SaveOutputTxt.Text}");
                    }
                }
                else
                {
                    File.AppendAllText(OutputFileTxt.Text, string.Join(Environment.NewLine, List));
                    Globals.LogWriter(DupeConsole, $"Duplicates found: {DuplicateGlobal.Duplicates}");
                    Globals.LogWriter(DupeConsole, "Successfully removed duplicates...");
                    Globals.LogWriter(DupeConsole, $"Saved {List.Count} lines to {OutputFileTxt.Text}");
                    if (DuplicateGlobal.SaveDuplicates)
                    {
                        File.AppendAllText(SaveOutputTxt.Text, string.Join(Environment.NewLine, DuplicateList));
                        Globals.LogWriter(DupeConsole, $"Saved {DuplicateGlobal.Duplicates} duplicates to {SaveOutputTxt.Text}");
                    }
                }
            }
            catch (Exception e)
            {
                Globals.LogWriter(DupeConsole, $"ERROR: {e.Message}");
                List.Clear(); DuplicateList.Clear(); DuplicateGlobal.Duplicates = 0;
                Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load";
                Array.Clear(RefFilenames, 0, RefFilenames.Length); loadref--; LoadRefFiles.Text = "Load";
            }
            List.Clear(); DuplicateList.Clear(); DuplicateGlobal.Duplicates = 0;
            Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load";
            Array.Clear(RefFilenames, 0, RefFilenames.Length); loadref--; LoadRefFiles.Text = "Load"; 
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            DuplicateGlobal.Duplicates = 0;
            Task t = Task.Factory.StartNew(() =>
            {
                StartProcess();
            });
        }
        private void SaveDuplicatesSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (SaveDuplicatesSwitch.Value == true)
            {
                DuplicateGlobal.SaveDuplicates = true;
                SaveOutputTxt.Enabled = true;
            }
            else if (SaveDuplicatesSwitch.Value == false)
            {
                DuplicateGlobal.SaveDuplicates = false;
                SaveOutputTxt.Enabled = false;
            }
        }

        private void SaveEachSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (SaveEachSwitch.Value == true)
            {
                DuplicateGlobal.SaveToEachFile = true;
            }
            else if (SaveEachSwitch.Value == false)
            {
                DuplicateGlobal.SaveToEachFile = false;
            }
        }

        private void UseReferenceFileSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (UseReferenceFileSwitch.Value == true)
            {
                DuplicateGlobal.UseRefFiles = true;
                LoadRefFiles.Enabled = true;
            }
            else if (UseReferenceFileSwitch.Value == false)
            {
                DuplicateGlobal.UseRefFiles = false;
                LoadRefFiles.Enabled = false;
            }
        }

       
    }
}
