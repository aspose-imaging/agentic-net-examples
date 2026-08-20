// HOW-TO: Convert WebP to GIF while Preserving EXIF Orientation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\temp\input.webp";
            string outputPath = @"C:\temp\output.gif";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WebP image, apply EXIF orientation, and save as GIF
            using (WebPImage webPImage = new WebPImage(inputPath))
            {
                // Rotate according to EXIF orientation if present
                webPImage.AutoRotate();

                // Save to GIF format
                webPImage.Save(outputPath, new GifOptions());
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
 * 1. When you need to display user‑uploaded WebP photos in a legacy system that only supports GIF and must keep the original rotation.
 * 2. When converting images for email newsletters that require GIF format but the source WebP files contain EXIF orientation tags.
 * 3. When generating animated thumbnails from WebP assets for a web app that expects GIFs with correct orientation.
 * 4. When migrating a photo archive from WebP to GIF for compatibility with older browsers while preserving how the images were taken.
 * 5. When building a batch image‑processing tool that normalizes orientation and changes format from WebP to GIF for downstream processing.
 */
