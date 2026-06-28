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

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

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

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Build output file name with timestamp suffix
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as WebP using default options
                    WebPOptions webpOptions = new WebPOptions();
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
 * 1. When a developer needs to migrate a legacy archive of TIFF scans to the modern WebP format for faster web delivery while preserving unique timestamps for version tracking.
 * 2. When an automated nightly job must convert newly added TIFF documents in a folder to WebP images and store them with timestamped filenames to avoid overwriting previous exports.
 * 3. When a digital asset management system requires batch processing of high‑resolution TIFF photos into WebP thumbnails, appending a timestamp to each file to maintain audit trails.
 * 4. When a Windows service processes scanned invoices saved as TIFF files and saves them as WebP files with a timestamp suffix for compliance and easy retrieval.
 * 5. When a C# application needs to generate web‑ready WebP versions of a batch of medical imaging TIFF files, ensuring each output file has a unique timestamp to prevent naming collisions.
 */