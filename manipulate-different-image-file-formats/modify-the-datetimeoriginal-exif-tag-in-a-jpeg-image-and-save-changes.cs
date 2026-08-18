// HOW-TO: How to Change DateTimeOriginal EXIF Tag in JPEG Using C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;

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

            // Load JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Modify the DateTimeOriginal EXIF tag if EXIF data is present
                if (image.ExifData != null)
                {
                    // Set to desired date/time in EXIF format (yyyy:MM:dd HH:mm:ss)
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

/*
 * Real-World Use Cases:
 * 1. When you need to correct the original capture date of a JPEG photo after the camera clock was wrong, you can update the DateTimeOriginal EXIF tag with C# and Aspose.Imaging.
 * 2. When migrating images to a digital asset management system that relies on accurate EXIF timestamps for sorting, you can programmatically set the DateTimeOriginal field.
 * 3. When preparing a batch of photos for legal evidence, you may need to ensure the recorded capture time matches documented timestamps, which can be done by modifying the EXIF tag in C#.
 * 4. When creating a photo‑sharing application that displays images based on their original shooting date, you can adjust the DateTimeOriginal metadata before publishing.
 * 5. When automating image processing pipelines that require consistent metadata for downstream analytics, you can use Aspose.Imaging to set the DateTimeOriginal tag in each JPEG file.
 */
