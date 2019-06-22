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
    public partial class SplitTab : UserControl
    {
        public static string[] filenames = new string[] { };

        private static int load, iterator, files;

        public SplitTab()
        {
            InitializeComponent();
            Globals.LogWriter(SplitConsole, "Waiting for user input...");
        }
        // for(int i = 0; i < 10,000 / 5, i++)
        
        private void StartProcess()
        {
            SplitConsole.Clear();
            int SplitAmount = 0; files = 0;
            try
            {
                SplitAmount = int.Parse(SplitAmountTxt.Text);
            }
            catch
            {
                Globals.LogWriter(SplitConsole, "Please put a valid number in the Split Amount Textbox!");
            }

            Globals.LogWriter(SplitConsole, "Splitting...");
            try
            {
                foreach (var file in filenames)
                {
                    var file_name = Path.GetFileNameWithoutExtension(file); iterator = 0;
                    using (StreamReader sr = new StreamReader(file))
                    {
                        StreamWriter writer = null;
                        try
                        {
                            using (StreamReader inputfile = new StreamReader(file))
                            {
                                int count = 0;
                                string line;
                                while ((line = inputfile.ReadLine()) != null)
                                {

                                    if (writer == null || count >= SplitAmount)
                                    {
                                        if (writer != null)
                                        {
                                            writer.Close();
                                            writer = null;
                                        }

                                        writer = new StreamWriter($"Output-Split-{file_name}_{iterator}.txt", true);
                                        iterator++; files++;
                                        count = 0;
                                    }

                                    if (count == SplitAmount - 1 || inputfile.Peek() == -1)
                                        writer.Write(line);
                                    else
                                        writer.WriteLine(line);

                                    count++;
                                }
                            }
                        }
                        finally
                        {
                            if (writer != null)
                                writer.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Globals.LogWriter(SplitConsole, $"ERROR: {e.Message}");
                Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load"; iterator = 0; files = 0;

            }

            Globals.LogWriter(SplitConsole, $"Splitted the file(s) into {files} parts");
            Globals.LogWriter(SplitConsole, "Splitted successfully...");
            Array.Clear(filenames, 0, filenames.Length); load--; LoadFiles.Text = "Load"; iterator = 0; files = 0;

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
                Globals.LogWriter(SplitConsole, "Cleared all loaded files!");
            }
            else if (load == 0)
            {
                filenames = Globals.OpenFileDialog();
                if (filenames.Length == 0)
                {
                    Globals.LogWriter(SplitConsole, $"No file(s) loaded!");
                }
                else
                {
                    Globals.LogWriter(SplitConsole, $"Loaded {filenames.Length} file(s)!");
                    load++; LoadFiles.Text = "Clear";
                }
            }
        }

    }
}
