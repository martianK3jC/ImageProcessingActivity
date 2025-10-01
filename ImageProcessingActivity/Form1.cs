using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCamLib;

namespace ImageProcessingActivity
{
    public partial class Form1 : Form
    {
        private Device[] devices;
        private Device currentDevice; //Track Device
        private System.Windows.Forms.Timer webcamTimer;
        private bool isWebcamRunning = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize devices on form load
            RefreshDevices();

            // Setup timer
            webcamTimer = new System.Windows.Forms.Timer();
            webcamTimer.Interval = 100; // Update every 100ms
            webcamTimer.Tick += WebcamTimer_Tick;
        }

        #region Improved Device Management

        private void RefreshDevices()
        {
            try
            {
                devices = DeviceManager.GetAllDevices();

                // Clear and populate combo box if you have one
                if (webcamDevicesComboBox != null)
                {
                    webcamDevicesComboBox.Items.Clear();
                    foreach (Device device in devices)
                    {
                        webcamDevicesComboBox.Items.Add($"{device.Name} - {device.Version}");
                    }
                    if (devices.Length > 0)
                        webcamDevicesComboBox.SelectedIndex = 0;
                }

                MessageBox.Show($"Found {devices.Length} webcam device(s)\n" +
                               $"If you see a black screen, try:\n" +
                               $"1. Closing other apps using the webcam\n" +
                               $"2. Selecting a different device\n" +
                               $"3. Restarting the application");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error finding devices: {ex.Message}\n\n" +
                               $"Possible solutions:\n" +
                               $"1. Make sure webcam is connected\n" +
                               $"2. Install webcam drivers\n" +
                               $"3. Run as administrator");
            }
        }
        #endregion

        #region Helper method 
        //Helper method to apply filter safely.
        private void ApplyFilter(Func<Bitmap, bool> filterFunc) //Takes a function that applies filter to bitmap, returns bool
        {
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }

            if (originalPicBox.Image.Width < 3 || originalPicBox.Height < 3)
            {
                MessageBox.Show("Image is too small for filter!");
                return;
            }

            Bitmap processedBitmap = new Bitmap(originalPicBox.Image); //Makes copy of original image
            bool success = filterFunc(processedBitmap); //this calls the passed filter function

            if (success)
            {
                editedPicBox.Image = processedBitmap; //sets result to edited box
                editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            else
            {
                MessageBox.Show("Filter failed! Check matrix values.");
                processedBitmap.Dispose(); //frees memory if failed
            }
        }
        #endregion

        #region Load Image A Button
        //Loading an original picture to originalPicBox
        private void loadBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Create and configure the file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog(); // -> creation of a windows file picker dialog
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // -> restricts file types to common image formats. Format: Display Name|file patterns.... ex. name.png, etc chuchu
            openFileDialog.Title = "Select an Image File";

            //Step 2: Show the dialog and check if user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)//-> this shows the dialog and checks if user clicks OK
            {
                try
                {
                    //Step 3: Load the Selected Image
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);

                    //Step 4: Display it in the original picture box
                    originalPicBox.Image = selectedImage; // -> assigns image to picture box
                    originalPicBox.SizeMode = PictureBoxSizeMode.StretchImage; // -> StretchImage to make it fit the picture box
                }
                catch (Exception ex)
                {
                    //Step 5: Handle any errors (corrupted files, ect.)
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }
        #endregion

        #region Copy Button

        private void Copy(Bitmap src, Bitmap dst)
        {
            int srcHeight = src.Height;
            int srcWidth = src.Width;

            BitmapData bmLoaded = src.LockBits(
                new Rectangle(0, 0, srcWidth, srcHeight),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            BitmapData bmProcessed = dst.LockBits(
                new Rectangle(0, 0, dst.Width, dst.Height),
                ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

            unsafe
            {
                int offSet = bmLoaded.Stride - srcWidth * 3; // Padding value

                byte* pLoaded = (byte*)bmLoaded.Scan0;
                byte* pProcessed = (byte*)bmProcessed.Scan0;

                for (int i = 0; i < srcHeight; i++)
                {
                    for (int j = 0; j < srcWidth; j++)
                    {
                        pProcessed[0] = pLoaded[0];
                        pProcessed[1] = pLoaded[1];
                        pProcessed[2] = pLoaded[2];

                        pLoaded += 3;
                        pProcessed += 3;
                    }

                    pLoaded += offSet;
                    pProcessed += offSet;

                }
            }

            src.UnlockBits(bmLoaded);
            dst.UnlockBits(bmProcessed);
        }
        private void copyBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check if we have an image to copy
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }

            try
            {
                Bitmap loaded = new Bitmap(originalPicBox.Image);
                Bitmap processed = new Bitmap(loaded.Width, loaded.Height);

                Copy(loaded, processed);

                editedPicBox.Image = processed;
                editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error copying image: " + ex.Message);
            }
        }

        #endregion

        #region Grayscale Button
        private void grayBtn_Click(object sender, EventArgs e)
        {
            //Grayscale formula = (R + G + B) /3

            //Step 1: Check if we have an image to process
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }

            //Step 2: Convert to Bitmap for pixel manipulation
            Bitmap originalBitmap = new Bitmap(originalPicBox.Image);

            //Step 3: Create new Bitmap for grayscale result
            Bitmap grayscaleBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            //Step 4: Process each pixel
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    //Get original pixel color
                    Color originalColor = originalBitmap.GetPixel(x, y);

                    //Extract RGB values
                    int red = originalColor.R;
                    int green = originalColor.G;
                    int blue = originalColor.B;

                    //Create new gray color (same value for R, G, and B)
                    int grayValue = (red + green + blue) / 3;

                    //Create new gray color (same value for r, g, and b)
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);

                    //Set the gray pixel in the new bitmap
                    grayscaleBitmap.SetPixel(x, y, grayColor);
                }
            }

            //Step 5: Display the grayscale image
            editedPicBox.Image = grayscaleBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region invert Button
        private void invertBtn_Click(object sender, EventArgs e)
        {
            /*
             Formula for inverted:
                inverted red = 255 - r
                inverted green = 255 - G
                inverted blue = 255 - B
             */
            //Step 1: Check if we have an image to process
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }

            //Step 2: Conver to Bitmap for pixel manipulation
            Bitmap originalBitmap = new Bitmap(originalPicBox.Image);

            //Step 3: Create new bitmap for inverted result
            Bitmap invertedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            //Step 4: Process each pixel
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    //Get original pixel color
                    Color pixelColor = originalBitmap.GetPixel(x, y);

                    //Apply inversion formula
                    int inverted_red = 255 - pixelColor.R;
                    int inverted_green = 255 - pixelColor.G;
                    int inverted_blue = 255 - pixelColor.B;

                    //Create new inverted color
                    Color invertedColor = Color.FromArgb(inverted_red, inverted_green, inverted_blue);

                    //Set the inverted pixel in the new bitmap
                    invertedBitmap.SetPixel(x, y, invertedColor);
                }
            }

            //Step 5: Display the inverted image
            editedPicBox.Image = invertedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region Histogram Button
        private void histogramBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check if we have an image to analyze
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }

            // Step 2: Convert to Bitmap and prepare for processing
            Bitmap originalBitmap = new Bitmap(originalPicBox.Image);

            //Step 3: Create array to count pixels at each intensity level
            int[] histogram = new int[256]; // 256 possible grayscale values (0-255)

            //Step 4: Scan all pixels and count intensities
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    //Get pixel and convert to grayscale
                    Color pixelColor = originalBitmap.GetPixel(x, y);

                    //Extract RGB values
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;

                    //Create new gray color (same value for R, G, and B)
                    int grayValue = (red + green + blue) / 3;

                    //Increment the count for this gray level
                    histogram[grayValue]++; //-> count this brightness level
                }
            }

            //Step 5: Find maximum count for scaling the display
            int maxCount = 0;
            for (int i = 0; i < 256; i++)
            {
                if (histogram[i] > maxCount)
                    maxCount = histogram[i]; //-> this tracks the highest bar
            }

            //Step 6: Create bitmap to draw histogram (256 wide, 200 tall)
            Bitmap histogramBitmap = new Bitmap(256, 200);

            //Step 7: Draw the histogram bars
            for (int i = 0; i < 256; i++)
            {
                //Calculate bar height (scale to fit in 200 pixels)
                int barHeight = (int)((double)histogram[i] / maxCount * 180); //Leave 20 pixels padding -> scale to fit

                //Draw vertical line from bottom up
                for (int j = 199; j >= (199 - barHeight); j--) //-> draw from bottom up
                {
                    histogramBitmap.SetPixel(i, j, Color.Black);//-> draw bar pixel
                }
            }

            //Step 8: Display the histogram
            editedPicBox.Image = histogramBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region Sepia Button
        private void sepiaBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check if we have an image to process
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }

            //Step 2: Convert to Bitmap for pixel manipulation
            Bitmap originalBitmap = new Bitmap(originalPicBox.Image);

            //Step 3: Create new bitmap for sepia result
            Bitmap sepiaBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            //Step 4: Process each pixel
            for (int x = 0; x < originalBitmap.Width; x++)
            {
                for (int y = 0; y < originalBitmap.Height; y++)
                {
                    //Get original pixel color
                    Color pixelColor = originalBitmap.GetPixel(x, y);

                    //Extract RGB values
                    int red = pixelColor.R;
                    int green = pixelColor.G;
                    int blue = pixelColor.B;

                    //Apply sepia formulas
                    int outputRed = (int)((red * 0.393) + (green * 0.769) + (blue * 0.189));
                    int outputGreen = (int)((red * 0.349) + (green * 0.686) + (blue * 0.168));
                    int outputBlue = (int)((red * 0.272) + (green * 0.534) + (blue * 0.131));

                    //IMPORTANT: Clamp values to valid RGB range (0 - 255)
                    outputRed = Math.Min(255, outputRed);
                    outputGreen = Math.Min(255, outputGreen);
                    outputBlue = Math.Min(255, outputBlue);

                    //Create new sepia color
                    Color sepiaColor = Color.FromArgb(outputRed, outputGreen, outputBlue);

                    //Set the new sepia color
                    sepiaBitmap.SetPixel(x, y, sepiaColor);
                }
            }
            //Step 5: Display the sepia image
            editedPicBox.Image = sepiaBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

        #region Save Button
        private void saveBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check if there is a loaded image
            if (editedPicBox.Image == null)
            {
                MessageBox.Show("No Processed image to save! Please process an image first.");
                return;
            }

            //Step 2: Create and configure the save dialog
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|All Files|*.*";
            saveFileDialog.Title = "Save Processed Image";
            saveFileDialog.DefaultExt = "png"; //Default to PNG

            //Step 3: Show the dialog and check if user clicked Save
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    //Step 4: Get the image from the edited picture box
                    Image imageToSave = editedPicBox.Image;

                    //Step 5: Save the image to the selected file path
                    imageToSave.Save(saveFileDialog.FileName);

                    //Step 6: Show success message
                    MessageBox.Show($"HUZZAH! IMAGE SAVED SUCCESSFULLY TO:\n{saveFileDialog.FileName}");
                }
                catch (Exception ex)
                {
                    //Step 7: Handle any errors (permissions, disk space, etc.)
                    MessageBox.Show($"Error saving image: {ex.Message}");
                }
            }
        }
        #endregion

        #region Load Image B Button
        private void loadBtn2_Click(object sender, EventArgs e)
        {
            //Step 1: Create and configure the file dialog
            OpenFileDialog openFileDialog = new OpenFileDialog(); // -> creation of a windows file picker dialog
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif"; // -> restricts file types to common image formats. Format: Display Name|file patterns.... ex. name.png, etc chuchu
            openFileDialog.Title = "Select an Image File";

            //Step 2: Show the dialog and check if user selected a file
            if (openFileDialog.ShowDialog() == DialogResult.OK)//-> this shows the dialog and checks if user clicks OK
            {
                try
                {
                    //Step 3: Load the Selected Image
                    Image selectedImage = Image.FromFile(openFileDialog.FileName);

                    //Step 4: Display it in the original picture box
                    pictureBox2.Image = selectedImage; // -> assigns image to picture box
                    pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage; // -> StretchImage to make it fit the picture box
                }
                catch (Exception ex)
                {
                    //Step 5: Handle any errors (corrupted files, ect.)
                    MessageBox.Show("Error loading image: " + ex.Message);
                }
            }
        }
        #endregion

        #region Subtract Button
        private void subtractBtn_Click(object sender, EventArgs e)
        {
            if (originalPicBox.Image == null || pictureBox2.Image == null)
            {
                MessageBox.Show("Please load both Image A and Image B first");
                return;
            }

            Bitmap imageABitmap = new Bitmap(originalPicBox.Image);
            Bitmap imageBBitmap = new Bitmap(pictureBox2.Image);

            if (imageABitmap.Width != imageBBitmap.Width || imageABitmap.Height != imageBBitmap.Height)
            {
                MessageBox.Show("Images must be the same size for background replacement");
                return;
            }

            Bitmap resultBitmap = new Bitmap(imageABitmap.Width, imageABitmap.Height);

            for (int x = 0; x < imageABitmap.Width; x++)
            {
                for (int y = 0; y < imageABitmap.Height; y++)
                {
                    Color pixelA = imageABitmap.GetPixel(x, y);
                    Color pixelB = imageBBitmap.GetPixel(x, y);

                    // Simple green check
                    bool isGreen = (pixelB.G > pixelB.R + 50) && (pixelB.G > pixelB.B + 50) && (pixelB.G > 150);

                    if (isGreen)
                    {
                        resultBitmap.SetPixel(x, y, pixelA); // Replace with background
                    }
                    else
                    {
                        resultBitmap.SetPixel(x, y, pixelB); // Keep original
                    }
                }
            }

            editedPicBox.Image = resultBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            MessageBox.Show("Green screen replacement complete!");
        }
        #endregion

        // ENHANCED WEBCAM FUNCTIONALITY

        #region Enhanced Toggle Webcam Button
        private void toggleWebcamBtn_Click(object sender, EventArgs e)
        {
            if (!isWebcamRunning)
            {
                // Update button text while starting
                toggleWebcamBtn.Text = "Starting...";
                toggleWebcamBtn.Enabled = false;

                Application.DoEvents(); // Allow UI to update

                StartWebcam();

                toggleWebcamBtn.Text = isWebcamRunning ? "Stop Webcam" : "Start Webcam";
                toggleWebcamBtn.Enabled = true;
            }
            else
            {
                StopWebcam();
                toggleWebcamBtn.Text = "Start Webcam";
            }
        }
        #endregion

        #region Enhanced Start Webcam
        private void StartWebcam()
        {
            try
            {
                // Stop any existing webcam first
                if (currentDevice != null)
                {
                    StopWebcam();
                    System.Threading.Thread.Sleep(1000); // Wait for cleanup
                }

                if (devices == null || devices.Length == 0)
                {
                    RefreshDevices();
                    if (devices.Length == 0)
                    {
                        MessageBox.Show("No webcam devices found! Please check:\n" +
                                      "1. Webcam is connected\n" +
                                      "2. Drivers are installed\n" +
                                      "3. No other apps are using webcam");
                        return;
                    }
                }

                // Use selected device from combo box if available, otherwise use first device
                int deviceIndex = 0;
                if (webcamDevicesComboBox != null && webcamDevicesComboBox.SelectedIndex >= 0)
                {
                    deviceIndex = webcamDevicesComboBox.SelectedIndex;
                }

                currentDevice = devices[deviceIndex];

                // Clear the picture box first
                originalPicBox.Image = null;
                originalPicBox.Refresh();

                // Initialize the webcam with proper error handling
                currentDevice.ShowWindow(originalPicBox);

                // Give the webcam time to initialize
                System.Threading.Thread.Sleep(2000);

                isWebcamRunning = true;

                // Test if webcam is actually working by trying to capture a frame
                TestWebcamCapture();

                MessageBox.Show($"Webcam started using: {currentDevice.Name}\n" +
                               $"If you see black screen:\n" +
                               $"1. Wait 3-5 seconds for initialization\n" +
                               $"2. Try capturing a test frame\n" +
                               $"3. Try a different webcam device");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error starting webcam: {ex.Message}\n\n" +
                               $"Troubleshooting:\n" +
                               $"1. Close Skype, Teams, or other webcam apps\n" +
                               $"2. Try running as administrator\n" +
                               $"3. Check Windows Privacy settings for camera access");

                // Clean up on error
                if (currentDevice != null)
                {
                    try { currentDevice.Stop(); } catch { }
                    currentDevice = null;
                }
                isWebcamRunning = false;
            }
        }
        #endregion

        #region Enhanced Stop Webcam
        private void StopWebcam()
        {
            try
            {
                webcamTimer.Enabled = false;

                if (currentDevice != null)
                {
                    currentDevice.Stop();
                    System.Threading.Thread.Sleep(500); // Give time for cleanup
                    currentDevice = null;
                }

                isWebcamRunning = false;

                // Clear the webcam picture box
                if (originalPicBox.Image != null)
                {
                    originalPicBox.Image.Dispose();
                    originalPicBox.Image = null;
                }
                originalPicBox.Refresh();

                MessageBox.Show("Webcam stopped successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error stopping webcam: {ex.Message}");
                // Force cleanup even if there's an error
                currentDevice = null;
                isWebcamRunning = false;
            }
        }
        #endregion

        #region Test Webcam Capture Function
        private void TestWebcamCapture()
        {
            if (currentDevice == null) return;

            try
            {
                // Try to capture a test frame to verify webcam is working
                currentDevice.Sendmessage();
                System.Threading.Thread.Sleep(500);

                if (Clipboard.ContainsImage())
                {
                    using (Image testImage = Clipboard.GetImage())
                    {
                        // Check if we got a valid image (not just black)
                        using (Bitmap testBitmap = new Bitmap(testImage))
                        {
                            bool hasContent = CheckImageHasContent(testBitmap);
                            if (!hasContent)
                            {
                                MessageBox.Show("Warning: Webcam appears to be capturing black frames.\n" +
                                               "This might indicate:\n" +
                                               "1. Camera is covered or blocked\n" +
                                               "2. Wrong device selected\n" +
                                               "3. Camera needs time to adjust to lighting\n" +
                                               "4. Driver issues");
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Warning: Unable to capture test frame.\n" +
                                   "Camera might not be responding properly.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Test capture error: {ex.Message}");
            }
        }

        // Helper method to check if image has actual content (not just black)
        private bool CheckImageHasContent(Bitmap bitmap)
        {
            int samplePoints = 10;
            int nonBlackPixels = 0;

            for (int i = 0; i < samplePoints; i++)
            {
                for (int j = 0; j < samplePoints; j++)
                {
                    int x = (bitmap.Width * i) / samplePoints;
                    int y = (bitmap.Height * j) / samplePoints;

                    if (x < bitmap.Width && y < bitmap.Height)
                    {
                        Color pixel = bitmap.GetPixel(x, y);
                        if (pixel.R > 10 || pixel.G > 10 || pixel.B > 10)
                        {
                            nonBlackPixels++;
                        }
                    }
                }
            }

            // If more than 10% of sample pixels are non-black, assume image has content
            return nonBlackPixels > (samplePoints * samplePoints * 0.1);
        }
        #endregion

        #region Start Green Screen Processing Button
        private void startProcessingBtn_Click(object sender, EventArgs e)
        {
            if (!isWebcamRunning)
            {
                MessageBox.Show("Please start the webcam first!");
                return;
            }

            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load a background image first!");
                return;
            }

            webcamTimer.Enabled = !webcamTimer.Enabled;

            if (webcamTimer.Enabled)
            {
                MessageBox.Show("Real-time green screen processing started!");
                // startProcessingBtn.Text = "Stop Processing";
            }
            else
            {
                MessageBox.Show("Processing stopped!");
                // startProcessingBtn.Text = "Start Processing";
            }
        }
        #endregion

        #region WebcamTimer_Tick
        private void WebcamTimer_Tick(object sender, EventArgs e)
        {
            if (currentDevice == null || pictureBox2.Image == null)
                return;

            try
            {
                currentDevice.Sendmessage();
                System.Threading.Thread.Sleep(30); // Small delay

                if (Clipboard.ContainsImage())
                {
                    using (Image webcamFrame = Clipboard.GetImage())
                    using (Bitmap webcamBitmap = new Bitmap(webcamFrame))
                    using (Bitmap backgroundBitmap = new Bitmap(pictureBox2.Image))
                    {
                        Bitmap processedWebcam = webcamBitmap;
                        if (webcamBitmap.Size != backgroundBitmap.Size)
                        {
                            processedWebcam = new Bitmap(webcamBitmap, backgroundBitmap.Size);
                        }

                        Bitmap result = ApplyGreenScreen(processedWebcam, backgroundBitmap);

                        if (editedPicBox.Image != null)
                            editedPicBox.Image.Dispose();

                        editedPicBox.Image = result;

                        if (processedWebcam != webcamBitmap)
                            processedWebcam.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Processing error: {ex.Message}");
            }
        }
        #endregion

        #region Apply green screen effect
        private Bitmap ApplyGreenScreen(Bitmap webcamBitmap, Bitmap backgroundBitmap)
        {
            Bitmap result = new Bitmap(backgroundBitmap.Width, backgroundBitmap.Height);

            for (int x = 0; x < result.Width; x++)
            {
                for (int y = 0; y < result.Height; y++)
                {
                    Color webcamPixel = webcamBitmap.GetPixel(x, y);
                    Color backgroundPixel = backgroundBitmap.GetPixel(x, y);

                    // Green screen detection na ari
                    bool isGreen = (webcamPixel.G > webcamPixel.R + 50) &&
                                  (webcamPixel.G > webcamPixel.B + 50) &&
                                  (webcamPixel.G > 150);

                    result.SetPixel(x, y, isGreen ? backgroundPixel : webcamPixel);
                }
            }

            return result;
        }
        #endregion

        #region Enhanced Capture Frame Button
        private void captureFrameBtn_Click(object sender, EventArgs e)
        {
            if (currentDevice == null)
            {
                MessageBox.Show("Please start webcam first!");
                return;
            }

            try
            {
                currentDevice.Sendmessage();
                System.Threading.Thread.Sleep(50);

                if (Clipboard.ContainsImage())
                {
                    // Dispose any existing image in the first picture box
                    if (originalPicBox.Image != null)
                        originalPicBox.Image.Dispose();

                    // Put the captured frame into the first picture box
                    originalPicBox.Image = Clipboard.GetImage();
                    originalPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    MessageBox.Show("Frame captured and loaded into Image A box!");
                }
                else
                {
                    MessageBox.Show("Unable to capture frame. Make sure webcam is working properly.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error capturing frame: {ex.Message}");
            }
        }
        #endregion

        #region Device Selection Event (Optional - if you have a ComboBox)
        // If you have a webcamDevicesComboBox, add this event handler
        private void webcamDevicesComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If webcam is currently running, restart it with new device
            if (isWebcamRunning)
            {
                StopWebcam();
                System.Threading.Thread.Sleep(1000);
                StartWebcam();
            }
        }
        #endregion

        #region Form Closing Event
        // Add this to prevent issues when closing the form
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Make sure to stop webcam when form is closing
            if (isWebcamRunning)
            {
                StopWebcam();
            }

            // Dispose of any images to free memory
            if (originalPicBox.Image != null)
            {
                originalPicBox.Image.Dispose();
            }
            if (editedPicBox.Image != null)
            {
                editedPicBox.Image.Dispose();
            }
            if (pictureBox2.Image != null)
            {
                pictureBox2.Image.Dispose();
            }
            if (originalPicBox.Image != null)
            {
                originalPicBox.Image.Dispose();
            }
        }
        #endregion

        #region Additional Helper Methods

        // Method to refresh devices manually (you can call this from a button)
        private void refreshDevicesBtn_Click(object sender, EventArgs e)
        {
            RefreshDevices();
        }

        // Method to test if a specific device works
        private void TestDevice(int deviceIndex)
        {
            if (devices == null || deviceIndex >= devices.Length) return;

            try
            {
                Device testDevice = devices[deviceIndex];
                testDevice.ShowWindow(originalPicBox);
                System.Threading.Thread.Sleep(1000);
                testDevice.Stop();
                MessageBox.Show($"Device {testDevice.Name} appears to be working.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Device test failed: {ex.Message}");
            }
        }

        // Enhanced error logging for debugging
        private void LogError(string methodName, Exception ex)
        {
            string errorMessage = $"[{DateTime.Now}] Error in {methodName}: {ex.Message}";
            Console.WriteLine(errorMessage);

            // You can also write to a log file if needed
            // System.IO.File.AppendAllText("webcam_errors.log", errorMessage + Environment.NewLine);
        }

        #endregion

        private void Form1_Load_1(object sender, EventArgs e)
        {
            // Set the form title
            this.Text = "Image Processing Studio";
        }


        #region Convolution Filter Buttons

        // Smooth Filter
        private void smoothBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.Smooth(processedBitmap, 1);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Sharpen Filter
        private void sharpenBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.Sharpen(processedBitmap, 11);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Mean Removal Filter
        private void meanRemovalBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.MeanRemoval(processedBitmap, 9);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Gaussian Blur Filter
        private void gaussianBlurBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.GaussianBlur(processedBitmap, 4);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Emboss Laplacian
        private void embossLaplacianBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EmbossLaplacian(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Emboss Horizontal/Vertical
        private void embossHorzVertBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EmbossHorzVertical(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Emboss All Directions
        private void embossAllDirBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EmbossAllDirections(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Emboss Lossy
        private void embossLossyBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EmbossLossy(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Emboss Horizontal Only
        private void embossHorizBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EmbossHorizontal(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Emboss Vertical Only
        private void embossVertBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EmbossVertical(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Edge Detection - Sobel
        private void edgeSobelBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EdgeDetectSobel(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Edge Detection - Prewitt
        private void edgePrewittBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EdgeDetectPrewitt(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        // Edge Detection - Kirsch
        private void edgeKirschBtn_Click(object sender, EventArgs e)
        {
            ;
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first!");
                return;
            }
            Bitmap processedBitmap = new Bitmap(originalPicBox.Image);
            ConvolutionFilter.EdgeDetectKirsch(processedBitmap);
            editedPicBox.Image = processedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        #endregion

    }

}