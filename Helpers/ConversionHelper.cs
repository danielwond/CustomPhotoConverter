using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace CustomPhotoConverter.Helpers
{
    public class ConversionHelper
    {
        //string folderPath = @"C:\Users\ddpro\Desktop\New folder (10)";
        private readonly string _folderPath = "";
        private readonly string _outputPath = "";
        private readonly ProgressBar _progressBar;
        private readonly Label _label;

        public ConversionHelper(string folderPath, string outputPath, ProgressBar progressBar, Label label)
        {
            _folderPath = folderPath;
            _outputPath = outputPath;
            _progressBar = progressBar;
            _label = label;
            _progressBar.Minimum = 0;
        }

        public async Task ConvertPhotos(CancellationToken token)
        {
            _progressBar.Refresh();
           
            try
            {
                List<string> imagePaths = GetImagesFromFolder(_folderPath);

                _progressBar.Maximum = imagePaths.Count;

                _label.Text = "Conversion Started... please wait";
                _label.Refresh();

                for (int i = 0; i < imagePaths.Count; i++)
                {
                    token.ThrowIfCancellationRequested();

                    var img = imagePaths[i];

                    var inputFilepath = _folderPath.Split('\\');
                    var outputFile = img.Split('\\');
                    var folders = outputFile.Except(inputFilepath).ToList();

                    folders.RemoveAt(folders.Count - 1);

                    var outputFolderPath = Path.Combine(_outputPath, "Converted", string.Join("\\", folders));
                    if (!Directory.Exists(outputFolderPath))
                    {
                        Directory.CreateDirectory(outputFolderPath);
                    }

                    var outputFilePath = Path.Combine(outputFolderPath, $"img{i}.jpg");

                    await Task.Run(() => CreateImage(outputFilePath, img));
                    _progressBar.Value = i;
                }

                _label.Text = "Conversion has finished :)";
                _label.Refresh();
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("User has cancelled the request");
                _progressBar.Value = 0;
                _progressBar.Refresh();
            }
        }
        void CreateImage(string outputFileName, string images)
        {
            int space = 10;
            int canvasWidth = 1772;
            int canvasHeight = 1181;

            using (Bitmap collageBitmap = new Bitmap(width: canvasWidth, height: canvasHeight))
            {

                int imageCount = 8;

                Graphics g = Graphics.FromImage(collageBitmap);
                g.Clear(Color.White);

                var x_increment = GetImgSize()["Width"] + space + 10;
                var y_increment = GetImgSize()["Height"] + space + 10;
                var x = 0 + 10;
                var y = 0 + 10;

                for (int i = 1; i <= imageCount; i++)
                {
                    using (Graphics graphics = Graphics.FromImage(collageBitmap))
                    {
                        var rectangle = new Rectangle(x, y, GetImgSize()["Width"], GetImgSize()["Height"]);
                        DrawImageWithBorder(graphics, images, rectangle, 5);
                    }
                    x += x_increment;
                    if (i % 4 == 0)
                    {
                        y += y_increment;
                        x = 10;
                    }
                }

                x = 1436 + space + space + 10 + 10 + 10 + 10 + 10;
                y = 0 + 10;
                y_increment = GetImgSize()["SmallHeight"] + space + 10;

                for (int i = 0; i < 4; i++)
                {

                    using (Graphics graphics = Graphics.FromImage(collageBitmap))
                    {
                        var rectangle = new Rectangle(x, y, GetImgSize()["SmallWidth"], GetImgSize()["SmallHeight"]);
                        DrawImageWithBorder(graphics, images, rectangle, 5);

                        y += y_increment;
                        x = 1436 + space + space + 10 + 10 + 10 + 10 + 10;
                    }
                }
                SaveCanvas(collageBitmap, outputFileName);
            }
        }

        List<string> GetImagesFromFolder(string folderPath)
        {
            List<string> imagePaths = Directory.EnumerateFiles(folderPath, "*.jpg", SearchOption.AllDirectories).ToList();
            return imagePaths;
        }

        Dictionary<string, int> GetImgSize()
        {
            Image img = Image.FromFile(@"C:\Users\ddpro\Desktop\img\Untitled-1.jpg");
            Image smallImg = Image.FromFile(@"C:\Users\ddpro\Desktop\img\2x2.jpg");

            return new Dictionary<string, int>()
            {
                {"Height", img.Height }, 
                {"Width", img.Width}, 
                {"SmallHeight" , smallImg.Height}, 
                {"SmallWidth", smallImg.Width}
            };
        }

        ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }

        void SaveCanvas(Bitmap collageBitmap, string outputFileName)
        {
            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)90);
            collageBitmap.Save(outputFileName, jgpEncoder, encoderParams);
        }

        void DrawImageWithBorder(Graphics g, string imagePath, Rectangle rect, float borderWidth = 1)
        {
            using (Image image = Image.FromFile(imagePath))
            {
                g.DrawImage(image, rect);
                g.DrawRectangle(new Pen(Brushes.Black, borderWidth), rect);
            }
        }
    }
}
