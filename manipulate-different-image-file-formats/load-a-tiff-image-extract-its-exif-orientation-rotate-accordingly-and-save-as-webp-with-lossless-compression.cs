using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Webp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.tif";
        string outputPath = @"C:\Images\output.webp";

        // Ensure any runtime exception is reported cleanly
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

            // Load the TIFF image
            using (Image img = Image.Load(inputPath))
            {
                // Cast to RasterImage to access AutoRotate (works for TIFF as well)
                if (img is RasterImage rasterImg)
                {
                    // Rotate according to EXIF orientation
                    rasterImg.AutoRotate();
                }

                // Prepare WebP options for lossless compression
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save the image as WebP using the lossless options
                img.Save(outputPath, webpOptions);
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
 * 1. When a photographer needs to batch‑convert scanned TIFF files to web‑optimized lossless WebP images while automatically correcting orientation from EXIF metadata.
 * 2. When a medical imaging system must deliver high‑quality TIFF scans as smaller, lossless WebP files for faster web viewing without losing diagnostic detail.
 * 3. When an e‑commerce platform wants to display product photos originally stored as TIFFs in browsers, ensuring they appear upright and use lossless WebP to reduce bandwidth.
 * 4. When a digital archiving solution requires preserving the exact visual appearance of legacy TIFF documents while storing them in a modern, lossless WebP format for long‑term storage.
 * 5. When a mobile app processes user‑uploaded TIFF images, rotates them according to EXIF orientation, and saves them as lossless WebP to maintain quality and improve load times.
 */