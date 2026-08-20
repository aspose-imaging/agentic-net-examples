// HOW-TO: Batch Convert TIFF Images to WebP with Timestamped Filenames in C# (Aspose.Imaging for .NET)
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

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output file name: original name + timestamp + .webp
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";

                // Combine with output directory
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure the output directory exists
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
 * 1. When you need to archive a large set of high‑resolution TIFF scans as smaller WebP files while preserving the original names and adding a processing timestamp.
 * 2. When an automated workflow must convert daily‑generated TIFF reports into web‑friendly WebP images for faster loading on a website.
 * 3. When a migration script has to rename exported images with a unique timestamp to avoid filename collisions in a shared folder.
 * 4. When a C# application processes scanned documents in bulk and stores them in a compressed format for long‑term storage or backup.
 * 5. When you want to integrate Aspose.Imaging into a scheduled job that transforms and timestamps image files before uploading them to a cloud storage service.
 */
