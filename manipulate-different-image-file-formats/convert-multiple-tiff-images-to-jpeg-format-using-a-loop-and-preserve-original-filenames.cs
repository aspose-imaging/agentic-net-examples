// HOW-TO: Batch Convert TIFF Files to JPEG While Preserving Filenames in C# (Aspose.Imaging for .NET)
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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");
            // Also include .tiff extension if needed
            string[] tiffFilesAlt = Directory.GetFiles(inputDir, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesAlt.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with same filename but .jpg extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".jpg");

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as JPEG using default options
                    image.Save(outputPath, new JpegOptions());
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
 * 1. When you need to prepare a large collection of scanned TIFF documents for web publishing by converting them to smaller JPEG files without changing the original file names.
 * 2. When an automated workflow must transform incoming TIFF images from a scanner into JPEGs for storage in a content‑management system while keeping the naming convention consistent.
 * 3. When a desktop application has to batch‑process user‑uploaded TIFF photos and save them as JPEGs for faster preview generation.
 * 4. When a migration script moves legacy TIFF assets to a new platform that only accepts JPEG images, requiring each file to retain its original identifier.
 * 5. When a scheduled service converts nightly TIFF backups into JPEG format for quick visual inspection by non‑technical staff.
 */
