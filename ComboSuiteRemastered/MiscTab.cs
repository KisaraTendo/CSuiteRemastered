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
    public partial class MiscTab : UserControl
    {
        private static HashSet<string> List = new HashSet<string>();

        public static string[] filenames = new string[] { };

        private static int load;

        public MiscTab()
        {
            InitializeComponent();
            Globals.LogWriter(MiscConsole, "Waiting for user input...");
        }

        private void StartProcess()
        {
            MiscConsole.Clear(); List.Clear();
            Globals.LogWriter(MiscConsole, "Started process...");
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
                                    if (MiscGlobal.EmailPassToUserPass)
                                    {
                                        try
                                        {
                                            string[] FullLine = line.Split(':');
                                            string[] UserPart = FullLine[0].Split('@');

                                            string User = UserPart[0];
                                            string Pass = FullLine[1];

                                            List.Add($"{User}:{Pass}");
                                        }
                                        catch
                                        {
                                            
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
                Globals.LogWriter(MiscConsole, $"ERROR: {e.Message}");
                Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load"; 
            }
            File.AppendAllText(OutputFileTxt.Text, string.Join(Environment.NewLine, List));

            if (MiscGlobal.EmailPassToUserPass)
            {
                Globals.LogWriter(MiscConsole, $"Converted {List.Count} lines!");
                Globals.LogWriter(MiscConsole, "Converting successful...");
            }
            Globals.LogWriter(MiscConsole, $"Saved {List.Count} lines to {OutputFileTxt.Text}");

            Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load";
        }


        private void StartBtn_Click(object sender, EventArgs e)
        {
            Task t = Task.Factory.StartNew(() =>
            {
                StartProcess();
            });
        }

        private void LoadFiles_Click(object sender, EventArgs e)
        {
            if (load == 1)
            {
                Array.Clear(filenames, 0, filenames.Length);
                load--; LoadFiles.Text = "Load";
                Globals.LogWriter(MiscConsole, "Cleared all loaded files!");
            }
            else if (load == 0)
            {
                filenames = Globals.OpenFileDialog();
                if (filenames.Length == 0)
                {
                    Globals.LogWriter(MiscConsole, $"No file(s) loaded!");
                }
                else
                {
                    Globals.LogWriter(MiscConsole, $"Loaded {filenames.Length} file(s)!");
                    load++; LoadFiles.Text = "Clear";
                }
            }
        }

        private void EPtoUPSwitch_OnValueChange(object sender, EventArgs e)
        {
            if (EPtoUPSwitch.Value == true)
            {
                MiscGlobal.EmailPassToUserPass = true;
            }
            else if (EPtoUPSwitch.Value == false)
            {
                MiscGlobal.EmailPassToUserPass = false;
            }
        }
    }
}
