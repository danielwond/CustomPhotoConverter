using CustomPhotoConverter.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPhotoConverter
{
    public partial class Preferences : Form
    {
        public Preferences()
        {
            InitializeComponent();

            txtResolution.Text = GetScreenResolutionPPI().ToString();

            InitializeElements();

            txtOneHeight.Enabled = false;
            txtOneWidth.Enabled = false;

            txtTwoHeight.Enabled = false;
            txtTwoWidth.Enabled = false;


        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            // redo this logic.. get the first size and compare it with the second size.. and whichever is the biggest take the height and width of that. instead of just calculating it directly.
            var conversionHelper = new ConversionHelper();

            var firstSizeIncrementX = double.Parse(txtOneWidth.Text) + 20;
            var firstSizeIncrementY = double.Parse(txtOneHeight.Text) + 20;
            var firstSizeAmount = int.Parse(txtSizeOneQty.Text);

            var secondSizeIncrementX = double.Parse(txtTwoWidth.Text) + 20;
            var secondSizeIncrementY = double.Parse(txtTwoHeight.Text) + 20;
            var secondSizeAmount = int.Parse(txtSizeTwoQty.Text);




            var resourceImg = Properties.Resources.man;

            var imgOneHeight = int.Parse(txtOneHeight.Text);
            var imgOneWidth = int.Parse(txtOneWidth.Text);

            var imgTwoHeight = int.Parse(txtTwoHeight.Text);
            var imgTwoWidth = int.Parse(txtTwoWidth.Text);


            var img = conversionHelper.CreateImage(resourceImg, pictureBox1, imgOneHeight, imgOneWidth, imgTwoHeight, imgTwoWidth, firstSizeAmount, secondSizeAmount);
            pictureBox1.Image = img;
        }

        private void rdBtnPixel_CheckedChanged(object sender, EventArgs e)
        {
            grpBoxcm.Visible = false;

            txtOneHeight.Enabled = true;
            txtOneWidth.Enabled = true;

            txtTwoHeight.Enabled = true;
            txtTwoWidth.Enabled = true;

        }

        private void rdBtnCm_CheckedChanged(object sender, EventArgs e)
        {
            grpBoxcm.Visible = true;

            txtOneHeight.Enabled = false;
            txtOneWidth.Enabled = false;

            txtTwoHeight.Enabled = false;
            txtTwoWidth.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void txtOneWidthcm_TextChanged(object sender, EventArgs e)
        {
            if (txtOneWidthcm.Text != string.Empty)
            {
                var value = double.Parse(txtOneWidthcm.Text);
                txtOneWidth.Text = CalculatePixel(value).ToString();
            }
        }


        private void txtOneHeightcm_TextChanged(object sender, EventArgs e)
        {
            if (txtOneHeightcm.Text != string.Empty)
            {
                var value = double.Parse(txtOneHeightcm.Text);
                txtOneHeight.Text = CalculatePixel(value).ToString();
            }
        }

        private void txtTwoWidthcm_TextChanged(object sender, EventArgs e)
        {
            if (txtTwoWidthcm.Text != string.Empty)
            {
                var value = double.Parse(txtTwoWidthcm.Text);
                txtTwoWidth.Text = CalculatePixel(value).ToString();
            }
        }

        private void txtTwoHeightcm_TextChanged(object sender, EventArgs e)
        {
            if (txtTwoHeightcm.Text != string.Empty)
            {
                var value = double.Parse(txtTwoHeightcm.Text);
                txtTwoHeight.Text = CalculatePixel(value).ToString();
            }
        }


        private void txtResolution_TextChanged(object sender, EventArgs e)
        {
            InitializeElements();

            SetTxtBoxWithCmTextBox(txtOneWidth, txtOneWidthcm);
            SetTxtBoxWithCmTextBox(txtOneHeight, txtOneHeightcm);

            SetTxtBoxWithCmTextBox(txtTwoWidth, txtTwoWidthcm);
            SetTxtBoxWithCmTextBox(txtTwoHeight, txtTwoHeightcm);
        }

        void SetTxtBoxWithCmTextBox(TextBox txtBox, TextBox txtBoxcm)
        {
            if (txtBoxcm.Text != string.Empty)
            {
                var value = double.Parse(txtBoxcm.Text);
                txtBox.Text = CalculatePixel(value).ToString();
            }
        }

        void InitializeElements()
        {
            txtOneWidth.Text = CalculatePixel(3).ToString();
            txtOneHeight.Text = CalculatePixel(4).ToString();

            txtTwoHeight.Text = CalculatePixel(2).ToString();
            txtTwoWidth.Text = CalculatePixel(2).ToString();

            txtOneWidthcm.Text = "3";
            txtOneHeightcm.Text = "4";

            txtTwoWidthcm.Text = "2";
            txtTwoHeightcm.Text = "2";

            txtSizeOneQty.Text = "8";
            txtSizeTwoQty.Text = "4";

            var conversionHelper = new ConversionHelper();
            var resourceImg = Properties.Resources.man;

            var imgOneHeight = int.Parse(txtOneHeight.Text);
            var imgOneWidth = int.Parse(txtOneWidth.Text);

            var imgTwoHeight = int.Parse(txtTwoHeight.Text);
            var imgTwoWidth = int.Parse(txtTwoWidth.Text);

            var sizeOneQty = Convert.ToInt32(txtSizeOneQty.Text);
            var sizeTwoQty = Convert.ToInt32(txtSizeTwoQty.Text);

            var img = conversionHelper.CreateImage(resourceImg, pictureBox1, imgOneHeight, imgOneWidth, imgTwoHeight, imgTwoWidth, sizeOneQty, sizeTwoQty);

            pictureBox1.Image = img;
        }

        int CalculatePixel(double value)
        {
            //get the value in inches .. we multiply it with 0.3937
            var valueInInches = value * 0.3937;

            if (txtResolution.Text != string.Empty)
            {
                //change the inch to pixels with the resolution
                var widthInPix = valueInInches * int.Parse(txtResolution.Text);

                return int.Parse(Math.Ceiling(widthInPix).ToString());
            }
            return 0;
        }

        int GetScreenResolutionPPI()
        {
            try
            {
                // Get screen resolution
                int screenWidth = Screen.PrimaryScreen.Bounds.Width;
                int screenHeight = Screen.PrimaryScreen.Bounds.Height;


                // Calculate diagonal pixel length
                double diagonalPixels = Math.Sqrt(screenWidth * screenWidth + screenHeight * screenHeight);

                // Get DPI
                using (Graphics graphics = Graphics.FromHwnd(IntPtr.Zero))
                {
                    float dpiX = graphics.DpiX;
                    float dpiY = graphics.DpiY;
                    float avgDpi = (dpiX + dpiY) / 2;

                    // Calculate diagonal inches
                    double diagonalInches = diagonalPixels / avgDpi;

                    // Calculate PPI
                    double ppi = Math.Sqrt(screenWidth * screenWidth + screenHeight * screenHeight) / diagonalInches;

                    Console.WriteLine($"Screen Resolution: {screenWidth}x{screenHeight}");
                    Console.WriteLine($"Diagonal Inches: {diagonalInches:F2}");


                    return int.Parse(ppi.ToString());
                }
            }
            catch (Exception)
            {

                return 300;
            }
        }

    }
}
