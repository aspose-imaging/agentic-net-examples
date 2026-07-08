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
            string inputDirectory = @"C:\InputTiff";
            string outputDirectory = @"C:\OutputWebP";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDirectory, "*.tif");
            string[] tiffFilesAlt = Directory.GetFiles(inputDirectory, "*.tiff");
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

                // Build output file path with original name and timestamp
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
                string outputFileName = $"{fileNameWithoutExt}_{timestamp}.webp";
                string outputPath = Path.Combine(outputDirectory, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as WebP using default options (you can adjust Quality, Lossless, etc. if needed)
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
 * 1. When a developer needs to convert a large collection of scanned TIFF documents into lightweight WebP files for faster web page loading while preserving the original filenames with timestamps for version tracking.
 * 2. When an e‑commerce platform must batch‑process product catalog images stored as TIFF and generate timestamped WebP assets for CDN distribution to reduce bandwidth usage.
 * 3. When a medical imaging system requires automated conversion of TIFF radiology images to WebP format for archiving, adding a timestamp to each filename to comply with audit‑trail regulations.
 * 4. When a content management system needs to migrate legacy TIFF assets to modern WebP format and keep a chronological record by appending the conversion date and time to each file name.
 * 5. When a developer builds a scheduled C# service that scans a directory, transforms all TIFF files to WebP using Aspose.Imaging, and names the outputs with the original name plus a timestamp to avoid filename collisions.
 */