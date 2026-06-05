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
            string inputDirectory = @"C:\Images\TiffInput";
            string outputDirectory = @"C:\Images\WebpOutput";

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(outputDirectory);

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesUpper = Directory.GetFiles(inputDirectory, "*.tiff");
            string[] allFiles = new string[tiffFiles.Length + tiffFilesUpper.Length];
            tiffFiles.CopyTo(allFiles, 0);
            tiffFilesUpper.CopyTo(allFiles, tiffFiles.Length);

            foreach (string inputPath in allFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Build output file name: original name + timestamp + .webp
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure the output directory exists (unconditional call as required)
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as WebP using default options (you can adjust quality if needed)
                    var webpOptions = new WebPOptions
                    {
                        // Example: set quality to 80 (optional)
                        Quality = 80,
                        Lossless = false
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
 * 1. When a developer needs to convert a large archive of scanned TIFF documents into smaller WebP files for faster web delivery while preserving the original filenames with a timestamp for version tracking.
 * 2. When an e‑commerce platform must generate optimized product images from high‑resolution TIFF assets and store them with unique timestamped names to avoid cache conflicts.
 * 3. When a digital asset management system requires automated nightly processing of newly uploaded TIFF photos into WebP format, appending a timestamp to each filename for audit trails.
 * 4. When a mobile app backend needs to batch‑compress TIFF map tiles into WebP to reduce bandwidth usage, using the original tile name plus a timestamp to synchronize updates.
 * 5. When a publishing workflow automates the migration of legacy TIFF illustrations to WebP for modern browsers, naming each output with the source name and current timestamp to maintain content chronology.
 */