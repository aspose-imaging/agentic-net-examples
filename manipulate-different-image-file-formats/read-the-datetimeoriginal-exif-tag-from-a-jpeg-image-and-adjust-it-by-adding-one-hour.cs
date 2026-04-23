using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        try
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
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                JpegExifData jpegExif = image.ExifData as JpegExifData;
                if (jpegExif != null && !string.IsNullOrEmpty(jpegExif.DateTimeOriginal))
                {
                    // Parse the original DateTime string (format: "yyyy:MM:dd HH:mm:ss")
                    if (DateTime.TryParseExact(
                            jpegExif.DateTimeOriginal,
                            "yyyy:MM:dd HH:mm:ss",
                            System.Globalization.CultureInfo.InvariantCulture,
                            System.Globalization.DateTimeStyles.None,
                            out DateTime originalDate))
                    {
                        // Add one hour
                        DateTime updatedDate = originalDate.AddHours(1);

                        // Write back in the same EXIF format
                        jpegExif.DateTimeOriginal = updatedDate.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                }

                // Save the modified image
                image.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}