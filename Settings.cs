using CustomPhotoConverter.Helpers;
using CustomPhotoConverter.Models;
using CustomPhotoConverter.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPhotoConverter
{
    public partial class RowAndColumn : Form
    {
        MeasurementHelpers measurementHelpers;
        string previous_SizeOneHeight = "";
        string previous_SizeOneWidth = "";
        string previous_SizeOneRow = "";
        string previous_SizeOneColumn = "";

        string previous_SizeTwoHeight = "";
        string previous_SizeTwoWidth = "";
        string previous_SizeTwoRow = "";
        string previous_SizeTwoColumn = "";
        string resolutionPPI = "";

        string borderSize = "";

        public RowAndColumn()
        {
            InitializeComponent();

            measurementHelpers = new MeasurementHelpers();
            txtResolution.Text = Settings.Default.resolutionPPI;

            #region SizeOneStuff
            txtSizeOneHeight.Text = measurementHelpers.ConvertToInt(Settings.Default.firstSizeHeight, txtResolution).ToString();
            txtSizeOneWidth.Text = measurementHelpers.ConvertToInt(Settings.Default.firstSizeWidth, txtResolution).ToString();
            txtSizeOneColumnsQty.Text = Settings.Default.firstSizeColumnQty;
            txtSizeOneRowsQty.Text = Settings.Default.firstSizeRowQty;
            #endregion

            #region SizeTwoStuff
            txtSizeTwoHeight.Text = measurementHelpers.ConvertToInt(Settings.Default.secondSizeHeight, txtResolution).ToString();
            txtSizeTwoWidth.Text = measurementHelpers.ConvertToInt(Settings.Default.secondSizeWidth, txtResolution).ToString();
            txtSizeTwoColumnsQty.Text = Settings.Default.secondSizeColumnQty;
            txtSizeTwoRowsQty.Text = Settings.Default.secondSizeRowQty;
            #endregion

            txtBorder.Text = Settings.Default.borderSize.ToString();

            InitializePictureBox();

            previous_SizeOneHeight = Settings.Default.firstSizeHeight;
            previous_SizeOneWidth = Settings.Default.firstSizeWidth;
            previous_SizeOneRow = Settings.Default.firstSizeRowQty;
            previous_SizeOneColumn = Settings.Default.firstSizeColumnQty;

            previous_SizeTwoHeight = Settings.Default.secondSizeHeight;
            previous_SizeTwoWidth = Settings.Default.secondSizeWidth;
            previous_SizeTwoRow = Settings.Default.secondSizeRowQty;
            previous_SizeTwoColumn = Settings.Default.secondSizeColumnQty;

            resolutionPPI = Settings.Default.resolutionPPI;
            borderSize = Settings.Default.borderSize.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region PictureBox
            pictureBox1.Width = measurementHelpers.ConvertToPixel(15);
            pictureBox1.Height = measurementHelpers.ConvertToPixel(10);
            #endregion

            var resourceImg = Resources.man;

            var firstSize = new PhotoSizeModel
                (
                    width: measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneWidth.Text)),
                    height: measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneHeight.Text)),
                    row: double.Parse(txtSizeOneRowsQty.Text),
                    column: double.Parse(txtSizeOneColumnsQty.Text)
                );
            var secondSize = new PhotoSizeModel
                (
                    width: measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoWidth.Text)),
                    height: measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoHeight.Text)),
                    row: double.Parse(txtSizeTwoRowsQty.Text),
                    column: double.Parse(txtSizeTwoColumnsQty.Text)
                );

            var conversion = new ConversionHelper();
            var pic = conversion.CreateImageByColumnsAndRows(resourceImg, pictureBox1, firstSize, secondSize, double.Parse(txtBorder.Text));
            if (pic == null)
            {

                MessageBox.Show("Invalid Size, Reverting back to previous size", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtSizeOneHeight.Text = previous_SizeOneHeight;
                txtSizeOneWidth.Text = previous_SizeOneWidth;
                txtSizeOneRowsQty.Text = previous_SizeOneRow;
                txtSizeOneColumnsQty.Text = previous_SizeOneColumn;

                txtSizeTwoHeight.Text = previous_SizeTwoHeight;
                txtSizeTwoWidth.Text = previous_SizeTwoWidth;
                txtSizeTwoRowsQty.Text = previous_SizeTwoRow;
                txtSizeTwoColumnsQty.Text = previous_SizeTwoColumn;

                txtResolution.Text = resolutionPPI;

                pictureBox1.Image = null;


            }
            else
            {
                pictureBox1.Image = pic;

                previous_SizeOneHeight = txtSizeOneHeight.Text;
                previous_SizeOneWidth = txtSizeOneWidth.Text;
                previous_SizeOneRow = txtSizeOneRowsQty.Text;
                previous_SizeOneColumn = txtSizeOneColumnsQty.Text;

                previous_SizeTwoHeight = txtSizeTwoHeight.Text;
                previous_SizeTwoWidth = txtSizeTwoWidth.Text;
                previous_SizeTwoRow = txtSizeTwoRowsQty.Text;
                previous_SizeTwoColumn = txtSizeTwoColumnsQty.Text;

                resolutionPPI = txtResolution.Text;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            var resourceImg = Resources.man;
            var firstSize = new PhotoSizeModel
                (
                    width: measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneWidth.Text)),
                    height: measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneHeight.Text)),
                    row: double.Parse(txtSizeOneRowsQty.Text),
                    column: double.Parse(txtSizeOneColumnsQty.Text)
                );
            var secondSize = new PhotoSizeModel
                (
                    width: measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoWidth.Text)),
                    height: measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoHeight.Text)),
                    row: double.Parse(txtSizeTwoRowsQty.Text),
                    column: double.Parse(txtSizeTwoColumnsQty.Text)
                );

            var conversion = new ConversionHelper();
            var pic = conversion.CreateImageByColumnsAndRows(resourceImg, pictureBox1, firstSize, secondSize, double.Parse(txtBorder.Text));
            if (pic == null)
            {
                MessageBox.Show("Invalid Size, Reverting back to previous size", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtSizeOneHeight.Text = previous_SizeOneHeight;
                txtSizeOneWidth.Text = previous_SizeOneWidth;
                txtSizeOneRowsQty.Text = previous_SizeOneRow;
                txtSizeOneColumnsQty.Text = previous_SizeOneColumn;

                txtSizeTwoHeight.Text = previous_SizeTwoHeight;
                txtSizeTwoWidth.Text = previous_SizeTwoWidth;
                txtSizeTwoRowsQty.Text = previous_SizeTwoRow;
                txtSizeTwoColumnsQty.Text = previous_SizeTwoColumn;

                txtResolution.Text = resolutionPPI;
                txtBorder.Text = borderSize;

                pictureBox1.Image = null;
            }
            else
            {
                //SizeOne
                Settings.Default.firstSizeHeight = measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneHeight.Text), txtResolution).ToString();
                Settings.Default.firstSizeWidth = measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneWidth.Text), txtResolution).ToString();
                Settings.Default.firstSizeColumnQty = txtSizeOneColumnsQty.Text;
                Settings.Default.firstSizeRowQty = txtSizeOneRowsQty.Text;

                //SizeTwo
                Settings.Default.secondSizeHeight = measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoHeight.Text), txtResolution).ToString();
                Settings.Default.secondSizeWidth = measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoWidth.Text), txtResolution).ToString();
                Settings.Default.secondSizeColumnQty = txtSizeTwoColumnsQty.Text;
                Settings.Default.secondSizeRowQty = txtSizeTwoRowsQty.Text;

                //Resolution
                Settings.Default.resolutionPPI = txtResolution.Text;

                //BorderSize
                Settings.Default.borderSize = double.Parse(txtBorder.Text);

                MessageBox.Show("Preferences are saved!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void InitializePictureBox()
        {
            #region PictureBox
            pictureBox1.Width = measurementHelpers.ConvertToPixel(15);
            pictureBox1.Height = measurementHelpers.ConvertToPixel(10);
            #endregion

            var resourceImg = Resources.man;
            var firstSize = new PhotoSizeModel
                (
                    width: measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneWidth.Text)),
                    height: measurementHelpers.ConvertToPixel(double.Parse(txtSizeOneHeight.Text)),
                    row: double.Parse(txtSizeOneRowsQty.Text),
                    column: double.Parse(txtSizeOneColumnsQty.Text)
                );
            var secondSize = new PhotoSizeModel
                (
                    width: measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoWidth.Text)),
                    height: measurementHelpers.ConvertToPixel(double.Parse(txtSizeTwoHeight.Text)),
                    row: double.Parse(txtSizeTwoRowsQty.Text),
                    column: double.Parse(txtSizeTwoColumnsQty.Text)
                );

            var conversion = new ConversionHelper();
            var pic = conversion.CreateImageByColumnsAndRows(resourceImg, pictureBox1, firstSize, secondSize, double.Parse(txtBorder.Text));
            if (pic == null)
            {
                MessageBox.Show("ERROR");
            }
            else
            {
                pictureBox1.Image = pic;
            }
        }

        private void txtSizeOneWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
