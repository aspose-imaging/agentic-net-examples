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
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Rotate according to EXIF orientation
                raster.AutoRotate();

                // Prepare lossless WebP options
                var webpOptions = new WebPOptions
                {
                    Lossless = true
                };

                // Save as WebP with lossless compression
                raster.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to convert scanned TIFF documents that contain EXIF orientation metadata into web‑optimized lossless WebP images for faster page loads.
 * 2. When an e‑commerce platform must automatically correct the orientation of product photos stored as TIFF files and store them as lossless WebP to preserve quality while reducing bandwidth.
 * 3. When a mobile app backend processes user‑uploaded TIFF images, rotates them based on EXIF data, and saves them as lossless WebP to ensure consistent display across devices.
 * 4. When a digital archiving system requires batch conversion of legacy TIFF assets, applying AutoRotate to fix orientation and using Aspose.Imaging to generate lossless WebP files for long‑term storage.
 * 5. When a content management system needs to generate SEO‑friendly, web‑ready images by reading EXIF orientation from TIFF files, rotating them correctly, and exporting them as lossless WebP using C#.
 */