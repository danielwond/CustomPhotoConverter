using CustomPhotoConverter.Helpers;
using CustomPhotoConverter.Models;
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
using static System.Console;

namespace CustomPhotoConverter
{
    public partial class Preferences : Form
    {
        MeasurementHelpers measurementHelpers;
        public Preferences()
        {
            InitializeComponent();

            measurementHelpers = new MeasurementHelpers();
            txtResolution.Text = measurementHelpers.GetScreenResolutionPPI().ToString();

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
            var resourceImg = Properties.Resources.man;

            var firstSize = new PhotoSizeModel(width: int.Parse(txtOneWidth.Text), height: int.Parse(txtOneHeight.Text), int.Parse(txtSizeOneQty.Text));
            var secondSize = new PhotoSizeModel(width: int.Parse(txtTwoWidth.Text), height: int.Parse(txtTwoHeight.Text), amount: int.Parse(txtSizeTwoQty.Text));


            var img = conversionHelper.CreateImage(resourceImg, pictureBox1, firstSize, secondSize);

            WriteLine(conversionHelper.GetRemainingSpace(pictureBox1, firstSize, secondSize));

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
                txtOneWidth.Text = measurementHelpers.ConvertToPixel(value).ToString();
            }
        }


        private void txtOneHeightcm_TextChanged(object sender, EventArgs e)
        {
            if (txtOneHeightcm.Text != string.Empty)
            {
                var value = double.Parse(txtOneHeightcm.Text);
                txtOneHeight.Text = measurementHelpers.ConvertToPixel(value).ToString();
            }
        }

        private void txtTwoWidthcm_TextChanged(object sender, EventArgs e)
        {
            if (txtTwoWidthcm.Text != string.Empty)
            {
                var value = double.Parse(txtTwoWidthcm.Text);
                txtTwoWidth.Text = measurementHelpers.ConvertToPixel(value).ToString();
            }
        }

        private void txtTwoHeightcm_TextChanged(object sender, EventArgs e)
        {
            if (txtTwoHeightcm.Text != string.Empty)
            {
                var value = double.Parse(txtTwoHeightcm.Text);
                txtTwoHeight.Text = measurementHelpers.ConvertToPixel(value).ToString();
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
                txtBox.Text = measurementHelpers.ConvertToPixel(value).ToString();
            }
        }

        void InitializeElements()
        {
            txtOneWidthcm.Text = "3";
            txtOneHeightcm.Text = "4";

            txtTwoWidthcm.Text = "2";
            txtTwoHeightcm.Text = "2";

            txtSizeOneQty.Text = "6";
            txtSizeTwoQty.Text = "4";

            txtOneWidth.Text = measurementHelpers.ConvertToPixel(3).ToString();
            txtOneHeight.Text = measurementHelpers.ConvertToPixel(4).ToString();

            txtTwoHeight.Text = measurementHelpers.ConvertToPixel(2).ToString();
            txtTwoWidth.Text = measurementHelpers.ConvertToPixel(2).ToString();

            pictureBox1.Height = measurementHelpers.ConvertToPixel(10);
            pictureBox1.Width = measurementHelpers.ConvertToPixel(15);

            var conversionHelper = new ConversionHelper();
            var resourceImg = Properties.Resources.man;


            var firstSize = new PhotoSizeModel(width: int.Parse(txtOneWidth.Text), height: int.Parse(txtOneHeight.Text), int.Parse(txtSizeOneQty.Text));
            var secondSize = new PhotoSizeModel(width: int.Parse(txtTwoWidth.Text), height: int.Parse(txtTwoHeight.Text), amount: int.Parse(txtSizeTwoQty.Text));


            var img = conversionHelper.CreateImage(resourceImg, pictureBox1, firstSize, secondSize);

            pictureBox1.Image = img;
        }

    }
}
