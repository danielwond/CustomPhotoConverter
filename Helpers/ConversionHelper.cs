using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using CustomPhotoConverter.Models;
using CustomPhotoConverter.Properties;

namespace CustomPhotoConverter.Helpers
{
    public class ConversionHelper
    {
        MeasurementHelpers measurementHelpers;
        public ConversionHelper()
        {
            measurementHelpers = new MeasurementHelpers();
        }
        public async Task ConvertPhotos(CancellationToken token, string _folderPath, string _outputPath, ProgressBar _progressBar, Label _label, double borderSize)
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

                    //var outputFilePath = Path.Combine(outputFolderPath, $"img{i}.jpg");
                    var filename = Path.GetFileName(imagePaths[i]);
                    var outputFilePath = Path.Combine(outputFolderPath, filename);

                    if (!File.Exists(outputFilePath))
                    {
                        var sizeOne = new PhotoSizeModel
                            (
                                width: int.Parse(Settings.Default.firstSizeWidth),
                                height: int.Parse(Settings.Default.firstSizeHeight),
                                row: int.Parse(Settings.Default.firstSizeRowQty),
                                column: int.Parse(Settings.Default.firstSizeColumnQty)
                            );
                        var sizeTwo = new PhotoSizeModel
                            (
                                width: int.Parse(Settings.Default.secondSizeWidth),
                                height: int.Parse(Settings.Default.secondSizeHeight),
                                row: int.Parse(Settings.Default.secondSizeRowQty),
                                column: int.Parse(Settings.Default.secondSizeColumnQty)
                            );

                        //await Task.Run(() => CreateImageOld(outputFilePath, img));
                        await Task.Run(() => createImage(outputFilePath, img, sizeOne, sizeTwo, borderSize));
                    }
                    _progressBar.Value = i + 1;
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

        /*        public async Task ConvertPhotos(CancellationToken token, string _folderPath, string _outputPath, ProgressBar _progressBar, Label _label)
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

                            //var outputFilePath = Path.Combine(outputFolderPath, $"img{i}.jpg");
                            var filename = Path.GetFileName(imagePaths[i]);
                            var outputFilePath = Path.Combine(outputFolderPath, filename);

                            if (!File.Exists(outputFilePath))
                            {
                                await Task.Run(() => CreateImage(outputFilePath, img));

                            }
                            _progressBar.Value = i + 1;
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
        */
        void CreateImageOld(string outputFileName, string images)
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

        void createImage(string outputFileName, string image, PhotoSizeModel sizeOne, PhotoSizeModel sizeTwo, double borderSize)
        {
            int space = 10;
            var canvasWidth = measurementHelpers.ConvertToPixel(15, 300);
            var canvasHeight = measurementHelpers.ConvertToPixel(10, 300);

            using (Bitmap collageBitmap = new Bitmap(width: canvasWidth, height: canvasHeight))
            {
                Graphics g = Graphics.FromImage(collageBitmap);
                g.Clear(Color.White);

                double x = 0 + space;
                double y = 0 + space;

                //check the first size, if it fits in the canvas.
                var totalWidth = (x + sizeOne.width) * sizeOne.column;
                var totalHeight = (y + sizeOne.height) * sizeOne.row;

                DrawImagesOnCanvas(collageBitmap, Bitmap.FromFile(image), sizeOne, space, x, y, borderSize);

                x = ((sizeOne.width + space) * sizeOne.column) + space;

                DrawImagesOnCanvas(collageBitmap, Bitmap.FromFile(image), sizeTwo, space, x, y, borderSize);

                SaveCanvas(collageBitmap, outputFileName);
            }
        }

        public Bitmap CreateImage(Image bitmap, PictureBox pictureBox, PhotoSizeModel sizeOne, PhotoSizeModel sizeTwo)
        {
            int space = 10;

            /*            int canvasWidth = 1772;
                        int canvasHeight = 1181;*/

            Bitmap collageBitmap = new Bitmap(width: pictureBox.Width, height: pictureBox.Height);

            Graphics g = Graphics.FromImage(collageBitmap);
            g.Clear(Color.White);

            double x_increment = sizeOne.width + space;
            double y_increment = sizeOne.height + space;

            //total x and y axises.. initially just 10 pixels
            double x = 0 + 10;
            double y = 0 + 10;

            DrawImagesOnCanvas(collageBitmap, bitmap, sizeOne, x, y, x_increment, y_increment, space, true);

            x = x_increment * (sizeOne.Amount / 2) + (space);
            y_increment = sizeTwo.height + space;
            x_increment = sizeTwo.width + space;

            DrawImagesOnCanvas(collageBitmap, bitmap, sizeTwo, x, y, x_increment, y_increment, space, false);

            return collageBitmap;

        }

        public Bitmap CreateImageByColumnsAndRows(Image bitmap, PictureBox pictureBox, PhotoSizeModel sizeOne, PhotoSizeModel sizeTwo, double borderSize)
        {
            try
            {
                int space = 10;

                Bitmap collageBitmap = new Bitmap(width: pictureBox.Width, height: pictureBox.Height);

                Graphics g = Graphics.FromImage(collageBitmap);
                g.Clear(Color.White);

                double x = 0 + space;
                double y = 0 + space;

                //check the first size, if it fits in the canvas.
                var totalWidth = (x + sizeOne.width) * sizeOne.column;
                var totalHeight = (y + sizeOne.height) * sizeOne.row;

                DrawImagesOnCanvas(collageBitmap, bitmap, sizeOne, space, x, y, borderSize);

                x = ((sizeOne.width + space) * sizeOne.column) + space;

                DrawImagesOnCanvas(collageBitmap, bitmap, sizeTwo, space, x, y, borderSize);

                totalWidth = x + ((sizeTwo.width + space) * sizeTwo.column);
                totalHeight = Math.Max(y + ((sizeTwo.height + space) * sizeTwo.row), totalHeight);

                if (totalWidth > pictureBox.Width || totalHeight > pictureBox.Height)
                {
                    return null;
                }

                return collageBitmap;
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }
        void DrawImagesOnCanvas(Bitmap collageBitmap, Image bitmap, PhotoSizeModel size, int space, double x, double y, double borderSize)
        {
            Graphics graphics = Graphics.FromImage(collageBitmap);

            for (int j = 0; j < size.column; j++)
            {
                for (int i = 0; i < size.row; i++)
                {
                    var rectangle = new Rectangle(x: (int)(x + j * (size.width + space)), y: (int)(y + (i * (size.height + space))), (int)(size.width), (int)(size.height));
                    DrawImageWithBorder(graphics, bitmap, rectangle, float.Parse(borderSize.ToString()));
                }
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

        void DrawImageWithBorder(Graphics g, Image image, Rectangle rect, float borderWidth = 1)
        {
            g.DrawImage(image, rect);
            g.DrawRectangle(new Pen(Brushes.Black, borderWidth), rect);
        }
        Tuple<int, int> DrawImagesOnCanvas(Bitmap collageBitmap, Image bitmap, PhotoSizeModel size, double x, double y, double x_increment, double y_increment, double space, bool firstSize)
        {
            var x_stopped_at = x;
            var y_stopped_at = y;

            Graphics graphics = Graphics.FromImage(collageBitmap);
            var rectangle = new Rectangle((int)x, (int)y, (int)(size.width), (int)(size.height));


            for (int i = 1; i <= size.Amount; i++)
            {
                DrawImageWithBorder(graphics, bitmap, rectangle, 5);

                if (firstSize)
                {
                    //x += x_increment;
                    if (i % (size.Amount / 2) == 0)
                    {
                        y += y_increment;

                        //because it pushed the y axis twice.. when it came to the second or third row. so divide it by half
                        x = space;
                    }
                    else
                    {
                        x += x_increment;
                    }
                }
                else
                {
                    //x += x_increment;
                    if (i % (size.Amount / 2) == 0)
                    {
                        y += y_increment;
                        x = x_stopped_at;
                    }
                    else
                    {
                        x += x_increment;
                    }
                }

                rectangle.Location = new Point((int)x, (int)y);
            }

            return new Tuple<int, int>((int)x, (int)y);

            //graphics.Dispose();
        }


        public bool GetRemainingSpace(PictureBox pictureBox, PhotoSizeModel firstSize, PhotoSizeModel secondSize)
        {
            var firstWidthTotal = (firstSize.width + 20) * (firstSize.Amount / 2);
            var secondWidthTotal = (secondSize.width + 20) * (secondSize.Amount / 2);

            var firstHeightTotal = (firstSize.height + 20) * 2;
            var secondHeightTotal = (secondSize.height + 20) * (secondSize.Amount / 2);


            var totalWidth = firstWidthTotal + secondWidthTotal;
            if (Math.Max(firstHeightTotal, secondHeightTotal) >= pictureBox.Height)
            {
                var ssdad = Math.Max(firstHeightTotal, secondHeightTotal);
                var fff = ssdad >= pictureBox.Height;

                return true;
            }
            return false;
        }
    }
}
