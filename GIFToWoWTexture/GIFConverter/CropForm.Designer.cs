namespace GIFConverter
{
    partial class CropForm
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
            this.CropPictureBox = new System.Windows.Forms.PictureBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.CropAreaSizeGroupBox = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.maxSizeButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.cropButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CropPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.CropAreaSizeGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CropPictureBox
            // 
            this.CropPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.CropPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CropPictureBox.Location = new System.Drawing.Point(0, 0);
            this.CropPictureBox.Name = "CropPictureBox";
            this.CropPictureBox.Size = new System.Drawing.Size(800, 391);
            this.CropPictureBox.TabIndex = 0;
            this.CropPictureBox.TabStop = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.CropPictureBox);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.CropAreaSizeGroupBox);
            this.splitContainer1.Panel2.Controls.Add(this.cancelButton);
            this.splitContainer1.Panel2.Controls.Add(this.cropButton);
            this.splitContainer1.Size = new System.Drawing.Size(800, 450);
            this.splitContainer1.SplitterDistance = 391;
            this.splitContainer1.TabIndex = 1;
            // 
            // CropAreaSizeGroupBox
            // 
            this.CropAreaSizeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CropAreaSizeGroupBox.Controls.Add(this.textBox1);
            this.CropAreaSizeGroupBox.Controls.Add(this.maxSizeButton);
            this.CropAreaSizeGroupBox.Location = new System.Drawing.Point(504, 3);
            this.CropAreaSizeGroupBox.Name = "CropAreaSizeGroupBox";
            this.CropAreaSizeGroupBox.Size = new System.Drawing.Size(160, 48);
            this.CropAreaSizeGroupBox.TabIndex = 2;
            this.CropAreaSizeGroupBox.TabStop = false;
            this.CropAreaSizeGroupBox.Text = "Crop Area Size";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(6, 20);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // maxSizeButton
            // 
            this.maxSizeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.maxSizeButton.Location = new System.Drawing.Point(112, 20);
            this.maxSizeButton.Name = "maxSizeButton";
            this.maxSizeButton.Size = new System.Drawing.Size(37, 20);
            this.maxSizeButton.TabIndex = 0;
            this.maxSizeButton.Text = "Max";
            this.maxSizeButton.UseVisualStyleBackColor = true;
            this.maxSizeButton.Click += new System.EventHandler(this.maxSizeButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(3, 2);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(127, 49);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // cropButton
            // 
            this.cropButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cropButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.cropButton.Location = new System.Drawing.Point(670, 3);
            this.cropButton.Name = "cropButton";
            this.cropButton.Size = new System.Drawing.Size(127, 49);
            this.cropButton.TabIndex = 0;
            this.cropButton.Text = "Crop";
            this.cropButton.UseVisualStyleBackColor = true;
            this.cropButton.Click += new System.EventHandler(this.cropButton_Click);
            // 
            // CropForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CropForm";
            this.Text = "CropForm";
            ((System.ComponentModel.ISupportInitialize)(this.CropPictureBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.CropAreaSizeGroupBox.ResumeLayout(false);
            this.CropAreaSizeGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CropPictureBox;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button cropButton;
        private System.Windows.Forms.GroupBox CropAreaSizeGroupBox;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button maxSizeButton;
    }
}