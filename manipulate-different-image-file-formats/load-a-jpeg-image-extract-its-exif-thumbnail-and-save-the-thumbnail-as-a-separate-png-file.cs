// HOW-TO: Extract EXIF Thumbnail From JPEG and Save As PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "sample.jpg";
        string outputPath = "thumbnail.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load JPEG image
            using (JpegImage jpegImage = (JpegImage)Image.Load(inputPath))
            {
                // Get EXIF thumbnail
                RasterImage thumbnail = jpegImage.ExifData?.Thumbnail;
                if (thumbnail == null)
                {
                    Console.Error.WriteLine("No EXIF thumbnail found in the image.");
                    return;
                }

                // Save thumbnail as PNG
                using (thumbnail)
                {
                    thumbnail.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate lightweight preview images for a photo gallery by extracting embedded EXIF thumbnails from high‑resolution JPEG files and converting them to PNG format.
 * 2. When building a digital asset management system that must display quick thumbnails without re‑encoding the original JPEG, using the stored EXIF thumbnail to improve performance.
 * 3. When creating a backup script that extracts and stores the original camera‑generated thumbnails from JPEG photos as separate PNG files for archival or analysis.
 * 4. When developing a mobile app that requires small PNG icons derived from the EXIF thumbnail of user‑uploaded JPEGs to reduce bandwidth and memory usage.
 * 5. When implementing a batch process that validates the presence of EXIF thumbnails in JPEGs and saves any found thumbnails as PNGs for further processing or quality checks.
 */
