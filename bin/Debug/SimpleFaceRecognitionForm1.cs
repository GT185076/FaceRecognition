using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;
using Emgu.CV.Face;
using Emgu.CV.CvEnum;
using System.IO;
using System.Threading;
using System.Media;
using System.Diagnostics;

namespace SimpleFaceRecognitionApp
{
    public partial class SimpleFaceRecognitionForm1 : Form
    {
        #region varibables

        Capture videoCapture = null;
        Image<Bgr, Byte> currentFrame = null;
        Mat frame = new Mat();
        bool faceDetectionEnable = false;
        CascadeClassifier Classifier;
        bool enabelSaveImages = false;
        int imagesCount = 0;
        DateTime lastImageTakenTS = DateTime.Now;
        string imageNameTaken = string.Empty;
        string trainedImagesDirectory =  Path.Combine(Directory.GetCurrentDirectory(), "TrainedImages");
        bool isTrained = false;
        EigenFaceRecognizer recognizer;       
        Dictionary<int,string> personsDb = new Dictionary<int,string>();
        bool recognize = false;
        double threshHold = 4500;
        double detectScale = 1.1;
        string NameFound = string.Empty;

        #endregion

        public SimpleFaceRecognitionForm1()
        {
            InitializeComponent();
            btnCapture_Click(null, null);
            comboBox1_SelectedIndexChanged(null, null);
            btnDetectFaces_Click(null, null);
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (videoCapture == null)
            {
                videoCapture = new Capture();
                videoCapture.ImageGrabbed += ProcessFrames;
                videoCapture.Start();
            }

        }

        void stopCapture()
        {
            if (videoCapture != null)
            {
                videoCapture.Stop();
                videoCapture.ImageGrabbed -= ProcessFrames;
                videoCapture.Dispose();
                videoCapture = null;
            }
        }

        private void ProcessFrames(object sender, EventArgs e)
        {
            // step 1 : video capture 
            videoCapture.Retrieve(frame, 0);
            currentFrame = frame.ToImage<Bgr, Byte>().Resize(picCapture.Width, picCapture.Height,Inter.Cubic);
            // step 2  : detect faces 
            if  (faceDetectionEnable)
            {
                // convert from Bgr to Image
                Mat grayImage = new Mat();
                CvInvoke.CvtColor(currentFrame, grayImage, ColorConversion.Bgr2Gray);
                // enhance the image to get better result
                CvInvoke.EqualizeHist(grayImage, grayImage);
                Rectangle[] faces = Classifier.DetectMultiScale(grayImage, detectScale, 3, Size.Empty, Size.Empty);
                // if faces is detected ..
                if (faces.Length>0 )
                {
                   foreach ( var face in faces)
                    {
                        // draw face around the faces
                        CvInvoke.Rectangle(currentFrame, face, new Bgr(Color.Red).MCvScalar, 2);
                        // Step 3: Add person 

                        // Assign the face into the pic detected.
                        Image<Bgr, byte> resultImage = currentFrame.Convert<Bgr, byte>();
                        resultImage.ROI = face;

                        if (btnSave.Enabled)
                        {
                            picDetected.SizeMode = PictureBoxSizeMode.StretchImage;
                            picDetected.Image = resultImage.Bitmap;

                            if (enabelSaveImages)
                            {
                                // Save 10 images  with delay a second for each images.
                                // to avoid GUI delay we will use tasks.

                                if ((DateTime.Now - lastImageTakenTS) < new TimeSpan(0, 0, 0, 1)) return;

                                // we will cretate a directory if not exist.
                                
                                if (!Directory.Exists(trainedImagesDirectory))
                                    Directory.CreateDirectory(trainedImagesDirectory);

                                this.Invoke(new Action(advancePicture));
                                
                                string finalName = Path.Combine(trainedImagesDirectory, txtPersonName.Text +".bmp");
                                
                                new Task(()=> resultImage.Resize(200, 200, Inter.Cubic).Save(finalName)).Start();

                                if (imagesCount > 9) 
                                    this.Invoke(new Action(stopSave));                                

                                lastImageTakenTS = DateTime.Now;
                            }
                        }

                        if (isTrained && recognize)
                        {
                            Image<Gray, Byte> grayFaceResult = resultImage.Convert<Gray, Byte>().Resize(200, 200, Inter.Cubic);
                            CvInvoke.EqualizeHist(grayFaceResult, grayFaceResult);
                            var result = recognizer.Predict(grayFaceResult);

                            this.Invoke(new Action(() =>
                            {
                                try
                                {
                                    picGrayResult.Image = grayFaceResult.Bitmap;
                                }
                                catch { }
                            }));

                            // Debug.WriteLine("Result:" + result.Label + ", Distance:" + result.Distance );

                            if (result.Label>=0 && result.Distance< threshHold)
                            {
                                string value;
                                string personName = string.Empty;
                                string imageName = string.Empty;

                                personsDb.TryGetValue(result.Label, out value);
                                if (string.IsNullOrWhiteSpace(value))
                                {
                                    personName = "Unknow";
                                }
                                else
                                {
                                    personName = value.Split(',')[0];
                                    imageName = value.Split(',')[1];
                                }

                                this.Invoke(new Action(() =>
                                {
                                    var pic = new Image<Gray, Byte>(imageName);
                                    CvInvoke.PutText(pic, personName,
                                               new Point(0,pic.Size.Height-10),
                                               FontFace.HersheyComplex, 1,
                                               new Bgr(Color.Black).MCvScalar);

                                    if (NameFound != personName)
                                    {
                                        SystemSounds.Beep.Play();
                                        NameFound = personName;
                                    }

                                    picFound.Image =  pic.Bitmap;                                   

                                }));

                                CvInvoke.PutText(currentFrame,personName,
                                                new Point(face.X - 2, face.Y - 2),
                                                FontFace.HersheyComplex, 1.0,
                                                new Bgr(Color.Orange).MCvScalar);
                                
                            }
                            else
                            {
                                CvInvoke.PutText(currentFrame,"Unknow Face",
                                                new Point(face.X - 2, face.Y - 2), 
                                                FontFace.HersheyComplex,1.0,
                                                new Bgr(Color.Orange).MCvScalar);
                            }

                        }
                    }
                }
            }
            // render the videon capture into the picture 
            picCapture.Image = currentFrame.Bitmap;
        }

        private void btnDetectFaces_Click(object sender, EventArgs e)
        {
            faceDetectionEnable = true;
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            btnAddPerson.Enabled = false;          
            enabelSaveImages = false;
            btnSave.Enabled = true;
            txtPersonName.Text = "PersonName";
            txtPersonName.Enabled = true;
            imagesCount = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            if (string.IsNullOrEmpty(txtPersonName.Text))
            {
                MessageBox.Show("You must enter a person name !", "Error");
                return;
            }
            btnAddPerson.Enabled = false;
            enabelSaveImages = true;
            imageNameTaken = txtPersonName.Text;
        }

        private void stopSave()
        {
            btnAddPerson.Enabled = true;
            enabelSaveImages = false;
            btnSave.Enabled = false;
            txtPersonName.Enabled = true;
        }

        private void advancePicture()
        {
            txtPersonName.Text =  imageNameTaken +"_"+ imagesCount.ToString();
            SystemSounds.Beep.Play();
            imagesCount++;
        }

        private bool TrainImageFromDir()
        {
            imagesCount = 0;
            List<Image<Gray, Byte>> trainedFaces = new List<Image<Gray, byte>>();
            personsDb.Clear();

            try
            {
                string[] imagesfiles = Directory.GetFiles(trainedImagesDirectory);
                foreach ( var imageFile in imagesfiles)
                {
                    string personName = Path.GetFileNameWithoutExtension(imageFile).Split('_')[0];
                    Image<Gray, Byte> trainedImage = new Image<Gray, Byte>(imageFile);
                    trainedFaces.Add(trainedImage);
                    personsDb.Add(imagesCount,personName+","+imageFile);                    
                    imagesCount++;
                }
                recognizer = new EigenFaceRecognizer(imagesCount,threshHold);
                recognizer.Train(trainedFaces.ToArray(),personsDb.Keys.ToArray());
                SystemSounds.Asterisk.Play();
                btnRecognaizeImages.Enabled = true;
                return isTrained = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in Train Images:" + ex.Message);
                return isTrained = false;
            }
        }

        private void btnTrainImage_Click(object sender, EventArgs e)
        {
            isTrained = TrainImageFromDir();
        }

        private void btnRecognaizeImages_Click(object sender, EventArgs e)
        {
            faceDetectionEnable = true;
            recognize = true;
        }

        private void trackBarThreshHoldDistance_Scroll(object sender, EventArgs e)
        {
            var tb = sender as TrackBar;
            threshHold = (int)tb?.Value;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string value = string.Empty;

            if (sender == null)
                value = comboBox1.Text;
            else
                value = ((ComboBox)sender).Text;

            if (value == "Faces")
            {
                Classifier = new CascadeClassifier("haarcascade_frontalface_alt.xml");
                detectScale = 1.1;
            }
            if (value == "Eyes")
            {
                Classifier = new CascadeClassifier("haarcascade_eye.xml");
                detectScale = 2.2;
            }
            if (value == "Hands")
            {
                Classifier = new CascadeClassifier("haarcascade_hand.xml");
                detectScale = 1.6;
            }
        }

        private void btnClearDb_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Are you sure ?", "Delete All taken Images");

            if (answer == DialogResult.OK)
            {
                string[] imagesfiles = Directory.GetFiles(trainedImagesDirectory);
                foreach (var imageFile in imagesfiles)
                {
                    System.IO.File.Delete(imageFile);
                }
            }
        }

        private void SimpleFaceRecognitionForm1_FormClosing(object sender, FormClosingEventArgs e)
        {            
            faceDetectionEnable = false;            
            stopSave();
            stopCapture();
            Thread.Sleep(2000);
        }
    }
}
