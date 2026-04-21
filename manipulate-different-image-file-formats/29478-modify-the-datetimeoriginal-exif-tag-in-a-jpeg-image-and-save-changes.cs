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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

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
                // Modify the DateTimeOriginal EXIF tag if EXIF data is present
                if (image.ExifData != null)
                {
                    // Set to desired date and time in EXIF format (YYYY:MM:DD HH:MM:SS)
                    image.ExifData.DateTimeOriginal = "2023:01:01 12:00:00";
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