using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

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

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                Aspose.Imaging.Exif.JpegExifData exif = image.ExifData;
                if (exif == null)
                {
                    exif = new Aspose.Imaging.Exif.JpegExifData();
                    image.ExifData = exif;
                }

                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1),
                    new TiffRational(0, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLatitudeRef = "N";

                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1),
                    new TiffRational(0, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLongitudeRef = "W";

                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}