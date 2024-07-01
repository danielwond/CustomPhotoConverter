using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CustomPhotoConverter.Helpers
{
    public class ConversionHelper
    {

        //string folderPath = @"C:\Users\ddpro\Desktop\New folder (10)";
        private readonly string _folderPath = "";
        private readonly string _outputPath = "";

        public ConversionHelper(string folderPath, string outputPath)
        {
            _folderPath = folderPath;
            _outputPath = outputPath;
        }

        public void ConvertPhotos()
        {
            List<string> imagePaths = GetImagesFromFolder(_folderPath);

            for (int i = 0; i < imagePaths.Count; i++)
            {
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

                CreateImage(outputFilePath, img);
            }

        }
        void CreateImage(string outputFileName, string images)
        {
            const int imagesPerRow = 4; // Adjust as needed

            int spacing = 10;
            int canvasWidth = GetCanvasSize()["Width"];
            int canvasHeight = GetCanvasSize()["Height"];
            int imageWidth = GetImgSize()["Width"];
            int imageHeight = GetImgSize()["Height"];
            int imgWidthSmall = GetImgSize()["SmallWidth"];
            int imgHeightSmall = GetImgSize()["SmallHeight"];

            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

            using (Bitmap collageBitmap = new Bitmap(width: canvasWidth, height: canvasHeight))
            {

                int imageCount = 6; // Limit to fit within canvas

                //int imageHeight = canvasHeight / (imageCount / imagesPerRow); // Adjust for even distribution
                Graphics g = Graphics.FromImage(collageBitmap);
                g.Clear(Color.White);

                List<Point> endingPositions = new List<Point>();

                for (int i = 0; i < imageCount; i++)
                {
                    int x = (i % imagesPerRow) * (imageWidth + spacing) + spacing;
                    int y = (i / imagesPerRow) * (imageHeight + spacing) + spacing;


                    using (var image = Image.FromFile(images))
                    {
                        using (Graphics graphics = Graphics.FromImage(collageBitmap))
                        {
                            graphics.DrawImage(image, new Rectangle(x, y, imageWidth, imageHeight));
                            graphics.DrawRectangle(new Pen(Brushes.Black, 5), new Rectangle(x, y, imageWidth, imageHeight));
                        }

                    }
                    endingPositions.Add(new Point(x + imageWidth, y + imageHeight));

                }
                // Get ending position of the last large image
                Point lastImageEndingPosition = endingPositions[endingPositions.Count - 1];

                // Calculate X coordinate for the small image (next to the last image)
                int smallImageX = lastImageEndingPosition.X + spacing;
                int increment = 250; // Amount to add in each iteration

                for (int i = 0; i < 4; i++)
                {

                    // Calculate Y coordinate for the small image (adjust as needed)
                    int smallImageY = 492 + spacing; // Adjust for vertical arrangement

                    using (var image = Image.FromFile(images))
                    {
                        using (Graphics graphics = Graphics.FromImage(collageBitmap))
                        {
                            graphics.DrawImage(image, new Rectangle(smallImageX, smallImageY, imgWidthSmall, imgHeightSmall));
                            graphics.DrawRectangle(new Pen(Brushes.Black, 5), new Rectangle(smallImageX, smallImageY, imgWidthSmall, imgHeightSmall));
                        }
                    }
                    smallImageX += increment;
                    smallImageY += increment;
                }

                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, (long)90); // Adjust quality (0-100)

                var path = outputFileName.Split('\\').ToList();
                if(path.Count > 7)
                {
                    Console.WriteLine("HHHHHH");
                }


                // Save the collage image to a file
                collageBitmap.Save(outputFileName, jgpEncoder, encoderParams); // Or your preferred format
            }
        }

        List<string> GetImagesFromFolder(string folderPath)
        {
            List<string> imagePaths = Directory.EnumerateFiles(folderPath, "*.jpg", SearchOption.AllDirectories).ToList();
            return imagePaths;
        }

        Dictionary<string, int> GetCanvasSize()
        {
            Image img = Image.FromFile(@"C:\Users\ddpro\Desktop\white.jpg");

            return new Dictionary<string, int>()
            {
                {"Height", img.Height }, {"Width", img.Width}
            };
        }

        Dictionary<string, int> GetImgSize()
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(@"C:\Users\ddpro\Desktop\img\Untitled-1.jpg");
            System.Drawing.Image smallImg = System.Drawing.Image.FromFile(@"C:\Users\ddpro\Desktop\img\2x2.jpg");

            return new Dictionary<string, int>()
    {
        {"Height", img.Height }, {"Width", img.Width}, {"SmallHeight" , smallImg.Height}, {"SmallWidth", smallImg.Width}
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

        /*
         *For downloading sample images
        for(int i=0; i<100; i++)
        {
            var url = $"https://ozgrozer.github.io/100k-faces/0/8/0088{i:D2}.jpg";

            if(i == 10)
            {
                Console.WriteLine("sdkads");
            }
            using var client = new HttpClient();
            client.BaseAddress = new Uri(url);
            HttpResponseMessage response = await client.GetAsync(url);
            var resp = await response.Content.ReadAsByteArrayAsync();
            var path = Path.Combine("Photos", i.ToString() + ".jpg");
            if (!Directory.Exists("Photos"))
            {
                Directory.CreateDirectory("Photos");
            }

            File.WriteAllBytes(path, resp);
        }
        */
    }
}
