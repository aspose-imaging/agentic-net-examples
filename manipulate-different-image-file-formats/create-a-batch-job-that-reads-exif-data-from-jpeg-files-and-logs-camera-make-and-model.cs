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
        string outputPath = @"C:\Logs\exif_log.txt";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (var image = (JpegImage)Image.Load(inputPath))
        {
            // Cast EXIF data to JPEG-specific EXIF container
            var jpegExif = image.ExifData as JpegExifData;

            // Retrieve camera make and model, fallback to "Unknown" if missing
            string make = jpegExif?.Make ?? "Unknown";
            string model = jpegExif?.Model ?? "Unknown";

            // Prepare log content
            string log = $"Camera Make: {make}{Environment.NewLine}Camera Model: {model}";

            // Output to console
            Console.WriteLine(log);

            // Write log to the output file
            File.WriteAllText(outputPath, log);
        }
    }
}