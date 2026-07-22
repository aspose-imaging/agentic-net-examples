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
            string inputDirectory = @"C:\Images\Input";
            string outputDirectory = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path preserving original filename with .webp extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".webp");

                // Ensure output directory exists
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
 * 1. When a developer needs to migrate a legacy archive of high‑resolution TIFF scans to modern, lossless WebP files for faster web delivery while keeping the original filenames.
 * 2. When an e‑commerce platform wants to convert product catalog TIFF images to WebP in bulk to reduce page load times without sacrificing image quality.
 * 3. When a medical imaging system requires batch transformation of diagnostic TIFF files to lossless WebP for storage optimization while preserving file naming conventions.
 * 4. When a digital asset management tool must automate the conversion of scanned documents from TIFF to WebP using C# to integrate with downstream web services.
 * 5. When a photographer’s workflow script needs to process a folder of TIFF photos, saving each as a lossless WebP image with the same base name for archival and web publishing.
 */