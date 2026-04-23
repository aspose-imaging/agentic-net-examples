using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;
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

            using (JpegImage image = new JpegImage(inputPath))
            {
                if (image.ExifData == null)
                {
                    image.ExifData = new JpegExifData();
                }

                if (image.Jfif == null)
                {
                    image.Jfif = new JFIFData();
                }

                using (JpegImage thumb = new JpegImage(100, 100))
                {
                    Graphics graphics = new Graphics(thumb);
                    SolidBrush brush = new SolidBrush(Color.Blue);
                    graphics.FillRectangle(brush, thumb.Bounds);

                    image.ExifData.Thumbnail = thumb;
                    image.Jfif.Thumbnail = thumb;

                    image.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}