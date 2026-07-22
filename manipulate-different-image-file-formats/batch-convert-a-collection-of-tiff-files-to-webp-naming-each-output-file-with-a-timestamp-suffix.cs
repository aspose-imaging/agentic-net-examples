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
            // Hardcoded input TIFF files
            string[] inputPaths = new string[]
            {
                @"C:\Images\sample1.tif",
                @"C:\Images\sample2.tif",
                @"C:\Images\sample3.tif"
            };

            // Output directory for WebP files
            string outputDirectory = @"C:\Images\WebP";

            foreach (string inputPath in inputPaths)
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
                    string timestamp = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                    string outputPath = Path.Combine(outputDirectory, outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save as WebP
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
 * 1. When a web developer needs to compress a batch of high‑resolution TIFF scans into smaller WebP files for faster page loads while preserving unique timestamps for version control.
 * 2. When an e‑commerce platform automates the conversion of product catalog TIFF images to WebP format and appends a timestamp to avoid cache conflicts during nightly uploads.
 * 3. When a digital archiving system processes scanned documents in TIFF, converts them to WebP for web preview, and uses the timestamp suffix to track when each file was generated.
 * 4. When a photo‑editing application offers a one‑click export feature that transforms multiple TIFF photos into WebP thumbnails, naming each output with a precise timestamp for easy sorting.
 * 5. When a content management workflow batches legacy TIFF assets into WebP for mobile optimization and adds a timestamp to each filename to ensure unique identifiers across deployments.
 */