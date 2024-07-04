using CustomPhotoConverter.Helpers;
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
    public partial class CropForm : Form
    {
        int xDown = 0;
        int yDown = 0;
        int xUp = 0;
        int yUp = 0;
        Rectangle rectCropArea = new Rectangle();
        string _fn = "";


        public CropForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            pictureBox1.Invalidate();

            xDown = e.X;
            yDown = e.Y;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            xUp = e.X;
            yUp = e.Y;
            Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
            using (Pen pen = new Pen(Color.YellowGreen, 3))
            {

                pictureBox1.CreateGraphics().DrawRectangle(pen, rec);
            }
            rectCropArea = rec;
        }

        private void btnImageSelect_Click(object sender, EventArgs e)
        {
            var opf = new OpenFileDialog();
            if(opf.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(opf.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                _fn = opf.FileName;
            }
            pictureBox1.Cursor = Cursors.Cross;
        }

        private void btnCrop_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Refresh();

                Bitmap sourceBitmap = new Bitmap(pictureBox1.Image, pictureBox1.Width, pictureBox1.Height);

                Graphics g = pictureBox2.CreateGraphics();
                int width = Math.Abs(xUp - xDown) * 100;
                int height = Math.Abs(yUp - yDown) * 100;

                var registry = new RegistryHelper();
                registry.WriteToRegistry("CropSizeWidth", width.ToString());
                registry.WriteToRegistry("CropSizeHeight", height.ToString());

                lblHeight.Text = $"Height: {registry.GetValue("CropSizeHeight")} Pixels";
                lblWidth.Text = $"Width: {registry.GetValue("CropSizeWidth")} Pixels";

                g.DrawImage(sourceBitmap, new Rectangle(0, 0, pictureBox2.Width, pictureBox2.Height), rectCropArea, GraphicsUnit.Pixel);

                sourceBitmap.Dispose();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
