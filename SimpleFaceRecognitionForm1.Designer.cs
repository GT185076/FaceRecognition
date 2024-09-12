
namespace SimpleFaceRecognitionApp
{
    partial class SimpleFaceRecognitionForm1
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
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.btnCapture = new System.Windows.Forms.Button();
            this.btnDetectObject = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.btnTrainImage = new System.Windows.Forms.Button();
            this.btnAddPerson = new System.Windows.Forms.Button();
            this.btnRecognaizeImages = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.picGrayResult = new System.Windows.Forms.PictureBox();
            this.picFound = new System.Windows.Forms.PictureBox();
            this.trackBarThreshHoldDistance = new System.Windows.Forms.TrackBar();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnClearDb = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFound)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshHoldDistance)).BeginInit();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.Location = new System.Drawing.Point(0, 15);
            this.picCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(1104, 794);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // btnCapture
            // 
            this.btnCapture.Location = new System.Drawing.Point(1111, 11);
            this.btnCapture.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Size = new System.Drawing.Size(267, 44);
            this.btnCapture.TabIndex = 1;
            this.btnCapture.Text = "1. Capture";
            this.btnCapture.UseVisualStyleBackColor = true;
            this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
            // 
            // btnDetectObject
            // 
            this.btnDetectObject.Location = new System.Drawing.Point(1111, 60);
            this.btnDetectObject.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDetectObject.Name = "btnDetectObject";
            this.btnDetectObject.Size = new System.Drawing.Size(267, 44);
            this.btnDetectObject.TabIndex = 2;
            this.btnDetectObject.Text = "2. Detect Object";
            this.btnDetectObject.UseVisualStyleBackColor = true;
            this.btnDetectObject.Click += new System.EventHandler(this.btnDetectFaces_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // txtPersonName
            // 
            this.txtPersonName.Enabled = false;
            this.txtPersonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPersonName.Location = new System.Drawing.Point(1113, 443);
            this.txtPersonName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(267, 27);
            this.txtPersonName.TabIndex = 4;
            // 
            // btnTrainImage
            // 
            this.btnTrainImage.Location = new System.Drawing.Point(1114, 525);
            this.btnTrainImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnTrainImage.Name = "btnTrainImage";
            this.btnTrainImage.Size = new System.Drawing.Size(263, 44);
            this.btnTrainImage.TabIndex = 5;
            this.btnTrainImage.Text = "4. Train Image";
            this.btnTrainImage.UseVisualStyleBackColor = true;
            this.btnTrainImage.Click += new System.EventHandler(this.btnTrainImage_Click);
            // 
            // btnAddPerson
            // 
            this.btnAddPerson.Location = new System.Drawing.Point(1110, 143);
            this.btnAddPerson.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAddPerson.Name = "btnAddPerson";
            this.btnAddPerson.Size = new System.Drawing.Size(268, 44);
            this.btnAddPerson.TabIndex = 6;
            this.btnAddPerson.Text = "3. Add Person";
            this.btnAddPerson.UseVisualStyleBackColor = true;
            this.btnAddPerson.Click += new System.EventHandler(this.btnAddPerson_Click);
            // 
            // btnRecognaizeImages
            // 
            this.btnRecognaizeImages.Enabled = false;
            this.btnRecognaizeImages.Location = new System.Drawing.Point(1113, 575);
            this.btnRecognaizeImages.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnRecognaizeImages.Name = "btnRecognaizeImages";
            this.btnRecognaizeImages.Size = new System.Drawing.Size(267, 44);
            this.btnRecognaizeImages.TabIndex = 7;
            this.btnRecognaizeImages.Text = "5. Recognaize Person";
            this.btnRecognaizeImages.UseVisualStyleBackColor = true;
            this.btnRecognaizeImages.Click += new System.EventHandler(this.btnRecognaizeImages_Click);
            // 
            // picDetected
            // 
            this.picDetected.Location = new System.Drawing.Point(1113, 192);
            this.picDetected.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(200, 200);
            this.picDetected.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picDetected.TabIndex = 8;
            this.picDetected.TabStop = false;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(1114, 477);
            this.btnSave.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(129, 44);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picGrayResult
            // 
            this.picGrayResult.Location = new System.Drawing.Point(1110, 624);
            this.picGrayResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picGrayResult.Name = "picGrayResult";
            this.picGrayResult.Size = new System.Drawing.Size(133, 123);
            this.picGrayResult.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picGrayResult.TabIndex = 10;
            this.picGrayResult.TabStop = false;
            // 
            // picFound
            // 
            this.picFound.Location = new System.Drawing.Point(1246, 624);
            this.picFound.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picFound.Name = "picFound";
            this.picFound.Size = new System.Drawing.Size(133, 123);
            this.picFound.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFound.TabIndex = 11;
            this.picFound.TabStop = false;
            // 
            // trackBarThreshHoldDistance
            // 
            this.trackBarThreshHoldDistance.Location = new System.Drawing.Point(1113, 753);
            this.trackBarThreshHoldDistance.Margin = new System.Windows.Forms.Padding(4);
            this.trackBarThreshHoldDistance.Maximum = 10000;
            this.trackBarThreshHoldDistance.Minimum = 1000;
            this.trackBarThreshHoldDistance.Name = "trackBarThreshHoldDistance";
            this.trackBarThreshHoldDistance.Size = new System.Drawing.Size(268, 56);
            this.trackBarThreshHoldDistance.TabIndex = 12;
            this.trackBarThreshHoldDistance.Value = 4500;
            this.trackBarThreshHoldDistance.Scroll += new System.EventHandler(this.trackBarThreshHoldDistance_Scroll);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Faces",
            "Eyes",
            "Hands"});
            this.comboBox1.Location = new System.Drawing.Point(1114, 109);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(263, 24);
            this.comboBox1.TabIndex = 13;
            this.comboBox1.Text = "Faces";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnClearDb
            // 
            this.btnClearDb.Location = new System.Drawing.Point(1246, 477);
            this.btnClearDb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClearDb.Name = "btnClearDb";
            this.btnClearDb.Size = new System.Drawing.Size(129, 44);
            this.btnClearDb.TabIndex = 14;
            this.btnClearDb.Text = "Clear DB";
            this.btnClearDb.UseVisualStyleBackColor = true;
            this.btnClearDb.Click += new System.EventHandler(this.btnClearDb_Click);
            // 
            // SimpleFaceRecognitionForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 817);
            this.Controls.Add(this.btnClearDb);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.picFound);
            this.Controls.Add(this.picGrayResult);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btnRecognaizeImages);
            this.Controls.Add(this.btnAddPerson);
            this.Controls.Add(this.btnTrainImage);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.btnDetectObject);
            this.Controls.Add(this.btnCapture);
            this.Controls.Add(this.picCapture);
            this.Controls.Add(this.trackBarThreshHoldDistance);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "SimpleFaceRecognitionForm1";
            this.Text = "Simple Face Recognition";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SimpleFaceRecognitionForm1_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFound)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThreshHoldDistance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.Button btnCapture;
        private System.Windows.Forms.Button btnDetectObject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Button btnTrainImage;
        private System.Windows.Forms.Button btnAddPerson;
        private System.Windows.Forms.Button btnRecognaizeImages;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picGrayResult;
        private System.Windows.Forms.PictureBox picFound;
        private System.Windows.Forms.TrackBar trackBarThreshHoldDistance;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnClearDb;
    }
}

