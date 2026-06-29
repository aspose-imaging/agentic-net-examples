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
            string inputPath = "sample.jpg";
            string outputPath = "output.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Original image dimensions
                int originalWidth = jpegImage.Width;
                int originalHeight = jpegImage.Height;

                // Access EXIF data and thumbnail
                JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
                if (jpegExif?.Thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail present.");
                }
                else
                {
                    RasterImage thumbnail = jpegExif.Thumbnail;
                    int thumbWidth = thumbnail.Width;
                    int thumbHeight = thumbnail.Height;

                    // Output sizes
                    Console.WriteLine($"Original image size: {originalWidth}x{originalHeight}");
                    Console.WriteLine($"Thumbnail size: {thumbWidth}x{thumbHeight}");

                    // Compare dimensions
                    if (thumbWidth < originalWidth && thumbHeight < originalHeight)
                    {
                        Console.WriteLine("Thumbnail is smaller than the original image.");
                    }
                    else
                    {
                        Console.WriteLine("Thumbnail is not smaller than the original image.");
                    }

                    // Write comparison result to output file
                    File.WriteAllText(outputPath,
                        $"Original: {originalWidth}x{originalHeight}{Environment.NewLine}" +
                        $"Thumbnail: {thumbWidth}x{thumbHeight}{Environment.NewLine}");
                }
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
 * 1. When building a photo‑gallery web app that generates preview images, a developer can use this code to read the embedded EXIF thumbnail of a JPEG and verify it is smaller than the full‑size image before displaying it as a quick preview.
 * 2. When creating a digital asset management system that validates image metadata, a developer can extract the EXIF thumbnail and compare its dimensions to the original to ensure the thumbnail complies with size constraints.
 * 3. When optimizing storage for a mobile app that syncs photos, a developer can read the JPEG’s EXIF thumbnail and check if it is already sufficiently reduced, avoiding unnecessary re‑encoding of a smaller preview.
 * 4. When implementing a forensic analysis tool that examines image authenticity, a developer can retrieve the EXIF thumbnail and compare its size to the main image to detect mismatched or tampered thumbnails.
 * 5. When developing a batch‑processing script that logs image information, a developer can use this code to output both the original JPEG dimensions and its EXIF thumbnail dimensions to a text file for reporting purposes.
 */