using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Gif.Blocks;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        int width = 300;
        int height = 300;

        using (GifImage gif = new GifImage(new GifFrameBlock((ushort)width, (ushort)height)))
        {
            using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Blue))
            {
                Point[] polygonPoints = new Point[]
                {
                    new Point(50, 50),
                    new Point(250, 70),
                    new Point(200, 250),
                    new Point(80, 200)
                };

                Graphics graphics = new Graphics(gif.ActiveFrame);
                graphics.Clear(Aspose.Imaging.Color.White);
                graphics.FillPolygon(brush, polygonPoints);
            }

            using (MemoryStream gifStream = new MemoryStream())
            {
                GifOptions gifOptions = new GifOptions();
                gif.Save(gifStream, gifOptions);
                gifStream.Position = 0;

                using (RasterImage raster = (RasterImage)Image.Load(gifStream))
                {
                    string jpegOutputPath = "output.jpg";
                    JpegOptions jpegOptions = new JpegOptions();
                    raster.Save(jpegOutputPath, jpegOptions);
                }
            }
        }
    }
}