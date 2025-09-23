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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.loadBtn2 = new System.Windows.Forms.Button();
            this.subtractBtn = new System.Windows.Forms.Button();
            this.toggleWebcamBtn = new System.Windows.Forms.Button();
            this.startProcessingBtn = new System.Windows.Forms.Button();
            this.captureFrameBtn = new System.Windows.Forms.Button();
            this.webcamDevicesComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedPicBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // originalPicBox
            // 
            this.originalPicBox.Location = new System.Drawing.Point(12, 127);
            this.originalPicBox.Name = "originalPicBox";
            this.originalPicBox.Size = new System.Drawing.Size(518, 308);
            this.originalPicBox.TabIndex = 0;
            this.originalPicBox.TabStop = false;
            // 
            // editedPicBox
            // 
            this.editedPicBox.Location = new System.Drawing.Point(12, 455);
            this.editedPicBox.Name = "editedPicBox";
            this.editedPicBox.Size = new System.Drawing.Size(518, 308);
            this.editedPicBox.TabIndex = 1;
            this.editedPicBox.TabStop = false;
            // 
            // loadBtn
            // 
            this.loadBtn.Location = new System.Drawing.Point(12, 7);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(167, 54);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load Image A";
            this.loadBtn.UseVisualStyleBackColor = true;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.Location = new System.Drawing.Point(553, 627);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(175, 54);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save image";
            this.saveBtn.UseVisualStyleBackColor = true;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.Location = new System.Drawing.Point(734, 468);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(165, 54);
            this.copyBtn.TabIndex = 4;
            this.copyBtn.Text = "Basic Copy";
            this.copyBtn.UseVisualStyleBackColor = true;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // grayBtn
            // 
            this.grayBtn.Location = new System.Drawing.Point(915, 468);
            this.grayBtn.Name = "grayBtn";
            this.grayBtn.Size = new System.Drawing.Size(165, 54);
            this.grayBtn.TabIndex = 5;
            this.grayBtn.Text = "Grayscale";
            this.grayBtn.UseVisualStyleBackColor = true;
            this.grayBtn.Click += new System.EventHandler(this.grayBtn_Click);
            // 
            // invertBtn
            // 
            this.invertBtn.Location = new System.Drawing.Point(553, 468);
            this.invertBtn.Name = "invertBtn";
            this.invertBtn.Size = new System.Drawing.Size(165, 54);
            this.invertBtn.TabIndex = 6;
            this.invertBtn.Text = "Color Inversion";
            this.invertBtn.UseVisualStyleBackColor = true;
            this.invertBtn.Click += new System.EventHandler(this.invertBtn_Click);
            // 
            // histogramBtn
            // 
            this.histogramBtn.Location = new System.Drawing.Point(734, 528);
            this.histogramBtn.Name = "histogramBtn";
            this.histogramBtn.Size = new System.Drawing.Size(165, 54);
            this.histogramBtn.TabIndex = 7;
            this.histogramBtn.Text = "Histogram";
            this.histogramBtn.UseVisualStyleBackColor = true;
            this.histogramBtn.Click += new System.EventHandler(this.histogramBtn_Click);
            // 
            // sepiaBtn
            // 
            this.sepiaBtn.Location = new System.Drawing.Point(553, 528);
            this.sepiaBtn.Name = "sepiaBtn";
            this.sepiaBtn.Size = new System.Drawing.Size(165, 54);
            this.sepiaBtn.TabIndex = 8;
            this.sepiaBtn.Text = "Sepia";
            this.sepiaBtn.UseVisualStyleBackColor = true;
            this.sepiaBtn.Click += new System.EventHandler(this.sepiaBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(553, 127);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(518, 308);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // loadBtn2
            // 
            this.loadBtn2.Location = new System.Drawing.Point(551, 67);
            this.loadBtn2.Name = "loadBtn2";
            this.loadBtn2.Size = new System.Drawing.Size(167, 54);
            this.loadBtn2.TabIndex = 10;
            this.loadBtn2.Text = "Load Image B";
            this.loadBtn2.UseVisualStyleBackColor = true;
            this.loadBtn2.Click += new System.EventHandler(this.loadBtn2_Click);
            // 
            // subtractBtn
            // 
            this.subtractBtn.Location = new System.Drawing.Point(915, 528);
            this.subtractBtn.Name = "subtractBtn";
            this.subtractBtn.Size = new System.Drawing.Size(165, 54);
            this.subtractBtn.TabIndex = 11;
            this.subtractBtn.Text = "Subtract";
            this.subtractBtn.UseVisualStyleBackColor = true;
            this.subtractBtn.Click += new System.EventHandler(this.subtractBtn_Click);
            // 
            // toggleWebcamBtn
            // 
            this.toggleWebcamBtn.Location = new System.Drawing.Point(193, 7);
            this.toggleWebcamBtn.Name = "toggleWebcamBtn";
            this.toggleWebcamBtn.Size = new System.Drawing.Size(167, 54);
            this.toggleWebcamBtn.TabIndex = 12;
            this.toggleWebcamBtn.Text = "Start/Stop Webcam";
            this.toggleWebcamBtn.UseVisualStyleBackColor = true;
            this.toggleWebcamBtn.Click += new System.EventHandler(this.toggleWebcamBtn_Click);
            // 
            // startProcessingBtn
            // 
            this.startProcessingBtn.Location = new System.Drawing.Point(193, 67);
            this.startProcessingBtn.Name = "startProcessingBtn";
            this.startProcessingBtn.Size = new System.Drawing.Size(337, 54);
            this.startProcessingBtn.TabIndex = 16;
            this.startProcessingBtn.Text = "Start/Stop Green Screen Processing";
            this.startProcessingBtn.UseVisualStyleBackColor = true;
            // 
            // captureFrameBtn
            // 
            this.captureFrameBtn.Location = new System.Drawing.Point(373, 7);
            this.captureFrameBtn.Name = "captureFrameBtn";
            this.captureFrameBtn.Size = new System.Drawing.Size(157, 54);
            this.captureFrameBtn.TabIndex = 17;
            this.captureFrameBtn.Text = "Capture Frame";
            this.captureFrameBtn.UseVisualStyleBackColor = true;
            this.captureFrameBtn.Click += new System.EventHandler(this.captureFrameBtn_Click);
            // 
            // webcamDevicesComboBox
            // 
            this.webcamDevicesComboBox.FormattingEnabled = true;
            this.webcamDevicesComboBox.Location = new System.Drawing.Point(12, 93);
            this.webcamDevicesComboBox.Name = "webcamDevicesComboBox";
            this.webcamDevicesComboBox.Size = new System.Drawing.Size(167, 28);
            this.webcamDevicesComboBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 789);
            this.Controls.Add(this.webcamDevicesComboBox);
            this.Controls.Add(this.captureFrameBtn);
            this.Controls.Add(this.startProcessingBtn);
            this.Controls.Add(this.toggleWebcamBtn);
            this.Controls.Add(this.subtractBtn);
            this.Controls.Add(this.loadBtn2);
            this.Controls.Add(this.pictureBox2);
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
            this.Load += new System.EventHandler(this.Form1_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.originalPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedPicBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button loadBtn2;
        private System.Windows.Forms.Button subtractBtn;
        private System.Windows.Forms.Button toggleWebcamBtn;
        private System.Windows.Forms.Button startProcessingBtn;
        private System.Windows.Forms.Button captureFrameBtn;
        private System.Windows.Forms.ComboBox webcamDevicesComboBox;
    }
}

