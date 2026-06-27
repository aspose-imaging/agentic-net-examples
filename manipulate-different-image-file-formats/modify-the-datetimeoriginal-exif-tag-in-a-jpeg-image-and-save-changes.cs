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

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                JpegExifData exif = image.ExifData as JpegExifData;
                if (exif != null)
                {
                    // Set DateTimeOriginal to current date/time in EXIF format
                    exif.DateTimeOriginal = DateTime.Now.ToString("yyyy:MM:dd HH:mm:ss");
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
 * 1. When a developer needs to correct the capture timestamp of a JPEG photo after it was imported from a camera with an incorrect clock, they can use Aspose.Imaging for .NET to update the DateTimeOriginal EXIF tag in C#.
 * 2. When building a photo‑organizing application that sorts images by the original shooting date, the code can rewrite the DateTimeOriginal field of JPEG files to ensure accurate chronological ordering.
 * 3. When integrating a digital asset management system that receives images from multiple sources, developers can standardize the EXIF DateTimeOriginal metadata using the provided C# example to maintain consistent metadata across JPEG assets.
 * 4. When creating a batch‑processing tool that fixes timezone discrepancies in JPEG metadata, the Aspose.Imaging library allows you to programmatically set the DateTimeOriginal tag to the correct local time before saving the image.
 * 5. When implementing a compliance workflow that requires all uploaded JPEGs to contain a valid capture date, the snippet demonstrates how to validate the file, modify the DateTimeOriginal EXIF tag, and save the updated image using C# and Aspose.Imaging.
 */