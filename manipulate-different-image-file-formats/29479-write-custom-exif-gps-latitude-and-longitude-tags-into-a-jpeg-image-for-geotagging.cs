using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.jpg";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output.jpg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                if (exif == null)
                {
                    exif = new Aspose.Imaging.Exif.JpegExifData();
                }

                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1), // degrees
                    new TiffRational(0, 1),  // minutes
                    new TiffRational(0, 1)   // seconds
                };
                exif.GPSLatitudeRef = "N";

                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1), // degrees
                    new TiffRational(0, 1),   // minutes
                    new TiffRational(0, 1)    // seconds
                };
                exif.GPSLongitudeRef = "W";

                image.ExifData = exif;
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}