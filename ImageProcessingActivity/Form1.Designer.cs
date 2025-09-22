namespace ImageProcessingActivity
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
            this.originalPicBox = new System.Windows.Forms.PictureBox();
            this.editedPicBox = new System.Windows.Forms.PictureBox();
            this.loadBtn = new System.Windows.Forms.Button();
            this.saveBtn = new System.Windows.Forms.Button();
            this.copyBtn = new System.Windows.Forms.Button();
            this.grayBtn = new System.Windows.Forms.Button();
            this.invertBtn = new System.Windows.Forms.Button();
            this.histogramBtn = new System.Windows.Forms.Button();
            this.sepiaBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedPicBox)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPicBox
            // 
            this.originalPicBox.Location = new System.Drawing.Point(12, 219);
            this.originalPicBox.Name = "originalPicBox";
            this.originalPicBox.Size = new System.Drawing.Size(654, 412);
            this.originalPicBox.TabIndex = 0;
            this.originalPicBox.TabStop = false;
            // 
            // editedPicBox
            // 
            this.editedPicBox.Location = new System.Drawing.Point(708, 219);
            this.editedPicBox.Name = "editedPicBox";
            this.editedPicBox.Size = new System.Drawing.Size(654, 412);
            this.editedPicBox.TabIndex = 1;
            this.editedPicBox.TabStop = false;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(29, 38);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(175, 54);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load image";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(231, 38);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(175, 54);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save image";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(29, 119);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(175, 54);
            this.copyBtn.TabIndex = 4;
            this.copyBtn.Text = "Basic Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // grayBtn
            // 
            this.grayBtn.Location = new System.Drawing.Point(231, 119);
            this.grayBtn.Name = "grayBtn";
            this.grayBtn.Size = new System.Drawing.Size(175, 54);
            this.grayBtn.TabIndex = 5;
            this.grayBtn.Text = "Grayscale";
            this.grayBtn.UseVisualStyleBackColor = true;
            this.grayBtn.Click += new System.EventHandler(this.grayBtn_Click);
            // 
            // invertBtn
            // 
            this.invertBtn.Location = new System.Drawing.Point(435, 119);
            this.invertBtn.Name = "invertBtn";
            this.invertBtn.Size = new System.Drawing.Size(175, 54);
            this.invertBtn.TabIndex = 6;
            this.invertBtn.Text = "Color Inversion";
            this.invertBtn.UseVisualStyleBackColor = true;
            this.invertBtn.Click += new System.EventHandler(this.invertBtn_Click);
            // 
            // histogramBtn
            // 
            this.histogramBtn.Location = new System.Drawing.Point(641, 119);
            this.histogramBtn.Name = "histogramBtn";
            this.histogramBtn.Size = new System.Drawing.Size(175, 54);
            this.histogramBtn.TabIndex = 7;
            this.histogramBtn.Text = "Histogram";
            this.histogramBtn.UseVisualStyleBackColor = true;
            this.histogramBtn.Click += new System.EventHandler(this.histogramBtn_Click);
            // 
            // sepiaBtn
            // 
            this.sepiaBtn.Location = new System.Drawing.Point(844, 119);
            this.sepiaBtn.Name = "sepiaBtn";
            this.sepiaBtn.Size = new System.Drawing.Size(175, 54);
            this.sepiaBtn.TabIndex = 8;
            this.sepiaBtn.Text = "Sepia";
            this.sepiaBtn.UseVisualStyleBackColor = true;
            this.sepiaBtn.Click += new System.EventHandler(this.sepiaBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 674);
            this.Controls.Add(this.sepiaBtn);
            this.Controls.Add(this.histogramBtn);
            this.Controls.Add(this.invertBtn);
            this.Controls.Add(this.grayBtn);
            this.Controls.Add(this.copyBtn);
            this.Controls.Add(this.saveBtn);
            this.Controls.Add(this.loadBtn);
            this.Controls.Add(this.editedPicBox);
            this.Controls.Add(this.originalPicBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedPicBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox originalPicBox;
        private System.Windows.Forms.PictureBox editedPicBox;
        private System.Windows.Forms.Button loadBtn;
        private System.Windows.Forms.Button saveBtn;
        private System.Windows.Forms.Button copyBtn;
        private System.Windows.Forms.Button grayBtn;
        private System.Windows.Forms.Button invertBtn;
        private System.Windows.Forms.Button histogramBtn;
        private System.Windows.Forms.Button sepiaBtn;
    }
}

