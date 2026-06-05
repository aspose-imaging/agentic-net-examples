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
            // Define input and output directories (relative paths)
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.*")
                .Where(f => f.EndsWith(".tif", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            foreach (string inputPath in tiffFiles)
            {
                // Validate input file existence
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Prepare output path with .webp extension
                string outputPath = Path.Combine(outputDirectory,
                    Path.GetFileNameWithoutExtension(inputPath) + ".webp");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save as WebP
                using (Image image = Image.Load(inputPath))
                {
                    using (WebPOptions options = new WebPOptions())
                    {
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
 * 1. When a developer needs to batch‑convert a folder of high‑resolution TIFF scans into smaller WebP files for faster web page loading using a foreach loop and Aspose.Imaging.
 * 2. When an automated .NET image‑processing workflow must iterate over all *.tif and *.tiff files in a directory and save them as WebP to reduce storage space.
 * 3. When a photo‑gallery application requires generating WebP thumbnails from existing TIFF assets by loading each image with Image.Load and exporting with WebPOptions.
 * 4. When a migration script has to preserve original file names while converting legacy TIFF documents to the modern WebP format across an entire folder.
 * 5. When a developer wants to integrate Aspose.Imaging into a C# service that validates each TIFF file, creates the output directory, and saves the image as WebP in a batch operation.
 */