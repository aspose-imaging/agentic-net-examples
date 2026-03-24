using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\sample_updated.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access EXIF data as JpegExifData
            JpegExifData exif = image.ExifData as JpegExifData;
            if (exif != null)
            {
                // Update desired EXIF tags
                exif.Artist = "John Doe";
                exif.Copyright = "© 2026 John Doe";
                exif.ImageDescription = "Updated image with new EXIF data";

                // Auto-rotate based on orientation (ignore out-of-range errors)
                try
                {
                    image.AutoRotate();
                }
                catch (ArgumentOutOfRangeException)
                {
                    // Orientation value is invalid; continue without rotation
                }
            }

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}