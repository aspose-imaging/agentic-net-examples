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

                // Build output path preserving original filename
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".webp";
                string outputPath = Path.Combine(outputDir, outputFileName);

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
 * 1. When a developer needs to migrate a legacy archive of high‑resolution TIFF scans to a modern, web‑friendly format without losing image quality, they can use this code to batch convert the files to lossless WebP while keeping the original filenames.
 * 2. When an e‑commerce platform wants to reduce page load times by serving smaller images, a developer can run this script to convert product‑catalog TIFF images to lossless WebP in bulk, preserving the naming scheme for seamless integration.
 * 3. When a medical imaging system stores diagnostic scans as TIFF and must share them with web portals that only accept WebP, a developer can employ this code to automate the conversion while maintaining lossless fidelity and original file identifiers.
 * 4. When a digital asset management (DAM) tool requires periodic optimization of stored TIFF assets for cloud storage cost savings, a developer can schedule this batch conversion to lossless WebP, ensuring filenames stay consistent for indexing.
 * 5. When a GIS application exports map layers as TIFF and needs to deliver them to web‑based viewers that support WebP, a developer can use this script to batch process the layers, keeping the original layer names for easy reference.
 */