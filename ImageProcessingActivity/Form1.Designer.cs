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
            this.originalPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalPicBox.Location = new System.Drawing.Point(12, 130);
            this.originalPicBox.Name = "originalPicBox";
            this.originalPicBox.Size = new System.Drawing.Size(518, 308);
            this.originalPicBox.TabIndex = 0;
            this.originalPicBox.TabStop = false;
            // 
            // editedPicBox
            // 
            this.editedPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.editedPicBox.Location = new System.Drawing.Point(12, 465);
            this.editedPicBox.Name = "editedPicBox";
            this.editedPicBox.Size = new System.Drawing.Size(518, 308);
            this.editedPicBox.TabIndex = 1;
            this.editedPicBox.TabStop = false;
            // 
            // loadBtn
            // 
            this.loadBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.loadBtn.FlatAppearance.BorderSize = 0;
            this.loadBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBtn.ForeColor = System.Drawing.Color.White;
            this.loadBtn.Location = new System.Drawing.Point(12, 12);
            this.loadBtn.Name = "loadBtn";
            this.loadBtn.Size = new System.Drawing.Size(167, 45);
            this.loadBtn.TabIndex = 2;
            this.loadBtn.Text = "Load Image A";
            this.loadBtn.UseVisualStyleBackColor = false;
            this.loadBtn.Click += new System.EventHandler(this.loadBtn_Click);
            // 
            // saveBtn
            // 
            this.saveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.saveBtn.FlatAppearance.BorderSize = 0;
            this.saveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveBtn.ForeColor = System.Drawing.Color.White;
            this.saveBtn.Location = new System.Drawing.Point(904, 690);
            this.saveBtn.Name = "saveBtn";
            this.saveBtn.Size = new System.Drawing.Size(167, 45);
            this.saveBtn.TabIndex = 3;
            this.saveBtn.Text = "Save Image";
            this.saveBtn.UseVisualStyleBackColor = false;
            this.saveBtn.Click += new System.EventHandler(this.saveBtn_Click);
            // 
            // copyBtn
            // 
            this.copyBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.copyBtn.FlatAppearance.BorderSize = 0;
            this.copyBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyBtn.ForeColor = System.Drawing.Color.White;
            this.copyBtn.Location = new System.Drawing.Point(553, 468);
            this.copyBtn.Name = "copyBtn";
            this.copyBtn.Size = new System.Drawing.Size(165, 40);
            this.copyBtn.TabIndex = 4;
            this.copyBtn.Text = "Basic Copy";
            this.copyBtn.UseVisualStyleBackColor = false;
            this.copyBtn.Click += new System.EventHandler(this.copyBtn_Click);
            // 
            // grayBtn
            // 
            this.grayBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.grayBtn.FlatAppearance.BorderSize = 0;
            this.grayBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.grayBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grayBtn.ForeColor = System.Drawing.Color.White;
            this.grayBtn.Location = new System.Drawing.Point(734, 468);
            this.grayBtn.Name = "grayBtn";
            this.grayBtn.Size = new System.Drawing.Size(165, 40);
            this.grayBtn.TabIndex = 5;
            this.grayBtn.Text = "Grayscale";
            this.grayBtn.UseVisualStyleBackColor = false;
            this.grayBtn.Click += new System.EventHandler(this.grayBtn_Click);
            // 
            // invertBtn
            // 
            this.invertBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.invertBtn.FlatAppearance.BorderSize = 0;
            this.invertBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.invertBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.invertBtn.ForeColor = System.Drawing.Color.White;
            this.invertBtn.Location = new System.Drawing.Point(915, 468);
            this.invertBtn.Name = "invertBtn";
            this.invertBtn.Size = new System.Drawing.Size(165, 40);
            this.invertBtn.TabIndex = 6;
            this.invertBtn.Text = "Color Inversion";
            this.invertBtn.UseVisualStyleBackColor = false;
            this.invertBtn.Click += new System.EventHandler(this.invertBtn_Click);
            // 
            // histogramBtn
            // 
            this.histogramBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.histogramBtn.FlatAppearance.BorderSize = 0;
            this.histogramBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.histogramBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.histogramBtn.ForeColor = System.Drawing.Color.White;
            this.histogramBtn.Location = new System.Drawing.Point(553, 528);
            this.histogramBtn.Name = "histogramBtn";
            this.histogramBtn.Size = new System.Drawing.Size(165, 40);
            this.histogramBtn.TabIndex = 7;
            this.histogramBtn.Text = "Histogram";
            this.histogramBtn.UseVisualStyleBackColor = false;
            this.histogramBtn.Click += new System.EventHandler(this.histogramBtn_Click);
            // 
            // sepiaBtn
            // 
            this.sepiaBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.sepiaBtn.FlatAppearance.BorderSize = 0;
            this.sepiaBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.sepiaBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sepiaBtn.ForeColor = System.Drawing.Color.White;
            this.sepiaBtn.Location = new System.Drawing.Point(734, 528);
            this.sepiaBtn.Name = "sepiaBtn";
            this.sepiaBtn.Size = new System.Drawing.Size(165, 40);
            this.sepiaBtn.TabIndex = 8;
            this.sepiaBtn.Text = "Sepia";
            this.sepiaBtn.UseVisualStyleBackColor = false;
            this.sepiaBtn.Click += new System.EventHandler(this.sepiaBtn_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox2.Location = new System.Drawing.Point(553, 130);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(518, 308);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // loadBtn2
            // 
            this.loadBtn2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.loadBtn2.FlatAppearance.BorderSize = 0;
            this.loadBtn2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadBtn2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loadBtn2.ForeColor = System.Drawing.Color.White;
            this.loadBtn2.Location = new System.Drawing.Point(553, 12);
            this.loadBtn2.Name = "loadBtn2";
            this.loadBtn2.Size = new System.Drawing.Size(167, 45);
            this.loadBtn2.TabIndex = 10;
            this.loadBtn2.Text = "Load Image B";
            this.loadBtn2.UseVisualStyleBackColor = false;
            this.loadBtn2.Click += new System.EventHandler(this.loadBtn2_Click);
            // 
            // subtractBtn
            // 
            this.subtractBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(160)))));
            this.subtractBtn.FlatAppearance.BorderSize = 0;
            this.subtractBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.subtractBtn.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.subtractBtn.ForeColor = System.Drawing.Color.White;
            this.subtractBtn.Location = new System.Drawing.Point(915, 528);
            this.subtractBtn.Name = "subtractBtn";
            this.subtractBtn.Size = new System.Drawing.Size(165, 40);
            this.subtractBtn.TabIndex = 11;
            this.subtractBtn.Text = "Subtract";
            this.subtractBtn.UseVisualStyleBackColor = false;
            this.subtractBtn.Click += new System.EventHandler(this.subtractBtn_Click);
            // 
            // toggleWebcamBtn
            // 
            this.toggleWebcamBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.toggleWebcamBtn.FlatAppearance.BorderSize = 0;
            this.toggleWebcamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.toggleWebcamBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toggleWebcamBtn.ForeColor = System.Drawing.Color.White;
            this.toggleWebcamBtn.Location = new System.Drawing.Point(195, 12);
            this.toggleWebcamBtn.Name = "toggleWebcamBtn";
            this.toggleWebcamBtn.Size = new System.Drawing.Size(167, 45);
            this.toggleWebcamBtn.TabIndex = 12;
            this.toggleWebcamBtn.Text = "Start/Stop Webcam";
            this.toggleWebcamBtn.UseVisualStyleBackColor = false;
            this.toggleWebcamBtn.Click += new System.EventHandler(this.toggleWebcamBtn_Click);
            // 
            // startProcessingBtn
            // 
            this.startProcessingBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.startProcessingBtn.FlatAppearance.BorderSize = 0;
            this.startProcessingBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startProcessingBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startProcessingBtn.ForeColor = System.Drawing.Color.White;
            this.startProcessingBtn.Location = new System.Drawing.Point(195, 66);
            this.startProcessingBtn.Name = "startProcessingBtn";
            this.startProcessingBtn.Size = new System.Drawing.Size(335, 45);
            this.startProcessingBtn.TabIndex = 16;
            this.startProcessingBtn.Text = "Start/Stop Green Screen Processing";
            this.startProcessingBtn.UseVisualStyleBackColor = false;
            // 
            // captureFrameBtn
            // 
            this.captureFrameBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.captureFrameBtn.FlatAppearance.BorderSize = 0;
            this.captureFrameBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.captureFrameBtn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.captureFrameBtn.ForeColor = System.Drawing.Color.White;
            this.captureFrameBtn.Location = new System.Drawing.Point(375, 12);
            this.captureFrameBtn.Name = "captureFrameBtn";
            this.captureFrameBtn.Size = new System.Drawing.Size(155, 45);
            this.captureFrameBtn.TabIndex = 17;
            this.captureFrameBtn.Text = "Capture Frame";
            this.captureFrameBtn.UseVisualStyleBackColor = false;
            this.captureFrameBtn.Click += new System.EventHandler(this.captureFrameBtn_Click);
            // 
            // webcamDevicesComboBox
            // 
            this.webcamDevicesComboBox.FormattingEnabled = true;
            this.webcamDevicesComboBox.Location = new System.Drawing.Point(12, 75);
            this.webcamDevicesComboBox.Name = "webcamDevicesComboBox";
            this.webcamDevicesComboBox.Size = new System.Drawing.Size(167, 28);
            this.webcamDevicesComboBox.TabIndex = 18;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1082, 783);
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
            this.Text = "Image Processing Studio";
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

