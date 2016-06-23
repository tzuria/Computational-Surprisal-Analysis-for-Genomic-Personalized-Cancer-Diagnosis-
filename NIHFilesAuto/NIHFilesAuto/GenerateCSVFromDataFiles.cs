using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace NIHFilesAuto
{
    public partial class GenerateCSVFromDataFiles : Form
    {
        public GenerateCSVFromDataFiles()
        {
            InitializeComponent();
        }

        public void cmdBrowse_Click(object sender, EventArgs e)
        {
            string[] lines = new string[700];
            int i = 0;

;

            string[] filePaths = Directory.GetFiles(txtPath.Text + @"\");

            var outPutFile = txtPath.Text + @"\outPut.csv";

            foreach (string file in filePaths)
            {
                lines[i] = i + ",";
                lines[i] += ParseFile(file);
                i++;
            }

            File.WriteAllLines(outPutFile, lines);

            TransposeCSV csvTrans = new TransposeCSV();
            csvTrans.txtTransposeCSV.Text = outPutFile;
            csvTrans.button1_Click(null,null);
            this.Close();
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
            return patianteGenesLevel.Substring(0, patianteGenesLevel.Length - 1);
        }
    }
}
