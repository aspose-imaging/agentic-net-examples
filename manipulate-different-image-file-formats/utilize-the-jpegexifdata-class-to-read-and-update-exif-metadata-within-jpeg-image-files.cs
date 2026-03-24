using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\temp\input.jpg";
        string outputPath = @"C:\temp\output\updated.jpg";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (JpegImage image = (JpegImage)Image.Load(inputPath))
        {
            // Access the EXIF data container specific to JPEG
            JpegExifData jpegExif = image.ExifData as JpegExifData;

            if (jpegExif != null)
            {
                // Update some EXIF tags
                jpegExif.Artist = "John Doe";
                jpegExif.Copyright = "© 2026 John Doe";
                jpegExif.ImageDescription = "Updated description via Aspose.Imaging";
            }
            else
            {
                // If no EXIF data exists, create a new container and assign it
                jpegExif = new JpegExifData();
                jpegExif.Artist = "John Doe";
                jpegExif.Copyright = "© 2026 John Doe";
                jpegExif.ImageDescription = "Created EXIF data via Aspose.Imaging";
                image.ExifData = jpegExif;
            }

            // Save the modified image to the output path
            image.Save(outputPath);
        }
    }
}