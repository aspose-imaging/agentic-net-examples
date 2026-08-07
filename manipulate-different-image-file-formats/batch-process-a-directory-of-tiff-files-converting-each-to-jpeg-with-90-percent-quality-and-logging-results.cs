using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output directories
        string inputDirectory = @"C:\InputTiffs";
        string outputDirectory = @"C:\OutputJpegs";

        try
        {
            // Ensure the output directory exists (creates parent directories if needed)
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            // Also include *.tiff files
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesAlt.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesAlt.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Determine output JPEG path
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".jpg";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists (creates parent directories if needed)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Set JPEG options with 90% quality
                    var jpegOptions = new JpegOptions
                    {
                        Quality = 90
                    };

                    // Save as JPEG
                    image.Save(outputPath, jpegOptions);
                }

                // Log successful conversion
                Console.WriteLine($"Converted \"{inputPath}\" to \"{outputPath}\"");
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer must batch‑convert a folder of scanned TIFF documents to web‑ready JPEGs with 90 % quality for faster page loads using C# and Aspose.Imaging.
 * 2. When a developer needs to automate the migration of legacy TIFF assets in a digital archive to JPEG format while preserving image fidelity and logging each conversion result.
 * 3. When a developer wants to prepare high‑resolution TIFF photographs for an e‑commerce catalog by converting them to JPEGs with controlled compression in a single C# routine.
 * 4. When a developer is building a document management system that ingests multi‑page TIFF files and stores each page as a JPEG thumbnail for quick preview, using Aspose.Imaging’s ImageOptions.
 * 5. When a developer requires a simple C# script to process all *.tif and *.tiff files in a directory, convert them to JPEG with 90 % quality, and record success or failure for each file in a log.
 */