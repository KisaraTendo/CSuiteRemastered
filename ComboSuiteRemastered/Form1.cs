using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComboSuiteRemastered
{
    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
            
        }


        private void AddPanel(UserControl control)
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(control);
        }


        private void DuplicatesTab_Click(object sender, EventArgs e)
        {
            AddPanel(Globals.dupeTab);
        }

        private void ExtractTab_Click(object sender, EventArgs e)
        {
            AddPanel(Globals.extractTab);
        }

        private void CloseBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MinimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void SplitTab_Click(object sender, EventArgs e)
        {
            AddPanel(Globals.splitTab);
        }

        private void MergeTab_Click(object sender, EventArgs e)
        {
            AddPanel(Globals.mergeTab);
        }

        private void MiscTab_Click(object sender, EventArgs e)
        {
            AddPanel(Globals.miscTab);
        }
    }
}
