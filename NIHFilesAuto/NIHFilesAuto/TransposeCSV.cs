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
    public partial class TransposeCSV : Form
    {
        public TransposeCSV()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            
           FileStream fs = new FileStream(txtTransposeCSV.Text, FileMode.OpenOrCreate);
           Match outPutPath = Regex.Match(txtTransposeCSV.Text, @"(.*)(\\.*csv)");
           transposeCSV(fs,outPutPath.Groups[1].Value);
            
        }
        private void transposeCSV(FileStream fs,string outputfilePath)
        {
            List<List<string>> data = new List<List<string>>();
            string[] tempLine;
            string line;
            using (StreamReader lineReader = new StreamReader(fs))
            {
                while ((line = lineReader.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        tempLine = line.Split(',');
                        List<string> lineData = new List<string>();
                        for (int i = 0; i < tempLine.Length; i++)
                        {
                            lineData.Add(tempLine[i]);
                        }
                        data.Add(lineData);
                    }
                }
            }
            if (data.Count == 0)
            {
                return;
            }
            int index = 0;
            string[] outPutLines = new string[data[0].Count];
            for (int j = 0; j < outPutLines.Length; j++)
            {
                outPutLines[j] = "";
            }

            while (index < data[0].Count)
            {
                foreach (List<string> list in data)
                {
                    outPutLines[index] += (list[index] + ",");
                }
                outPutLines[index] = outPutLines[index].Remove(outPutLines[index].Length - 1);
                index++;
            }
            var outPutFile = outputfilePath + "\\outPut.csv";
            File.WriteAllLines(outPutFile, outPutLines);
            //MessageBox.Show(string.Format("Your .CSV file was generated to : {0}", outPutFile));
            this.Close();
        }
        
    }
}
