using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
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
                using (JpegImage thumb = new JpegImage(new JpegOptions(), 50, 50))
                {
                    Graphics graphics = new Graphics(thumb);
                    var brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, thumb.Bounds);

                    jpegImage.Jfif = new JFIFData();
                    jpegImage.Jfif.Thumbnail = thumb;

                    jpegImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}