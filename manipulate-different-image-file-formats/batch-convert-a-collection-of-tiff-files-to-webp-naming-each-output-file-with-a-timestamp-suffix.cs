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
            // Hardcoded input and output directories
            string inputDir = @"C:\InputTiff";
            string outputDir = @"C:\OutputWebp";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file name with timestamp suffix
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as WebP
                using (Image image = Image.Load(inputPath))
                {
                    // Save using default WebP options
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
 * 1. When a developer needs to migrate a legacy archive of high‑resolution TIFF scans to the lightweight WebP format for faster web delivery while preserving original filenames with a timestamp to avoid overwriting.
 * 2. When an automated nightly job must process newly uploaded TIFF images from a scanner folder and generate timestamped WebP copies for a content‑management system.
 * 3. When building a C# utility that prepares medical imaging files (TIFF) for mobile health apps by converting them to WebP and appending a timestamp to track version history.
 * 4. When creating a batch image‑conversion script for a digital publishing workflow that converts TIFF page assets to WebP and adds a timestamp suffix to ensure unique filenames in the output directory.
 * 5. When implementing a backup routine that compresses TIFF screenshots into WebP files with a timestamped name to keep chronological snapshots without manual renaming.
 */