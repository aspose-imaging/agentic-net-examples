// HOW-TO: Read JPEG EXIF Camera Make and Model and Log with C# (Aspose.Imaging for .NET)
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
        string outputPath = @"C:\Images\exif_log.txt";

        try
        {
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
                // Access EXIF data
                JpegExifData jpegExif = image.ExifData as JpegExifData;

                // Prepare log content
                string make = jpegExif?.Make ?? "Unknown";
                string model = jpegExif?.Model ?? "Unknown";
                string logLine = $"Camera Make: {make}, Model: {model}";

                // Write to console
                Console.WriteLine(logLine);

                // Append to log file
                File.AppendAllText(outputPath, logLine + Environment.NewLine);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate a report of camera models used for a photo shoot by extracting EXIF data from JPEG files with Aspose.Imaging in C#.
 * 2. When an application must verify that uploaded JPEG images come from approved camera manufacturers before further processing.
 * 3. When building a digital asset management system that catalogs images based on their make and model metadata extracted via Aspose.Imaging.
 * 4. When troubleshooting image quality issues by logging the camera make and model of each JPEG in a batch job.
 * 5. When creating an audit trail for compliance that records the source device information of stored JPEG images.
 */
