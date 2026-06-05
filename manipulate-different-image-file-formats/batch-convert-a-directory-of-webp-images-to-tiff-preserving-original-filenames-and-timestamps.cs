using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputWebP";
            string outputDir = @"C:\OutputTiff";

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output path with the same filename but .tif extension
                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileName + ".tif");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save as TIFF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    webPImage.Save(outputPath, tiffOptions);
                }

                // Preserve original timestamps
                File.SetCreationTime(outputPath, File.GetCreationTime(inputPath));
                File.SetLastWriteTime(outputPath, File.GetLastWriteTime(inputPath));
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
 * 1. When a developer needs to migrate a collection of WebP assets to lossless TIFF files for archival or printing while keeping original filenames and timestamps intact.
 * 2. When an image‑processing pipeline must convert user‑uploaded WebP photos to TIFF before feeding them into a legacy system that only accepts TIFF, preserving file metadata for audit trails.
 * 3. When a digital asset management tool requires batch conversion of WebP images stored in a folder to TIFF to support software that reads TIFF metadata, ensuring timestamps remain unchanged for version control.
 * 4. When a C# application automates the preparation of WebP screenshots for legal evidence, converting them to TIFF and retaining creation and modification dates to satisfy compliance requirements.
 * 5. When a developer builds a scheduled job that scans a directory, transforms all WebP files into TIFF using Aspose.Imaging, and keeps the original file names and timestamps for seamless integration with downstream workflows.
 */