using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomPhotoConverter.Helpers
{
    public class MeasurementHelpers
    {
        public int ConvertToPixel(double value, TextBox txtResolution)
        {
            //get the value in inches .. we multiply it with 0.3937
            var valueInInches = value * 0.3937;

            if (txtResolution.Text != string.Empty)
            {
                //change the inch to pixels with the resolution
                var widthInPix = valueInInches * int.Parse(txtResolution.Text);

                return (int)Math.Ceiling(widthInPix);
            }
            return 0;
        }
        public int GetScreenResolutionPPI()
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
        public int ConvertToPixel(double value)
        {
            //get the value in inches .. we multiply it with 0.3937
            var valueInInches = value * 0.3937;

            //change the inch to pixels with the resolution
            var widthInPix = valueInInches * GetScreenResolutionPPI();
            return (int)Math.Ceiling(widthInPix);
        }
        public int ConvertToPixel(double value, int resolution)
        {
            //get the value in inches .. we multiply it with 0.3937
            var valueInInches = value * 0.3937;

            //change the inch to pixels with the resolution
            var widthInPix = valueInInches * resolution;
            return (int)Math.Ceiling(widthInPix);
        }

        public int ConvertToInt(string value, TextBox resolution)
        {
            var result = (double.Parse(value) / double.Parse(resolution.Text)) * 2.54;
            return (int)Math.Floor(result);
        }
    }
}
