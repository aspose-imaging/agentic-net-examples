// HOW-TO: Read JPEG EXIF Camera Model Tag in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Wrap the whole logic to catch unexpected exceptions
        try
        {
            // Hardcoded input path (no argument validation)
            string inputPath = "sample.jpg";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the JPEG image
            using (JpegImage image = (JpegImage)Image.Load(inputPath))
            {
                // Access the EXIF data; cast to JpegExifData to get JPEG‑specific tags
                JpegExifData jpegExif = image.ExifData as JpegExifData;

                if (jpegExif != null)
                {
                    // Print the camera model tag
                    Console.WriteLine($"Camera model: {jpegExif.Model}");
                }
                else
                {
                    Console.WriteLine("No JPEG EXIF data found.");
                }
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When building a photo gallery app that displays the camera model for each uploaded JPEG image.
 * 2. When generating a report of equipment used in field photography by extracting camera model tags from image files.
 * 3. When validating that images were captured with a specific camera model before processing them in a workflow.
 * 4. When creating a digital asset management system that indexes JPEG files by their EXIF camera model metadata.
 * 5. When debugging image import pipelines by printing the camera model to verify correct EXIF extraction.
 */
