﻿namespace GIFConverter
{
    partial class GIFConverterForm
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
            this.LoadGIFButton = new System.Windows.Forms.Button();
            this.GIFPictureBox = new System.Windows.Forms.PictureBox();
            this.PicturePreviewsSplitContainer = new System.Windows.Forms.SplitContainer();
            this.WoWTexturePictureBox = new System.Windows.Forms.PictureBox();
            this.ConvertOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.makeTransparentButton = new System.Windows.Forms.Button();
            this.saveTextureButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.trimEndButton = new System.Windows.Forms.Button();
            this.removeFramesFromStartButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.ToWoWTextureButton = new System.Windows.Forms.Button();
            this.GIFPropertyTreeView = new System.Windows.Forms.TreeView();
            this.currentFrameLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.GIFPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicturePreviewsSplitContainer)).BeginInit();
            this.PicturePreviewsSplitContainer.Panel1.SuspendLayout();
            this.PicturePreviewsSplitContainer.Panel2.SuspendLayout();
            this.PicturePreviewsSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.WoWTexturePictureBox)).BeginInit();
            this.ConvertOptionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadGIFButton
            // 
            this.LoadGIFButton.Location = new System.Drawing.Point(12, 12);
            this.LoadGIFButton.Name = "LoadGIFButton";
            this.LoadGIFButton.Size = new System.Drawing.Size(75, 23);
            this.LoadGIFButton.TabIndex = 0;
            this.LoadGIFButton.Text = "Load GIF";
            this.LoadGIFButton.UseVisualStyleBackColor = true;
            this.LoadGIFButton.Click += new System.EventHandler(this.LoadGIFButton_Click);
            // 
            // GIFPictureBox
            // 
            this.GIFPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.GIFPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GIFPictureBox.Location = new System.Drawing.Point(0, 0);
            this.GIFPictureBox.Name = "GIFPictureBox";
            this.GIFPictureBox.Size = new System.Drawing.Size(388, 262);
            this.GIFPictureBox.TabIndex = 1;
            this.GIFPictureBox.TabStop = false;
            this.GIFPictureBox.Click += new System.EventHandler(this.GIFPictureBox_Click);
            // 
            // PicturePreviewsSplitContainer
            // 
            this.PicturePreviewsSplitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PicturePreviewsSplitContainer.Location = new System.Drawing.Point(0, 188);
            this.PicturePreviewsSplitContainer.Name = "PicturePreviewsSplitContainer";
            // 
            // PicturePreviewsSplitContainer.Panel1
            // 
            this.PicturePreviewsSplitContainer.Panel1.Controls.Add(this.GIFPictureBox);
            // 
            // PicturePreviewsSplitContainer.Panel2
            // 
            this.PicturePreviewsSplitContainer.Panel2.Controls.Add(this.WoWTexturePictureBox);
            this.PicturePreviewsSplitContainer.Size = new System.Drawing.Size(800, 262);
            this.PicturePreviewsSplitContainer.SplitterDistance = 388;
            this.PicturePreviewsSplitContainer.TabIndex = 2;
            // 
            // WoWTexturePictureBox
            // 
            this.WoWTexturePictureBox.BackColor = System.Drawing.Color.Transparent;
            this.WoWTexturePictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WoWTexturePictureBox.Location = new System.Drawing.Point(0, 0);
            this.WoWTexturePictureBox.Name = "WoWTexturePictureBox";
            this.WoWTexturePictureBox.Size = new System.Drawing.Size(408, 262);
            this.WoWTexturePictureBox.TabIndex = 0;
            this.WoWTexturePictureBox.TabStop = false;
            // 
            // ConvertOptionsGroupBox
            // 
            this.ConvertOptionsGroupBox.Controls.Add(this.makeTransparentButton);
            this.ConvertOptionsGroupBox.Controls.Add(this.saveTextureButton);
            this.ConvertOptionsGroupBox.Controls.Add(this.button3);
            this.ConvertOptionsGroupBox.Controls.Add(this.trimEndButton);
            this.ConvertOptionsGroupBox.Controls.Add(this.removeFramesFromStartButton);
            this.ConvertOptionsGroupBox.Controls.Add(this.button1);
            this.ConvertOptionsGroupBox.Controls.Add(this.ToWoWTextureButton);
            this.ConvertOptionsGroupBox.Location = new System.Drawing.Point(256, 12);
            this.ConvertOptionsGroupBox.Name = "ConvertOptionsGroupBox";
            this.ConvertOptionsGroupBox.Size = new System.Drawing.Size(170, 144);
            this.ConvertOptionsGroupBox.TabIndex = 4;
            this.ConvertOptionsGroupBox.TabStop = false;
            this.ConvertOptionsGroupBox.Text = "Convert Options";
            // 
            // makeTransparentButton
            // 
            this.makeTransparentButton.Location = new System.Drawing.Point(6, 86);
            this.makeTransparentButton.Name = "makeTransparentButton";
            this.makeTransparentButton.Size = new System.Drawing.Size(156, 23);
            this.makeTransparentButton.TabIndex = 6;
            this.makeTransparentButton.Text = "Transparent Range";
            this.makeTransparentButton.UseVisualStyleBackColor = true;
            this.makeTransparentButton.Click += new System.EventHandler(this.makeTransparentButton_Click);
            // 
            // saveTextureButton
            // 
            this.saveTextureButton.Location = new System.Drawing.Point(87, 115);
            this.saveTextureButton.Name = "saveTextureButton";
            this.saveTextureButton.Size = new System.Drawing.Size(75, 23);
            this.saveTextureButton.TabIndex = 5;
            this.saveTextureButton.Text = "Save";
            this.saveTextureButton.UseVisualStyleBackColor = true;
            this.saveTextureButton.Click += new System.EventHandler(this.saveTextureButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(6, 48);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 35);
            this.button3.TabIndex = 4;
            this.button3.Text = "Remove Frame";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // trimEndButton
            // 
            this.trimEndButton.Location = new System.Drawing.Point(87, 19);
            this.trimEndButton.Name = "trimEndButton";
            this.trimEndButton.Size = new System.Drawing.Size(75, 23);
            this.trimEndButton.TabIndex = 3;
            this.trimEndButton.Text = "Trim End";
            this.trimEndButton.UseVisualStyleBackColor = true;
            this.trimEndButton.Click += new System.EventHandler(this.trimEndButton_Click);
            // 
            // removeFramesFromStartButton
            // 
            this.removeFramesFromStartButton.Location = new System.Drawing.Point(6, 19);
            this.removeFramesFromStartButton.Name = "removeFramesFromStartButton";
            this.removeFramesFromStartButton.Size = new System.Drawing.Size(75, 23);
            this.removeFramesFromStartButton.TabIndex = 2;
            this.removeFramesFromStartButton.Text = "Trim Start";
            this.removeFramesFromStartButton.UseVisualStyleBackColor = true;
            this.removeFramesFromStartButton.Click += new System.EventHandler(this.removeFramesFromStartButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(87, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Crop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ToWoWTextureButton
            // 
            this.ToWoWTextureButton.Location = new System.Drawing.Point(6, 115);
            this.ToWoWTextureButton.Name = "ToWoWTextureButton";
            this.ToWoWTextureButton.Size = new System.Drawing.Size(75, 23);
            this.ToWoWTextureButton.TabIndex = 0;
            this.ToWoWTextureButton.Text = "To Texture";
            this.ToWoWTextureButton.UseVisualStyleBackColor = true;
            this.ToWoWTextureButton.Click += new System.EventHandler(this.ToWoWTextureButton_Click);
            // 
            // GIFPropertyTreeView
            // 
            this.GIFPropertyTreeView.Location = new System.Drawing.Point(93, 12);
            this.GIFPropertyTreeView.Name = "GIFPropertyTreeView";
            this.GIFPropertyTreeView.Size = new System.Drawing.Size(157, 144);
            this.GIFPropertyTreeView.TabIndex = 5;
            // 
            // currentFrameLabel
            // 
            this.currentFrameLabel.AutoSize = true;
            this.currentFrameLabel.Location = new System.Drawing.Point(9, 154);
            this.currentFrameLabel.Name = "currentFrameLabel";
            this.currentFrameLabel.Size = new System.Drawing.Size(76, 13);
            this.currentFrameLabel.TabIndex = 6;
            this.currentFrameLabel.Text = "Current Frame:";
            // 
            // GIFConverterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.currentFrameLabel);
            this.Controls.Add(this.GIFPropertyTreeView);
            this.Controls.Add(this.ConvertOptionsGroupBox);
            this.Controls.Add(this.PicturePreviewsSplitContainer);
            this.Controls.Add(this.LoadGIFButton);
            this.Name = "GIFConverterForm";
            this.Text = "GIF Converter";
            ((System.ComponentModel.ISupportInitialize)(this.GIFPictureBox)).EndInit();
            this.PicturePreviewsSplitContainer.Panel1.ResumeLayout(false);
            this.PicturePreviewsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PicturePreviewsSplitContainer)).EndInit();
            this.PicturePreviewsSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.WoWTexturePictureBox)).EndInit();
            this.ConvertOptionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadGIFButton;
        private System.Windows.Forms.PictureBox GIFPictureBox;
        private System.Windows.Forms.SplitContainer PicturePreviewsSplitContainer;
        private System.Windows.Forms.GroupBox ConvertOptionsGroupBox;
        private System.Windows.Forms.TreeView GIFPropertyTreeView;
        private System.Windows.Forms.HScrollBar GIFPositionScrollBar;
        private System.Windows.Forms.Button ToWoWTextureButton;
        private System.Windows.Forms.PictureBox WoWTexturePictureBox;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button trimEndButton;
        private System.Windows.Forms.Button removeFramesFromStartButton;
        private System.Windows.Forms.Label currentFrameLabel;
        private System.Windows.Forms.Button saveTextureButton;
        private System.Windows.Forms.Button makeTransparentButton;
    }
}

