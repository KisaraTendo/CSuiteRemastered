using System;
using System.Collections.Generic;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboSuiteRemastered
{
    public class DuplicateGlobal
    {
        public static bool SaveToEachFile, SaveDuplicates, UseRefFiles;
        public static int Duplicates;
    }


    public class ExtractGlobal
    {
        public static bool EmailOnly, CustomRegex;
        public static int Extracted;
    }

    public class MiscGlobal
    {
        public static bool EmailPassToUserPass;
    }

    public class Globals
    {
        public static DupeTab dupeTab = new DupeTab();
        public static ExtractTab extractTab = new ExtractTab();
        public static SplitTab splitTab = new SplitTab();
        public static MergeTab mergeTab = new MergeTab();
        public static MiscTab miscTab = new MiscTab();


        public static void LogWriter(TextBox txtbox, string text)
        {
            txtbox.ReadOnly = true;
            txtbox.AppendText($"[{DateTime.UtcNow}] {text}" + Environment.NewLine);
        }


        public static string[] OpenFileDialog()
        {
            string[] files = new string[] { };
            OpenFileDialog ofd = new OpenFileDialog()
            {
                CheckFileExists = true,
                Title = "Please choose your text file(s)",
                CheckPathExists = true,
                Filter = "TXT FILES (*.txt)|*.txt",
                Multiselect = true
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                files = ofd.FileNames;
            }
            return files;
        }
    }

    
}
