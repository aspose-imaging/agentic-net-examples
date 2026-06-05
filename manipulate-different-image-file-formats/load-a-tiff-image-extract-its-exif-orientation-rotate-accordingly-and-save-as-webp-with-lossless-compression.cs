using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.tif";
            string outputPath = @"C:\Images\output.webp";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TIFF image
            using (Image image = Image.Load(inputPath))
            {
                // Auto‑rotate according to EXIF orientation if possible
                if (image is RasterImage raster)
                {
                    raster.AutoRotate();
                }

                // Save as lossless WebP
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };
                image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert high‑resolution TIFF photographs that contain EXIF orientation metadata into web‑friendly lossless WebP files for faster page loads.
 * 2. When an e‑commerce platform must automatically rotate product images stored as TIFFs based on their EXIF orientation and save them as lossless WebP to preserve quality while reducing storage costs.
 * 3. When a digital archiving system requires batch processing of scanned TIFF documents, correcting their orientation and storing them in a compact, lossless WebP format for long‑term preservation.
 * 4. When a mobile app backend processes user‑uploaded TIFF images, normalizes their orientation, and serves them as lossless WebP to ensure consistent display across devices.
 * 5. When a content management system integrates Aspose.Imaging in C# to transform legacy TIFF assets with embedded orientation tags into lossless WebP images for SEO‑optimized web publishing.
 */