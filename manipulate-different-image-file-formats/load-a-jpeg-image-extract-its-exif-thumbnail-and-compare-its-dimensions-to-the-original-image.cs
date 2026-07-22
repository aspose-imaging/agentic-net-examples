using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded paths
        string inputPath = "sample.jpg";
        string outputPath = "thumbnail_output.jpg";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF data
                JpegExifData jpegExif = jpegImage.ExifData as JpegExifData;
                if (jpegExif == null)
                {
                    Console.WriteLine("No EXIF data found in the image.");
                    return;
                }

                // Get thumbnail
                RasterImage thumbnail = jpegExif.Thumbnail;
                if (thumbnail == null)
                {
                    Console.WriteLine("No EXIF thumbnail present.");
                    return;
                }

                // Compare dimensions
                Console.WriteLine($"Original image size: {jpegImage.Width}x{jpegImage.Height}");
                Console.WriteLine($"Thumbnail size: {thumbnail.Width}x{thumbnail.Height}");

                // Save thumbnail (output directory creation)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                thumbnail.Save(outputPath);
                Console.WriteLine($"Thumbnail saved to: {outputPath}");
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
 * 1. When building a photo‑gallery web application that needs fast preview images, a developer can load each JPEG, extract its EXIF thumbnail, compare the thumbnail dimensions to the original, and decide whether to display the thumbnail or generate a new preview.
 * 2. When creating a digital asset‑management system that validates image metadata, a developer can load a JPEG, read the embedded EXIF thumbnail, compare its size to the full‑resolution image, and flag files with missing or corrupted thumbnails.
 * 3. When optimizing storage for a mobile app, a developer can extract the EXIF thumbnail from a JPEG, compare its resolution to the original image, and use the smaller thumbnail as a low‑resolution placeholder to reduce bandwidth.
 * 4. When implementing a batch‑processing tool that archives image previews, a developer can load each JPEG, retrieve the EXIF thumbnail, verify its dimensions against the source image, and save the thumbnail to a designated output folder.
 * 5. When developing a forensic analysis utility to check image authenticity, a developer can load a JPEG, pull the EXIF thumbnail, compare its width and height to the main image, and detect mismatched metadata that may indicate tampering.
 */