using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to JpegImage to access EXIF data
            JpegImage jpeg = (JpegImage)image;

            // Get EXIF data
            var exif = jpeg.ExifData;

            // Read DateTimeOriginal, parse, add one hour, and write back
            string original = exif.DateTimeOriginal;
            if (!string.IsNullOrEmpty(original))
            {
                // EXIF date format: "yyyy:MM:dd HH:mm:ss"
                if (DateTime.TryParseExact(original, "yyyy:MM:dd HH:mm:ss",
                    System.Globalization.CultureInfo.InvariantCulture,
                    System.Globalization.DateTimeStyles.None, out DateTime dt))
                {
                    DateTime updated = dt.AddHours(1);
                    exif.DateTimeOriginal = updated.ToString("yyyy:MM:dd HH:mm:ss");
                }
            }

            // Save the modified image
            jpeg.Save(outputPath, new JpegOptions());
        }
    }
}