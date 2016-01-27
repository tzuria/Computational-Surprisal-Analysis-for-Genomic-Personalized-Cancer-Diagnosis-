namespace FinalProject
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.tbSVDTable = new System.Windows.Forms.DataGridView();
            this.inputDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cmdShowSVD = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbSVDTable)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.button1.Location = new System.Drawing.Point(118, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Brows";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.browsButtonClick);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(12, 23);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(100, 20);
            this.txtFilePath.TabIndex = 1;
            // 
            // tbSVDTable
            // 
            this.tbSVDTable.AllowUserToOrderColumns = true;
            this.tbSVDTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbSVDTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.tbSVDTable.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tbSVDTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tbSVDTable.Location = new System.Drawing.Point(12, 97);
            this.tbSVDTable.Name = "tbSVDTable";
            this.tbSVDTable.Size = new System.Drawing.Size(665, 188);
            this.tbSVDTable.TabIndex = 2;
            // 
            // inputDataBindingSource
            // 
            this.inputDataBindingSource.DataSource = typeof(FinalProject.InputData);
            // 
            // cmdShowSVD
            // 
            this.cmdShowSVD.Location = new System.Drawing.Point(13, 58);
            this.cmdShowSVD.Name = "cmdShowSVD";
            this.cmdShowSVD.Size = new System.Drawing.Size(99, 30);
            this.cmdShowSVD.TabIndex = 4;
            this.cmdShowSVD.Text = "Show SVD";
            this.cmdShowSVD.UseVisualStyleBackColor = true;
            this.cmdShowSVD.Click += new System.EventHandler(this.cmdShowSVD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 461);
            this.Controls.Add(this.cmdShowSVD);
            this.Controls.Add(this.tbSVDTable);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbSVDTable)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputDataBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.DataGridView tbSVDTable;
        private System.Windows.Forms.BindingSource inputDataBindingSource;
        private System.Windows.Forms.Button cmdShowSVD;
    }
}

