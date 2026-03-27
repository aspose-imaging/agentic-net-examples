using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.FileFormats.Tiff;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output\\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data as JpegExifData
            var exif = image.ExifData as Aspose.Imaging.Exif.JpegExifData;
            if (exif != null)
            {
                // Set GPS latitude (e.g., 37°0'0" N)
                exif.GPSLatitude = new TiffRational[]
                {
                    new TiffRational(37, 1),
                    new TiffRational(0, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLatitudeRef = "N";

                // Set GPS longitude (e.g., 122°0'0" W)
                exif.GPSLongitude = new TiffRational[]
                {
                    new TiffRational(122, 1),
                    new TiffRational(0, 1),
                    new TiffRational(0, 1)
                };
                exif.GPSLongitudeRef = "W";
            }

            // Save the image with updated EXIF data
            image.Save(outputPath);
        }
    }
}