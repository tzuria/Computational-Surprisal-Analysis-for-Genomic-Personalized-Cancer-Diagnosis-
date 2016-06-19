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
using FilesReading;
//using FilesReading;

namespace FinalProjectPrototype
{
    public partial class Form1 : Form
    {
        int numOfActiveData;
        InputData[] inputData;
        OpenFileDialog dialog;
        string[] dataDescriptions;
        
        public Form1()
        {
            InitializeComponent();
            inputData = new InputData[Consts.OPTIONAL_DATA_INSERT];
            dataDescriptions = new string[Consts.OPTIONAL_DATA_INSERT];
            numOfActiveData = 0;
            #region set components unvisiable...
            txtClinicalDataDescription2.Visible = false;
            txtClinicalDataDescription3.Visible = false;
            txtClinicalDataDescription4.Visible = false;

            txtUploadCSV2.Visible = false;
            txtUploadCSV3.Visible = false;
            txtUploadCSV4.Visible = false;

            cmdBrowse2.Visible = false;
            cmdBrowse3.Visible = false;
            cmdBrowse4.Visible = false;

            lblClinicalData2.Visible = false;
            lblClinicalData3.Visible = false;
            lblClinicalData4.Visible = false;

            lblSubGroupColor2.Visible = false;
            lblSubGroupColor3.Visible = false;
            lblSubGroupColor4.Visible = false;

            cmdGenerateGraph.Visible = false;
            cmbLamdaChoose.Visible = false;

            lblLamdaChoosing.Visible = false;

            #endregion

        }

        private void cmdBrowse_Click(object sender, EventArgs e)
        {
            if (numOfActiveData == Consts.OPTIONAL_DATA_INSERT)
            {
                MessageBox.Show("No space for more data...");
                return;
            }
            dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {
                showPath(dialog.FileName);
                txtUploadCSV1.Text = dialog.FileName; // get name of file
                FileStream fs = new FileStream(dialog.FileName, FileMode.OpenOrCreate);
                inputData[numOfActiveData] = new InputData(fs);
                numOfActiveData++;
            }
        }
        private void showPath(String filePath)
        {
            switch (numOfActiveData)
            {
                case 0:
                    txtUploadCSV1.Text = filePath;
                    break;
                case 1:
                    txtUploadCSV2.Text = filePath;
                    break;
                case 2:
                    txtUploadCSV3.Text = filePath;
                    break;
                case 3:
                    txtUploadCSV4.Text = filePath;
                    break;
                default:
                    break;
            }

        }


        private void cmdGenerateGraph_Click(object sender, EventArgs e)
        {
            #region initialize data's descriptions
            dataDescriptions[0] = txtClinicalDataDescription1.Text;
            dataDescriptions[1] = txtClinicalDataDescription2.Text;
            dataDescriptions[2] = txtClinicalDataDescription3.Text;
            dataDescriptions[3] = txtClinicalDataDescription4.Text;
            #endregion
            if (cmbLamdaChoose.SelectedIndex == -1)
            {
                MessageBox.Show("You didnt choose Lamda to compare with", "Error");
                return;
            }
            Form graph = new Graph(inputData,cmbLamdaChoose.SelectedIndex,dataDescriptions);
            graph.Show();

            
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            if (numOfActiveData >= 4)
                return;
            switch (numOfActiveData)
            {
                case 1:
                    #region set components visiable
                    lblSubGroupColor2.Visible = true;
                    txtUploadCSV2.Visible = true;
                    txtClinicalDataDescription2.Visible = true;
                    cmdBrowse2.Visible = true;
                    txtClinicalDataDescription2.Visible = true;
                    lblClinicalData2.Visible = true;
                    cmdGenerateGraph.Visible = true;
                    cmbLamdaChoose.Visible = true;
                    lblLamdaChoosing.Visible = true;
                    #endregion
                    break;
                case 2:
                    #region set components visiable
                    lblSubGroupColor3.Visible = true;
                    txtUploadCSV3.Visible = true;
                    txtClinicalDataDescription3.Visible = true;
                    cmdBrowse3.Visible = true;
                    txtClinicalDataDescription3.Visible = true;
                    lblClinicalData3.Visible = true;
                    #endregion
                    break;
                case 3:
                    #region set components visiable
                    lblSubGroupColor4.Visible = true;
                    txtUploadCSV4.Visible = true;
                    txtClinicalDataDescription4.Visible = true;
                    cmdBrowse4.Visible = true;
                    txtClinicalDataDescription4.Visible = true;
                    lblClinicalData4.Visible = true;
                    #endregion
                    break;
            }
        }

        private void cmdNIHInput_Click(object sender, EventArgs e)
        {
            this.Hide();
            var NIHUpload = new GroupSeparation();
            NIHUpload.Closed += (s, args) => this.Close();
            NIHUpload.Show();
        }       
    }
}
