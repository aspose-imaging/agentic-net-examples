using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\input\";
            string outputDir = @"C:\output\";

            // Ensure output directory exists (will also handle subfolders if any)
            Directory.CreateDirectory(outputDir);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path preserving original filename with .webp extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as lossless WebP
                    var webpOptions = new WebPOptions
                    {
                        Lossless = true
                    };
                    image.Save(outputPath, webpOptions);
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
 * 1. When a developer needs to migrate a legacy archive of high‑resolution TIFF scans to smaller, lossless WebP files for faster web delivery while keeping the original filenames.
 * 2. When an e‑commerce platform wants to batch convert product catalog TIFF images to WebP to reduce page load times without sacrificing image quality.
 * 3. When a medical imaging system requires converting TIFF‑based radiology images to lossless WebP for secure storage and easy integration with web‑based viewers.
 * 4. When a digital asset management tool must automate the preparation of TIFF artwork files for social‑media publishing by generating WebP versions that retain the original naming scheme.
 * 5. When a GIS application needs to transform a folder of satellite TIFF tiles into lossless WebP tiles to improve map rendering performance in a C#‑based web map service.
 */