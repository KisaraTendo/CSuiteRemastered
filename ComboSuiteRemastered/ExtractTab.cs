using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ComboSuiteRemastered
{
    public partial class ExtractTab : UserControl
    {
        private static HashSet<string> List = new HashSet<string>();

        public static string[] filenames = new string[] { };

        private static int load;


        public ExtractTab()
        {
            InitializeComponent();
            Globals.LogWriter(ExtractConsole, "Waiting for user input...");
        }

        private void StartBtn_Click(object sender, EventArgs e)
        {
            List.Clear();
            Task t = Task.Factory.StartNew(() =>
            {
                StartProcess();
            });

        }

        private void StartProcess()
        {
            ExtractConsole.Clear();
            Globals.LogWriter(ExtractConsole, "Extracting...");

            Regex EmailOnlyRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@(?:(?:[a-zA-Z0-9-]+\.)?[a-zA-Z]+\.)?" + $"({ExtractTermTxt.Text})?$");
            Regex CustomRegex = new Regex(CustomRegexTxt.Text);
            Regex NormalRegex = new Regex(@"^[a-zA-Z0-9_.+-]+@(?:(?:[a-zA-Z0-9-]+\.)?[a-zA-Z]+\.)?(" + ExtractTermTxt.Text + @")?:.*$");
            try
            {
                foreach (var file in filenames)
                {
                    string file_name = Path.GetFileName(file);
                    using (FileStream fs = File.Open(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                    {
                        using (BufferedStream bs = new BufferedStream(fs))
                        {
                            using (StreamReader sr = new StreamReader(bs))
                            {
                                string line = string.Empty;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    // MessageBox.Show(line);
                                    if (ExtractGlobal.EmailOnly)
                                    {

                                        Match match = EmailOnlyRegex.Match(line);
                                        if (match.Success)
                                        {
                                            List.Add(line);
                                        }
                                    }
                                    else if (ExtractGlobal.CustomRegex)
                                    {
                                        Match match = CustomRegex.Match(line);
                                        if (match.Success)
                                        {
                                            List.Add(line);
                                        }
                                    }
                                    else
                                    {
                                        Match match = NormalRegex.Match(line);
                                        if (match.Success)
                                        {
                                            List.Add(line);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Globals.LogWriter(ExtractConsole, $"ERROR: {e.Message}");
                Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load"; List.Clear();
            }
            
            File.AppendAllText(OutputFileTxt.Text, string.Join(Environment.NewLine, List));
            Globals.LogWriter(ExtractConsole, $"Extracted {List.Count} lines");
            Globals.LogWriter(ExtractConsole, "Extraction successful...");
            Globals.LogWriter(ExtractConsole, $"Saved {List.Count} lines to {OutputFileTxt.Text}");
            Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load"; List.Clear();
        }




        private void EmailOnlySwitch_OnValueChange(object sender, EventArgs e)
        {
            if (EmailOnlySwitch.Value == true)
            {
                ExtractGlobal.EmailOnly = true;
                CustomRegexTxt.Enabled = false;
                CustomRegexSwitch.Enabled = false;
            }
            else if (EmailOnlySwitch.Value == false)
            {
                ExtractGlobal.EmailOnly = false;
                CustomRegexSwitch.Enabled = true;
            }
        }

        private void CustomRegexSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (CustomRegexSwitch.Value == true)
            {
                ExtractGlobal.CustomRegex = true;
                ExtractTermTxt.Enabled = false;
                CustomRegexTxt.Enabled = true;
                EmailOnlySwitch.Enabled = false;
            }
            else if (CustomRegexSwitch.Value == false)
            {
                ExtractGlobal.CustomRegex = false;
                CustomRegexTxt.Enabled = false;
                ExtractTermTxt.Enabled = true;
                EmailOnlySwitch.Enabled = true;
            }
        }

        private void LoadFiles_Click(object sender, EventArgs e)
        {
            List.Clear();
            if (load == 1)
            {
                Array.Clear(filenames, 0, filenames.Length);
                load--; LoadFiles.Text = "Load";
                Globals.LogWriter(ExtractConsole, "Cleared all loaded files!");
            }
            else if (load == 0)
            {
                filenames = Globals.OpenFileDialog();
                if (filenames.Length == 0)
                {
                    Globals.LogWriter(ExtractConsole, $"No file(s) loaded!");
                }
                else
                {
                    Globals.LogWriter(ExtractConsole, $"Loaded {filenames.Length} file(s)!");
                    load++; LoadFiles.Text = "Clear";
                }
            }
        }

        private void CustomRegexTxt_OnValueChanged(object sender, EventArgs e)
        {

        }
    }
}
