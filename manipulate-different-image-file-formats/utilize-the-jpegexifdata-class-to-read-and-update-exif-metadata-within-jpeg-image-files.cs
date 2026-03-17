using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        // Input and output JPEG file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data
            var exif = image.ExifData;
            if (exif != null)
            {
                // Cast to JpegExifData (fully qualified to avoid extra using)
                var jpegExif = exif as Aspose.Imaging.Exif.JpegExifData;
                if (jpegExif != null)
                {
                    // Read some existing tags
                    Console.WriteLine($"Original Make: {jpegExif.Make}");
                    Console.WriteLine($"Original Model: {jpegExif.Model}");

                    // Update EXIF tags
                    jpegExif.Make = "MyCameraMaker";
                    jpegExif.Model = "MyCameraModel";
                    jpegExif.Artist = "John Doe";
                    jpegExif.Copyright = "© 2026 MyCompany";
                }
            }

            // Save the image with updated EXIF metadata
            image.Save(outputPath);
        }
    }
}