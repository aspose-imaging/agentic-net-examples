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
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/sample_geotagged.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                var exif = image.ExifData;
                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1),
                    new TiffRational(46, 1),
                    new TiffRational(2964, 100)
                };
                exif.GPSLatitudeRef = "N";
                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1),
                    new TiffRational(25, 1),
                    new TiffRational(984, 100)
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