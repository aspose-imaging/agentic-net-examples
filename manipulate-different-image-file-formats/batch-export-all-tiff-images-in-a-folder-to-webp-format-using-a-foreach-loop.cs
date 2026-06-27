using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input and output directories (relative paths)
            string inputDir = "Input";
            string outputDir = "Output";

            // Retrieve all TIFF files from the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Construct the output file path with .webp extension
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as WebP
                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
                        // Example options: lossless compression with quality setting
                        options.Lossless = true;
                        options.Quality = 80f;

                        image.Save(outputPath, options);
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
 * 1. When a developer needs to convert a large collection of scanned TIFF documents into smaller, web‑optimized WebP files for faster page loads.
 * 2. When an e‑commerce platform must batch‑process product catalog images stored as TIFF and generate lossless WebP versions for modern browsers.
 * 3. When a digital archiving system requires automated conversion of high‑resolution TIFF scans to WebP to reduce storage costs while preserving image quality.
 * 4. When a photo‑editing application wants to provide a one‑click export feature that transforms all TIFF files in a user‑selected folder into WebP with configurable quality settings.
 * 5. When a content management workflow automates the migration of legacy TIFF assets to WebP for responsive design and mobile‑friendly delivery.
 */