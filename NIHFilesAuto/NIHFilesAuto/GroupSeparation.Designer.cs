namespace NIHFilesAuto
{
    partial class GroupSeparation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtMapPath = new System.Windows.Forms.TextBox();
            this.lblMapPath = new System.Windows.Forms.Label();
            this.cmdMapFile = new System.Windows.Forms.Button();
            this.cmbSeparatedValues = new System.Windows.Forms.ComboBox();
            this.lblChoosingSeparateValue = new System.Windows.Forms.Label();
            this.listBoxValues = new System.Windows.Forms.ListBox();
            this.cmdGenerateFile = new System.Windows.Forms.Button();
            this.cmdGenerateComparison = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtMapPath
            // 
            this.txtMapPath.Location = new System.Drawing.Point(31, 28);
            this.txtMapPath.Name = "txtMapPath";
            this.txtMapPath.Size = new System.Drawing.Size(100, 20);
            this.txtMapPath.TabIndex = 0;
            // 
            // lblMapPath
            // 
            this.lblMapPath.AutoSize = true;
            this.lblMapPath.Location = new System.Drawing.Point(31, 9);
            this.lblMapPath.Name = "lblMapPath";
            this.lblMapPath.Size = new System.Drawing.Size(126, 13);
            this.lblMapPath.TabIndex = 1;
            this.lblMapPath.Text = "Choose the file\'s map file:";
            // 
            // cmdMapFile
            // 
            this.cmdMapFile.Location = new System.Drawing.Point(157, 26);
            this.cmdMapFile.Name = "cmdMapFile";
            this.cmdMapFile.Size = new System.Drawing.Size(75, 23);
            this.cmdMapFile.TabIndex = 2;
            this.cmdMapFile.Text = "Brows..";
            this.cmdMapFile.UseVisualStyleBackColor = true;
            this.cmdMapFile.Click += new System.EventHandler(this.cmdMapFile_Click);
            // 
            // cmbSeparatedValues
            // 
            this.cmbSeparatedValues.FormattingEnabled = true;
            this.cmbSeparatedValues.Location = new System.Drawing.Point(34, 97);
            this.cmbSeparatedValues.Name = "cmbSeparatedValues";
            this.cmbSeparatedValues.Size = new System.Drawing.Size(198, 21);
            this.cmbSeparatedValues.TabIndex = 3;
            this.cmbSeparatedValues.SelectedValueChanged += new System.EventHandler(this.cmbSeparatedValues_SelectedValueChanged);
            // 
            // lblChoosingSeparateValue
            // 
            this.lblChoosingSeparateValue.AutoSize = true;
            this.lblChoosingSeparateValue.Location = new System.Drawing.Point(31, 81);
            this.lblChoosingSeparateValue.Name = "lblChoosingSeparateValue";
            this.lblChoosingSeparateValue.Size = new System.Drawing.Size(136, 13);
            this.lblChoosingSeparateValue.TabIndex = 4;
            this.lblChoosingSeparateValue.Text = "choose the separate value:";
            // 
            // listBoxValues
            // 
            this.listBoxValues.FormattingEnabled = true;
            this.listBoxValues.Location = new System.Drawing.Point(34, 128);
            this.listBoxValues.Name = "listBoxValues";
            this.listBoxValues.Size = new System.Drawing.Size(218, 160);
            this.listBoxValues.TabIndex = 5;
            // 
            // cmdGenerateFile
            // 
            this.cmdGenerateFile.Location = new System.Drawing.Point(384, 203);
            this.cmdGenerateFile.Name = "cmdGenerateFile";
            this.cmdGenerateFile.Size = new System.Drawing.Size(104, 29);
            this.cmdGenerateFile.TabIndex = 6;
            this.cmdGenerateFile.Text = "Separate to folders";
            this.cmdGenerateFile.UseVisualStyleBackColor = true;
            this.cmdGenerateFile.Click += new System.EventHandler(this.cmdGenerateFile_Click);
            // 
            // cmdGenerateComparison
            // 
            this.cmdGenerateComparison.Location = new System.Drawing.Point(384, 253);
            this.cmdGenerateComparison.Name = "cmdGenerateComparison";
            this.cmdGenerateComparison.Size = new System.Drawing.Size(104, 35);
            this.cmdGenerateComparison.TabIndex = 7;
            this.cmdGenerateComparison.Text = "Generate comparison";
            this.cmdGenerateComparison.UseVisualStyleBackColor = true;
            this.cmdGenerateComparison.Click += new System.EventHandler(this.cmdGenerateComparison_Click);
            // 
            // GroupSeparation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 305);
            this.Controls.Add(this.cmdGenerateComparison);
            this.Controls.Add(this.cmdGenerateFile);
            this.Controls.Add(this.listBoxValues);
            this.Controls.Add(this.lblChoosingSeparateValue);
            this.Controls.Add(this.cmbSeparatedValues);
            this.Controls.Add(this.cmdMapFile);
            this.Controls.Add(this.lblMapPath);
            this.Controls.Add(this.txtMapPath);
            this.Name = "GroupSeparation";
            this.Text = "GroupSeparation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtMapPath;
        private System.Windows.Forms.Label lblMapPath;
        private System.Windows.Forms.Button cmdMapFile;
        private System.Windows.Forms.ComboBox cmbSeparatedValues;
        private System.Windows.Forms.Label lblChoosingSeparateValue;
        private System.Windows.Forms.ListBox listBoxValues;
        private System.Windows.Forms.Button cmdGenerateFile;
        private System.Windows.Forms.Button cmdGenerateComparison;
    }
}