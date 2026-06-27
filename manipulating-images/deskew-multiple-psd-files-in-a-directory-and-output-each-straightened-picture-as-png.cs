using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output directories
            string inputDir = @"C:\Images\InputPsd";
            string outputDir = @"C:\Images\OutputPng";

            // Ensure the output directory exists (will also work for subfolders)
            Directory.CreateDirectory(outputDir);

            // Get all PSD files in the input directory
            string[] psdFiles = Directory.GetFiles(inputDir, "*.psd", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in psdFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the corresponding PNG output path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".png");

                // Ensure the output directory exists (covers possible subfolders)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the PSD image
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access deskew functionality
                    if (image is RasterImage rasterImage)
                    {
                        // Deskew the image (do not resize, use LightGray background)
                        rasterImage.NormalizeAngle(false, Color.LightGray);

                        // Save as PNG – the format is inferred from the .png extension
                        rasterImage.Save(outputPath);
                    }
                    else
                    {
                        Console.Error.WriteLine($"Unsupported image type for file: {inputPath}");
                    }
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
 * 1. When a design studio needs to automatically straighten scanned PSD mockups and export them as web‑ready PNGs for client review.
 * 2. When a batch processing tool must convert a folder of Photoshop files into corrected PNG thumbnails for a digital asset management system.
 * 3. When an e‑commerce platform wants to deskew product images saved as PSDs before publishing them as PNGs on the storefront.
 * 4. When a document archiving service has to clean up rotated PSD scans of old blueprints and store the corrected images in PNG format for quick preview.
 * 5. When a CI/CD pipeline for a graphics application must ensure all PSD assets are levelled and saved as PNGs before they are bundled into the final release.
 */