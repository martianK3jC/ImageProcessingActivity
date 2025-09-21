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
            if(openFileDialog.ShowDialog() == DialogResult.OK)//-> this shows the dialog and checks if user clicks OK
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
                        Color originalColor = originalBitmap.GetPixel(x,y);
                        
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
                for(int y = 0;y < originalBitmap.Height; y++)
                {
                    //Get original pixel color
                    Color pixelColor = originalBitmap.GetPixel(x,y);

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
    }
}
