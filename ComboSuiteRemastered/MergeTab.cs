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

namespace ComboSuiteRemastered
{
    public partial class MergeTab : UserControl
    {
        public static string[] filenames = new string[] { };

        private static int load;
        public MergeTab()
        {
            InitializeComponent();
            Globals.LogWriter(MergeConsole, "Waiting for user input...");
        }

        private void StartProcess()
        {
            MergeConsole.Clear();
            try
            {
                const int chunkSize = 2 * 1024;
                Globals.LogWriter(MergeConsole, "Merging files...");
                using (var output_file = File.Create(OutputFileTxt.Text))
                {
                    foreach (var file in filenames)
                    {
                        using (var input = File.OpenRead(file))
                        {
                            var buff = new byte[chunkSize];
                            int bytesRead;

                            while ((bytesRead = input.Read(buff, 0, buff.Length)) > 0)
                            {
                                output_file.Write(buff, 0, bytesRead);
                            }
                        }
                    }
                }
                Globals.LogWriter(MergeConsole, $"Merged {filenames.Length} files into {OutputFileTxt.Text}");
                Globals.LogWriter(MergeConsole, "Merge successful...");
                Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load";
            }
            catch (Exception e)
            {
                Globals.LogWriter(MergeConsole, $"ERROR: {e.Message}");
                Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load";
            }
            
            
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
                Globals.LogWriter(MergeConsole, "Cleared all loaded files!");
            }
            else if (load == 0)
            {
                filenames = Globals.OpenFileDialog();
                if (filenames.Length == 0)
                {
                    Globals.LogWriter(MergeConsole, $"No file(s) loaded!");
                }
                else
                {
                    Globals.LogWriter(MergeConsole, $"Loaded {filenames.Length} file(s)!");
                    load++; LoadFiles.Text = "Clear";
                }
            }
        }
    }
}
