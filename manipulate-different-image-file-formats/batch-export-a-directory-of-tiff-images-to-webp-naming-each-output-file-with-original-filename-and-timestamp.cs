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
            string inputDirectory = @"C:\Images\Tiff";
            string outputDirectory = @"C:\Images\WebP";

            // Ensure the output directory exists (creates if missing)
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file name: original name + timestamp + .webp
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists (unconditional as per rule)
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save as WebP
                using (Image image = Image.Load(inputPath))
                {
                    // Use default WebP options; customize if needed
                    var webpOptions = new WebPOptions();
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
 * 1. When a developer needs to convert a large collection of legacy TIFF scans into modern WebP files for faster web delivery while preserving the original filenames with a timestamp for version tracking.
 * 2. When an automated image pipeline must process daily satellite TIFF imagery and store compressed WebP copies with unique timestamps to avoid overwriting previous exports.
 * 3. When a content management system requires batch migration of high‑resolution TIFF assets to WebP format for mobile optimization, and the filenames must include a timestamp to maintain audit trails.
 * 4. When a Windows service is tasked with nightly archiving of scanned documents, converting them from TIFF to WebP and appending the current date‑time to each file name for easy retrieval.
 * 5. When a developer builds a desktop utility that scans a folder of TIFF photos, exports them as WebP using Aspose.Imaging, and names each output with the original name plus a timestamp to ensure uniqueness across multiple runs.
 */