using System;
using System.IO;
using System.Globalization;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.jpg";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                var exif = image.ExifData;
                if (exif != null && !string.IsNullOrEmpty(exif.DateTimeOriginal))
                {
                    // Parse the original DateTime string (format: "yyyy:MM:dd HH:mm:ss")
                    if (DateTime.TryParseExact(
                            exif.DateTimeOriginal,
                            "yyyy:MM:dd HH:mm:ss",
                            CultureInfo.InvariantCulture,
                            DateTimeStyles.None,
                            out DateTime originalDateTime))
                    {
                        // Add one hour
                        DateTime updatedDateTime = originalDateTime.AddHours(1);

                        // Write back in the same format
                        exif.DateTimeOriginal = updatedDateTime.ToString("yyyy:MM:dd HH:mm:ss");
                    }
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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