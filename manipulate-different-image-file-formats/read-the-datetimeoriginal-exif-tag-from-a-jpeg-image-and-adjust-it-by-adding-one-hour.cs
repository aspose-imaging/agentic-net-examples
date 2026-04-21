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
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists (unconditional)
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to JpegImage to access EXIF data
            JpegImage jpeg = image as JpegImage;
            if (jpeg != null && jpeg.ExifData != null)
            {
                string original = jpeg.ExifData.DateTimeOriginal;
                if (!string.IsNullOrEmpty(original))
                {
                    // EXIF DateTimeOriginal format: "yyyy:MM:dd HH:mm:ss"
                    if (DateTime.TryParseExact(
                        original,
                        "yyyy:MM:dd HH:mm:ss",
                        System.Globalization.CultureInfo.InvariantCulture,
                        System.Globalization.DateTimeStyles.None,
                        out DateTime dt))
                    {
                        // Add one hour
                        dt = dt.AddHours(1);
                        // Write back in the same format
                        jpeg.ExifData.DateTimeOriginal = dt.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                }
            }

            // Save the modified image
            jpeg.Save(outputPath);
        }
    }
}