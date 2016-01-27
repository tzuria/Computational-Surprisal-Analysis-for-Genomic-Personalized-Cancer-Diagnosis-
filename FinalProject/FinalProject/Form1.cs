using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
       private InputData data;
       private DataTable SVDData;
        private DataTable covData;

        public Form1()
        {
            InitializeComponent();
            tbSVDTable.Visible = false;

        }

       
        private void browsButtonClick(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Text files | *.csv"; // file types, that will be allowed to upload
            dialog.Multiselect = false; // allow/deny user to upload more than one file at a time
            if (dialog.ShowDialog() == DialogResult.OK) // if user clicked OK
            {

                string path = dialog.FileName; // get name of file

                //lines = System.IO.File.ReadAllLines(path);
                txtFilePath.Text = path;
                FileStream fs = new FileStream(path, FileMode.OpenOrCreate);
                data = new InputData(fs);
            }
        }

        private void cmdShowSVD_Click(object sender, EventArgs e)
        {
            SVDData = data.getLagrangeDatatable();

            tbSVDTable.RowCount = SVDData.Rows.Count;
            tbSVDTable.ColumnCount = SVDData.Columns.Count;

            for (int i = 0; i < SVDData.Columns.Count; i++)
            {
                for (int j = 0; j < SVDData.Rows.Count; j++)
                {
                    tbSVDTable[i, j].Value = SVDData.Rows[j][i];
                }
            }

            tbSVDTable.Show();
        }

    }
}
