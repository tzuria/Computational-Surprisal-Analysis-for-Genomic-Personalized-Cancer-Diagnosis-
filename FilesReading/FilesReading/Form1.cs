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
        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            string[] lines = new string[79];
            int i = 0;

            var outPutFile = @"C:\ProgramOutput\mRNAtemp1.csv";
            
            string[] filePaths = Directory.GetFiles(txtPath.Text+ @"\");

//            lines = System.IO.File.ReadAllLines(path);
            foreach (string file in filePaths)
            {
                
                    lines[i] = ParseFile(file);
                    i++;
            }

            File.WriteAllLines(outPutFile, lines);
            MessageBox.Show(string.Format("Your .CSV file was generated to : {0}", outPutFile));
        }

        private string ParseFile(string filePath)
        {
            string reader = "";
            string patianteGenesLevel = "";
            string geneExpressionPattern = "(\\S*)\\s*(?<geneCount>\\S*)";
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

            using (StreamReader lineReader = new StreamReader(fileStream))
            {
                reader = lineReader.ReadLine();
                while ((reader = lineReader.ReadLine()) != null)
                {
                    patianteGenesLevel += Regex.Match(reader, geneExpressionPattern).Groups["geneCount"].Value + ",";
                }
            }
            return patianteGenesLevel.Substring(0,patianteGenesLevel.Length-1);
        }
    }
}
