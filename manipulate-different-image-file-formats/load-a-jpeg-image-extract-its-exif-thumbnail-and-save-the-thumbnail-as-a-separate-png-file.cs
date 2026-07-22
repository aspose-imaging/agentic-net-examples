using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.Exif;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.jpg";
        string outputPath = @"C:\Images\thumbnail.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Access EXIF thumbnail
                RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;

                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Save thumbnail as PNG
                var pngOptions = new PngOptions();
                thumbnail.Save(outputPath, pngOptions);
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
 * 1. When a developer needs to create a quick preview for a photo gallery, they can extract the embedded EXIF thumbnail from a JPEG and save it as a lightweight PNG file.
 * 2. When building a digital asset management system that displays thumbnail icons, this code lets the application pull the original EXIF thumbnail and store it in a PNG format for consistent rendering.
 * 3. When optimizing a mobile app’s image loading speed, developers can use the EXIF thumbnail extraction to generate low‑resolution PNG placeholders without re‑encoding the full‑size JPEG.
 * 4. When archiving photographs and preserving their original preview images, the code extracts the JPEG’s EXIF thumbnail and saves it as a separate PNG for easy catalog browsing.
 * 5. When implementing a batch‑processing tool that converts embedded JPEG thumbnails to PNG for compatibility with web standards, this snippet handles the loading, extraction, and conversion in C#.
 */