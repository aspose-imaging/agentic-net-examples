// HOW-TO: Batch Convert TIFF Images to Lossless WebP in C# (Aspose.Imaging for .NET)
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

                // Build output path preserving original filename but with .webp extension
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
 * 1. When you need to shrink a large collection of high‑resolution TIFF scans for faster web delivery while keeping them lossless, this code converts each file to WebP and keeps the original names.
 * 2. When a legacy system exports medical or archival images as TIFF and your web portal requires modern WebP assets, the script automates the batch transformation in C#.
 * 3. When you are building an image‑processing pipeline that must preserve filename consistency across formats, this example shows how to rename TIFFs to .webp without losing the base name.
 * 4. When you want to generate lightweight, lossless thumbnails for a digital asset management system from existing TIFF files, the code batch processes the folder and stores the results in an output directory.
 * 5. When you need to integrate Aspose.Imaging into a scheduled Windows service that periodically converts newly added TIFF files to WebP for storage cost reduction, this sample provides the core conversion loop.
 */
