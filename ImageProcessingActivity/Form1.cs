using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageProcessingActivity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

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

        private void copyBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check if we have an image to copy
            if (originalPicBox.Image == null)
            {
                MessageBox.Show("Please load an image first");
                return;
            }

            //Step 2: Convert to Bitmap for pixel manipulation
            Bitmap originalBitmap = new Bitmap(originalPicBox.Image);

            //Step 3: Create a new bitmap with same width and height
            Bitmap copiedBitmap = new Bitmap(originalBitmap.Width, originalBitmap.Height);

            //Step 4: Copy each pixel
            for (int x = 0; x < originalBitmap.Width; x++) // -> goes through each column
            {
                for (int y = 0; y < originalBitmap.Height; y++) // -> goes through each row
                {
                    //PROCESS PIXEL AT POSITION(x,y)
                    //Get pixel color from original
                    Color pixelColor = originalBitmap.GetPixel(x, y); //-> to read the pixel

                    //Set same color in copied bitmap
                    copiedBitmap.SetPixel(x, y, pixelColor); //-> to write the pixel

                    //Images are 2d arrays of pixels. x -> column position (left to right). y -> row position (up to down)... visit every single pixel to copuy
                }
            }

            //Step 5: Display the copied image
            editedPicBox.Image = copiedBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

        }

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

                    //Create new gay color (same value for r, g, and b)
                    Color grayColor = Color.FromArgb(grayValue, grayValue, grayValue);

                    //Set the gray pixel in the new bitmap
                    grayscaleBitmap.SetPixel(x, y, grayColor);
                }
            }

            //Step 5: Display the grayscale image
            editedPicBox.Image = grayscaleBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;


        }

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

        private void histogramBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check if we have an image to analyze
            if (originalPicBox == null)
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

        private void subtractBtn_Click(object sender, EventArgs e)
        {
            //Step 1: Check both images exist and are the same size
            if (originalPicBox == null || pictureBox2 == null)
            {
                MessageBox.Show("Please load both Image A and Image B first");
                return;
            }

            //Step 2: Convert to bitmaps
            Bitmap imageABitmap = new Bitmap(originalPicBox.Image);
            Bitmap imageBBitmap = new Bitmap(pictureBox2.Image);

            //Step 3: Check if images are same size
            if (imageABitmap.Width != imageBBitmap.Width || imageABitmap.Height != imageBBitmap.Height)
            {
                MessageBox.Show("Images must be the same size for background replacement");
                return;
            }

            //Step 4: Create result bitmap
            Bitmap resultBitmap = new Bitmap(imageABitmap.Width, imageABitmap.Height);

            //Step 5: Set threshold value 
            int threshold = 130; //-> adjust value for experimentation

            //Step 6: Process each pixel
            for (int x = 0; x < imageABitmap.Width; x++) 
            {
                for (int y = 0; y < imageBBitmap.Height; y++)
                {

                    // Get pixels from both images
                    Color pixelA = imageABitmap.GetPixel(x, y);
                    Color pixelB = imageBBitmap.GetPixel(x, y);

                    // Convert to grayscale for comparison
                    int grayA = (pixelA.R + pixelA.G + pixelA.B) / 3;
                    int grayB = (pixelB.R + pixelB.G + pixelB.B) / 3;

                    // Calculate absolute difference
                    int difference = Math.Abs(grayA - grayB);

                    // Decide which pixel to use
                    if (difference > threshold)
                    {
                        // Pixels are different - use original background (Image A)
                        resultBitmap.SetPixel(x, y, pixelA);
                    }
                    else
                    {
                        // Pixels are similar - use person from green screen (Image B)
                        resultBitmap.SetPixel(x, y, pixelB);
                    }

                }
            }

            //Step 7: Display Result
            editedPicBox.Image = resultBitmap;
            editedPicBox.SizeMode = PictureBoxSizeMode.StretchImage;

            MessageBox.Show("Background replacement compete!");
        }
    }
}
