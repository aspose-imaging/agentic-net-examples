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
            // Hardcoded input and output file paths
            string inputPath = @"C:\Images\input.jpg";
            string outputPath = @"C:\Images\output.jpg";

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
                // Access EXIF data
                JpegExifData exif = image.ExifData as JpegExifData;
                if (exif != null)
                {
                    // Set the DateTimeOriginal tag (format: "yyyy:MM:dd HH:mm:ss")
                    exif.DateTimeOriginal = "2023:01:01 12:00:00";
                }
                else
                {
                    Console.Error.WriteLine("No EXIF data found in the image.");
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