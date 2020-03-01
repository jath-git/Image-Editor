using System;
using System.Drawing;
using System.Windows.Forms;

/* Jathurshan Theivikaran
 * October 11 2019
 * this program manipulates the colour pixels of the inputted image
 */

//sample image is in the folder of this solution
namespace ImageProcessing
{
    public partial class frmMain : Form
    {
        //global variables for arrays of original picture and transformed picture that is displayed
        private Color[,] original;
        private Color[,] transformedPic;

        public frmMain()
        {
            InitializeComponent();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            //draw transformed picture on form
            base.OnPaint(e);
            Graphics g = e.Graphics;

            //only draw if picture is transformed
            if (transformedPic != null)
            {
                //get height and width of transfrormedPic array
                int height = transformedPic.GetUpperBound(0)+1;
                int width = transformedPic.GetUpperBound(1) + 1;

                //create new Bitmap to be dispalyed on the form
                Bitmap newBmp = new Bitmap(width, height);
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        //loop through each element transformedPic and set colour of each pixel in bitmap
                        newBmp.SetPixel(j, i, transformedPic[i, j]);
                    }
                }
                //call DrawImage to draw bitmap
                g.DrawImage(newBmp, 0, 20, width, height);
            }
        }


        private void mnuFileOpen_Click(object sender, EventArgs e)
        {
            //try catch handles errors for invalid picture files
            try
            {
                //open file dialog to select picture file
                OpenFileDialog fd = new OpenFileDialog();

                //create bitmap to store file in
                Bitmap bmp;

                //read picture file
                if (fd.ShowDialog() == DialogResult.OK)
                {
                    //store selected file into bitmap
                    bmp = new Bitmap(fd.FileName);

                    //create arrays to store image colours with height and width of bitmap
                    original = new Color[bmp.Height, bmp.Width];
                    transformedPic = new Color[bmp.Height, bmp.Width];

                    //load each colour into colour array
                    for (int i = 0; i < bmp.Height; i++)
                    {
                        for (int j = 0; j < bmp.Width; j++)
                        {
                            //assign the colour in the bitmap to the array
                            original[i, j] = bmp.GetPixel(j, i);
                            transformedPic[i, j] = original[i, j];
                        }
                    }
                    //refresh form
                    this.Refresh();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error Loading Picture File. \n" + ex.Message);
            }
        }

        private void mnuProcessDarken_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //to store colour intensity of a red, green, blue colours
                int Red, Green, Blue;

                //get height and width of picture
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //loop through each element in transformedPic
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        //add dark colour
                        Red = transformedPic[i, j].R - 10;
                        if (Red < 0) Red = 0;
                        Green = transformedPic[i, j].G - 10;
                        if (Green < 0) Green = 0;
                        Blue = transformedPic[i, j].B - 10;
                        if (Blue < 0) Blue = 0;

                        //copy back colours into transformedPic
                        transformedPic[i, j] = Color.FromArgb(Red, Green, Blue);
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessInvert_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //create variables for colours and dimensions of transformedPic
                int Red, Green, Blue;
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //loop through each index of transformedPic
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        //determine inverted colour
                        Red = 255 - transformedPic[i, j].R;
                        Green = 255 - transformedPic[i, j].G;
                        Blue = 255 - transformedPic[i, j].B;

                        //change colours of transformedPic
                        transformedPic[i, j] = Color.FromArgb(Red, Green, Blue);
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessWhiten_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store colour intensity of a red, green, blue colours
                int Red, Green, Blue;

                //get height and width of picture
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //loop through each index in transformedPic
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        //add white colour
                        Red = transformedPic[i, j].R + 10;
                        if (Red > 255) Red = 255;
                        Green = transformedPic[i, j].G + 10;
                        if (Green > 255) Green = 255;
                        Blue = transformedPic[i, j].B + 10;
                        if (Blue > 255) Blue = 255;

                        //copy back colours into transformedPic
                        transformedPic[i, j] = Color.FromArgb(Red, Green, Blue);
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessRotate_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformed picture
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create temporary array with opposite dimensions
                Color[,] TempColour = new Color[Width, Height];

                //loop through each index of transformed picture
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        //copy first row of transformed to last column of temp and first column of transformed to first row
                        TempColour[i, j] = transformedPic[Height - j - 1, i];
                    }
                }

                //change dimensions of transformedPic to TempColour
                transformedPic = new Color[Width, Height];
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        //copy back tempColour into transformedPic 
                        transformedPic[i, j] = TempColour[i,j];
                    }
                }

                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessReset_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //change dimensions of transformedPic to dimensions of original array
                transformedPic = new Color[original.GetLength(0), original.GetLength(1)];

                //loop through each index of transformedPic
                for (int i = 0; i < transformedPic.GetLength(0); i++)
                {
                    for (int j = 0; j < transformedPic.GetLength(1); j++)
                    {
                        //copy original array element into transformedPic element
                        transformedPic[i, j] = original[i, j];
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessFlipX_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create temporary colour array
                Color TempColour;

                //loop through left half columns of transformedPic
                for (int i = 0; i < Width / 2; i++)
                {
                    //loop through row of transformedPic
                    for (int j = 0; j < Height; j++)
                    {
                        //transfer left pixel to right and vice versa
                        TempColour = transformedPic[j, i];
                        transformedPic[j, i] = transformedPic[j, Width - 1 - i];
                        transformedPic[j, Width - 1 - i] = TempColour;
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessFlipY_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimension of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create temporary colour array
                Color TempColour;

                //loop through top half rows
                for (int i = 0; i < Height / 2; i++)
                {
                    //looop through each column
                    for (int j = 0; j < Width; j++)
                    {
                        //transfer top pixel to bottom and vice versa
                        TempColour = transformedPic[i, j];
                        transformedPic[i, j] = transformedPic[Height - 1 - i, j];
                        transformedPic[Height - 1 - i, j] = TempColour;
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessMirrorH_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create temporary colour array with double the width
                Color[,] TempColor = new Color[Height, 2 * Width];

                //copy transformedPic to the same indexes of TempColour
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        TempColor[i, j] = transformedPic[i, j];
                    }
                }

                //copy flipX to right half of TempColour
                for (int i = 0; i < Width; i++)
                {
                    for (int j = 0; j < Height; j++)
                    {
                        TempColor[j, i + Width - 1] = TempColor[j, Width - i - 1];
                        TempColor[j, 2 * Width - i - 1] = TempColor[j, i];
                    }
                }

                //resize transformedPic as same dimensions as TempColour
                transformedPic = new Color[TempColor.GetLength(0), TempColor.GetLength(1)];

                //copy TempColour back into transformedPic
                for (int i = 0; i < transformedPic.GetLength(0); i++)
                {
                    for (int j = 0; j < transformedPic.GetLength(1); j++)
                    {
                        transformedPic[i, j] = TempColor[i, j];
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessMirrorV_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create temporary array with doubled height
                Color[,] TempColor = new Color[2 * Height, Width];

                //copy transformedPic to the same indexes of TempColour
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        TempColor[i, j] = transformedPic[i, j];
                    }
                }

                //copy flipX to bottom half of TempColour
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        TempColor[i + Height - 1, j] = TempColor[Height - i - 1, j];
                        TempColor[2 * Height - i - 1, j] = TempColor[i, j];
                    }
                }

                //resize transformedPic as same dimensions as TempColour
                transformedPic = new Color[TempColor.GetLength(0), TempColor.GetLength(1)];
                
                //copy TempColour back into transformedPic
                for (int i = 0; i < transformedPic.GetLength(0); i++)
                {
                    for (int j = 0; j < transformedPic.GetLength(1); j++)
                    {
                        transformedPic[i, j] = TempColor[i, j];
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessScale50_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create counters for height and width
                int CounterHeight = 0, CounterWidth = 0;

                //create temporary colour array with half the dimensions
                Color[,] TempColour = new Color[Height/2, Width/2];

                //loop through each index of transformedPic
                for (int i = 0; i < Height / 2; i++)
                {
                    //check if odd row
                    if (CounterHeight % 2 != 0)
                    {
                        //skip row
                        CounterHeight++;
                    }

                    //start width from beginning
                    CounterWidth = 0;

                    for (int j = 0; j < Width / 2; j++)
                    {
                        //check if odd column
                        if (CounterWidth % 2 != 0)
                        {
                            //skip column
                            CounterWidth++;
                        }
                        //copy transformedPic element skipping odd rows and columns to temporary array
                        TempColour[i, j] = transformedPic[CounterHeight, CounterWidth];
                        CounterWidth++;
                    }
                    CounterHeight++;
                }

                //resize transformedPic with half its original dimensions
                transformedPic = new Color[Height / 2, Width / 2];

                //loop through each index of transformedPic
                for (int i = 0; i < Height / 2; i++)
                {
                    for (int j = 0; j < Width / 2; j++)
                    {
                        //copy temporary array to transformedPic
                        transformedPic[i, j] = TempColour[i, j];
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessScale200_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create temporary array with doubple the dimensions
                Color[,] TempColour = new Color[Height * 2, Width * 2];

                //loop through each index of transformedPic
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        //copy element to the four indexes to the right, bottom and bottom right
                        for (int k = i * 2; k < i * 2 + 2; k++)
                        {
                            for (int l = j * 2; l < j * 2 + 2; l++)
                            {
                                TempColour[k, l] = transformedPic[i, j];
                            }
                        }
                    }
                }

                //resize transformedPic 
                transformedPic = new Color[Height * 2, Width * 2];

                //copy tempColour to transformedPic
                for (int i = 0; i < Height * 2; i++)
                {
                    for (int j = 0; j < Width * 2; j++)
                    {
                        transformedPic[i, j] = TempColour[i, j];
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuProcessBlur_Click(object sender, EventArgs e)
        {
            //check if picture is loaded
            if (transformedPic != null)
            {
                //store dimensions of transformedPic
                int Height = transformedPic.GetLength(0);
                int Width = transformedPic.GetLength(1);

                //create variables to store counter data
                int Red, Green, Blue, PixelCounter;

                //create temporary array
                Color[,] TempColour = new Color[Height, Width];

                //store transformedPic
                for (int i = 0; i < Height; i++)
                { 
                    for (int j = 0; j < Width; j++)
                    {
                        TempColour[i, j] = transformedPic[i, j];
                    }
                }

                //loop through each index of TempColour
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        //reinitialize the values
                        Red = 0;
                        Green = 0;
                        Blue = 0;
                        PixelCounter = 9;

                        //loop through a 3 by 3 array starting from the pixel that is top left of current transformedPic index
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                //check if pixel is out of boundary
                                if (k < 0 || k >= Height || l < 0 || l >= Width)
                                {
                                    //subtract the number of pixels to be divided, by 1
                                    PixelCounter--;
                                }
                                else
                                {
                                    //add values for red, green, blue colours of pixel
                                    Red += TempColour[k, l].R;
                                    Green += TempColour[k, l].G;
                                    Blue += TempColour[k, l].B;
                                }
                            }
                        }

                        //divide total red, green, blue colours by number of pixels added
                        Red /= PixelCounter;
                        Green /= PixelCounter;
                        Blue /= PixelCounter;

                        //change colours of transformedPic
                        transformedPic[i, j] = Color.FromArgb(Red, Green, Blue);
                    }
                }
                //refresh form
                this.Refresh();
            }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            //close form
            this.Close();
        }
    }
}
