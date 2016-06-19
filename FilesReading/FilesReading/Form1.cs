using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilesReading
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form groupSeparation = new GroupSeparation();
            groupSeparation.Show();
            this.Close();
        }

       
        private void cmdTransposeCSV_Click(object sender, EventArgs e)
        {
            Form transposeCSV = new TransposeCSV();
            transposeCSV.Show();
        }

        private void cmdGenesDataToCSVGenerator_Click(object sender, EventArgs e)
        {
            Form CSVGenerator = new GenerateCSVFromDataFiles();
            CSVGenerator.Show();
        }

        private void cmdGroupSeparation_Click(object sender, EventArgs e)
        {
            Form groupSeparation = new GroupSeparation();
            groupSeparation.Show();
        }

    }
}
