using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProjectPrototype
{
    public partial class Form1 : Form
    {
        public const int OPTIONAL_DATA_INSERT = 4;
        int numOfActiveData;
        int[] dataInsert;
        public Form1()
        {
            InitializeComponent();
            
            dataInsert = new int[OPTIONAL_DATA_INSERT];
            numOfActiveData = 0;

            #region set components unvisiable...
            txtClinicalDataDescription2.Visible = false;
            txtClinicalDataDescription3.Visible = false;
            txtClinicalDataDescription4.Visible = false;

            txtUploadCSV2.Visible = false;
            txtUploadCSV3.Visible = false;
            txtUploadCSV4.Visible = false;

            cmdAdd2.Visible = false;
            cmdAdd3.Visible = false;
            cmdAdd4.Visible = false;

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

        private void cmdAdd2_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdAdd3_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdAdd4_Click(object sender, EventArgs e)
        {
            
        }

        private void cmdAddDataClick(object sender, EventArgs e)
        {

        }

        private void cmdBrowse1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {

                txtUploadCSV1.Text = dialog.FileName; // get name of file
            }
        }

        private void cmdBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {

                txtUploadCSV2.Text = dialog.FileName; // get name of file
            }
        }

        private void cmdBrowse3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {

                txtUploadCSV3.Text = dialog.FileName; // get name of file
            }
        }

        private void cmdBrowse4_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {

                txtUploadCSV4.Text = dialog.FileName; // get name of file
            }
        }

        private void cmdGenerateGraph_Click(object sender, EventArgs e)
        {
            if (cmbLamdaChoose.SelectedIndex == -1)
            {
                MessageBox.Show("You didnt choose Lamda to compare with", "Error");
                return;
            }
            Form graph = new Graph();
            graph.Show();
            
        }

        private void cmdAddGroup_Click(object sender, EventArgs e)
        {
            numOfActiveData++;
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
                    cmdAdd2.Visible = true;
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
                    cmdAdd3.Visible = true;
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
                    cmdAdd4.Visible = true;
                    lblClinicalData4.Visible = true;
                    #endregion
                    break;
            }
        }

        
    }
}
