using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
        {
            int thumbWidth = 100;
            int thumbHeight = 100;
            PngOptions thumbOptions = new PngOptions();

            using (RasterImage thumbImage = (RasterImage)Image.Create(thumbOptions, thumbWidth, thumbHeight))
            {
                Graphics graphics = new Graphics(thumbImage);
                SolidBrush brush = new SolidBrush(Color.Blue);
                graphics.FillRectangle(brush, thumbImage.Bounds);

                JFIFData jfif = new JFIFData();
                jfif.Thumbnail = thumbImage;
                jpegImage.Jfif = jfif;

                jpegImage.Save(outputPath);
            }
        }
    }
}