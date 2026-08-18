// HOW-TO: Batch Convert TIFF Files to WebP Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
            string inputFolder = @"C:\Images\Tiff";
            string outputFolder = @"C:\Images\WebP";

            // Get all TIFF files in the input folder
            foreach (string inputPath in Directory.GetFiles(inputFolder, "*.tif"))
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path with .webp extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".webp");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as WebP
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new WebPOptions());
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
 * 1. When you need to shrink a large collection of high‑resolution TIFF scans for faster web page loading by converting them to WebP in a single C# batch operation.
 * 2. When an automated build pipeline must generate WebP thumbnails from TIFF assets stored in a folder before publishing them to a content delivery network.
 * 3. When a desktop application processes scanned documents and must archive them in a space‑efficient WebP format without manually handling each file.
 * 4. When a migration script has to replace legacy TIFF images with modern WebP equivalents for a mobile app’s asset bundle using Aspose.Imaging.
 * 5. When a server‑side service needs to read TIFF files from a directory, convert them to WebP, and save them to another folder as part of an image‑optimization workflow.
 */
