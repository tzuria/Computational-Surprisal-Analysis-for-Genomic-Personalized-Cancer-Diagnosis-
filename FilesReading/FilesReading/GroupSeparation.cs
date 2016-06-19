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
using System.Xml;
using FinalProjectPrototype;

namespace FilesReading
{
    public partial class GroupSeparation : Form
    {
        string clinicalDataPath;
        string resultsPath;
        public GroupSeparation()
        {
            InitializeComponent();
            listBoxValues.Visible = false;
            cmdGenerateFile.Visible = false;
            resultsPath = @"C:\Users\tzuria\results\";
            cmdGenerateComparison.Visible = false;
        }

        //first value:txtfile. second value: sample id
        List<SampleData> sampleData;


        private void cmdMapFile_Click(object sender, EventArgs e)
        {
            sampleData = new List<SampleData>();
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                txtMapPath.Text = dialog.FileName;
                FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate);
                createDictionary(fs);
            }

            //generate separated values
            clinicalDataPath = Regex.Match(dialog.FileName,@"(.*\\)FILE_SAMPLE_MAP.txt").Groups[1].Value + @"Clinical\XML";
            generateSeparetedValues(clinicalDataPath);
            
        }

        private void generateSeparetedValues(string path)
        {
            string[] filePaths = Directory.GetFiles(path + @"\");
            XmlDocument doc = new XmlDocument();
            doc.Load(filePaths[0]);
            // cycle through each child noed 
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                if (node.Name.StartsWith("admin:"))
                    continue;
                // first node is the url ... have to go to nexted loc node 
                foreach (XmlNode locNode in node)
                {
                    if (locNode.Name.StartsWith("admin:"))
                        continue;
                    if (locNode.ChildNodes.Count < 2)
                        cmbSeparatedValues.Items.Add(locNode.Name);
                    else
                    {
                        foreach (XmlNode loclocNode in locNode)
                        {
                            if (loclocNode.Name.StartsWith("admin:"))
                                continue;
                            if (loclocNode.ChildNodes.Count < 2)
                                cmbSeparatedValues.Items.Add(loclocNode.Name);
                            else
                            {
                                foreach(XmlNode locloclocNode in loclocNode)
                                {
                                    if (locloclocNode.ChildNodes.Count < 2)
                                        cmbSeparatedValues.Items.Add(locloclocNode.Name);
                                }
                            }
                        }
                    }
                }
            }
        }


        private void createDictionary(FileStream fs)
        {
            string line;

            using (StreamReader lineReader = new StreamReader(fs))
            {
                line = lineReader.ReadLine();
                while ((line = lineReader.ReadLine()) != null)
                {
                    if (line != "")
                    {
                        Match match = Regex.Match(line, @"(?<txtFile>\S*)(\s*)(?<sampleID>\S*)");
                        if (match.Groups["txtFile"].Value.Contains("genes.normalized_results"))
                        {
                            SampleData newSampleData = new SampleData();
                            newSampleData.TxtFile = match.Groups["txtFile"].Value;
                            newSampleData.SampleID = match.Groups["sampleID"].Value;
                            sampleData.Add(newSampleData);
                        }
                    }
                }
            }
        }

        
        private void addToMAP(XmlNode node,string filePath)
        {
            SampleData newSampleData = new SampleData();
            foreach (SampleData data in sampleData)
            {
                string SampleIDShort = Regex.Match(data.SampleID,@"TCGA-\S{2}-\S{4}").Value;
                if (filePath.Contains(SampleIDShort))
                {
                    data.Value = node.InnerText;
                    listBoxValues.Items.Add(data.Value);
                }
            }
        }

        private void cmbSeparatedValues_SelectedValueChanged(object sender, EventArgs e)
        {
            string selectedItem = cmbSeparatedValues.SelectedItem.ToString();
            string[] filePaths = Directory.GetFiles(clinicalDataPath + @"\");
            listBoxValues.Visible = true;
            listBoxValues.Items.Clear();
            cmdGenerateFile.Visible = true;
            foreach (string filePath in filePaths)
            {
                if(!filePath.EndsWith(".xml"))
                {
                    continue;
                }
                XmlDocument doc = new XmlDocument();
                doc.Load(filePath);

                // cycle through each child noed 
                foreach (XmlNode node in doc.DocumentElement.ChildNodes)
                {
                    if (node.Name.StartsWith("admin:"))
                        continue;
                    // first node is the url ... have to go to nexted loc node 
                    foreach (XmlNode locNode in node)
                    {
                        if (locNode.Name.StartsWith("admin:"))
                            continue;
                        if (locNode.Name == selectedItem)
                            addToMAP(locNode,filePath);
                        else
                        {
                            foreach (XmlNode loclocNode in locNode)
                            {
                                if (loclocNode.Name.StartsWith("admin:"))
                                    continue;
                                if (loclocNode.Name == selectedItem)
                                    addToMAP(loclocNode,filePath);
                                else
                                {
                                    foreach (XmlNode locloclocNode in loclocNode)
                                    {
                                        if (locloclocNode.Name == selectedItem)
                                            addToMAP(locloclocNode,filePath);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private void cmdGenerateFile_Click(object sender, EventArgs e)
        {
            //deleting old files
            string[] filePaths = Directory.GetFiles(resultsPath);
            string[] directories = Directory.GetDirectories(resultsPath);

            foreach (string file in filePaths)
            {
                File.Delete(file);
            }

            foreach (string directory in directories)
            {
                filePaths = Directory.GetFiles(directory);
                foreach (string file in filePaths)
                {
                    File.Delete(file);
                }
                Directory.Delete(directory);
            }

            string rootPath = Regex.Match(clinicalDataPath, @"(.*)Clinical.*").Groups[1].Value;
            string fullPath = rootPath + @"RNASeqV2\UNC__IlluminaHiSeq_RNASeqV2\Level_3";

            string newFolderPath = "";
            foreach(SampleData sample in sampleData)
            {
                if (sample.Value != null)
                {
                    newFolderPath = System.IO.Path.Combine(@"C:\Users\tzuria\results", sample.Value);
                    System.IO.Directory.CreateDirectory(newFolderPath);
                    string sourceFile = fullPath + @"\" + sample.TxtFile;
                    string targetFile = newFolderPath + @"\" + Regex.Match(sample.TxtFile, @"(unc.edu.\S{8}-\S{4}-\S{4}-\S{4}-\S{13})(.*)").Groups[2].Value;
                    System.IO.Directory.CreateDirectory(newFolderPath);
                    try
                    {
                        System.IO.File.Copy(sourceFile, targetFile);
                    }
                    catch (DirectoryNotFoundException ex)
                    {

                        fullPath = rootPath + @"RNASeqV2\UNC__IlluminaGA_RNASeqV2\Level_3";
                        sourceFile = fullPath + @"\" + sample.TxtFile;
                        System.IO.File.Copy(sourceFile, targetFile);
                    }
                }

            }

            string txtFilePath = "C:\\Users\\tzuria\\results\\" + cmbSeparatedValues.SelectedItem.ToString().Replace(":","_") + ".txt";
            File.Create(txtFilePath);

            cmdGenerateComparison.Visible = true;
            
            
        }

        private void generateGraphs()
        {
            string[] filePaths = Directory.GetDirectories(resultsPath);
            InputData[] subGroups = new InputData[4];
            string[] descriptions = new string[]{"","","",""};
            int i = 0;
            foreach (string filePath in filePaths)
            {
                subGroups[i] = new InputData(new FileStream(filePath + "\\outPut.csv",FileMode.OpenOrCreate));
                descriptions[i] = Regex.Match(filePath, @"(.*)\\([^\\]*)").Groups[2].Value;
                i++;
            }

            for (int j = 0; j < 10; j++)
            {
                new Graph(subGroups, j, descriptions).Show();
            }
          
        }

        private void generateCSV()
        {

            string[] filePaths = Directory.GetDirectories(resultsPath);
            GenerateCSVFromDataFiles csvGeneretor = new GenerateCSVFromDataFiles();

            foreach (string filePath in filePaths)
            {
                csvGeneretor.txtPath.Text = filePath;
                csvGeneretor.cmdBrowse_Click(null, null);
            }
        }

        private void cmdGenerateComparison_Click(object sender, EventArgs e)
        {
            generateCSV();

            generateGraphs();
        }
    }
}
