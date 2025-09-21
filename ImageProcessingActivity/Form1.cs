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
    }
}
