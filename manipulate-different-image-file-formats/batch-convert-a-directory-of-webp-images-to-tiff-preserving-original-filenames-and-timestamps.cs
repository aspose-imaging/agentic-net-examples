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
            string inputDir = @"C:\Images\Input";
            string outputDir = @"C:\Images\Output";

            // Get all WebP files in the input directory
            string[] webpFiles = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in webpFiles)
            {
                // Verify input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build output path with same filename but .tif extension
                string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".tif";
                string outputPath = Path.Combine(outputDir, outputFileName);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load WebP image and save as TIFF
                using (WebPImage webPImage = new WebPImage(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    webPImage.Save(outputPath, tiffOptions);
                }

                // Preserve timestamps from the original file
                DateTime creationTime = File.GetCreationTime(inputPath);
                DateTime lastWriteTime = File.GetLastWriteTime(inputPath);
                DateTime lastAccessTime = File.GetLastAccessTime(inputPath);

                File.SetCreationTime(outputPath, creationTime);
                File.SetLastWriteTime(outputPath, lastWriteTime);
                File.SetLastAccessTime(outputPath, lastAccessTime);
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
 * 1. When a developer needs to migrate a legacy web gallery that stores images as WebP into a TIFF‑based archival system while keeping original filenames and file timestamps intact.
 * 2. When an automated build pipeline must batch‑convert user‑uploaded WebP screenshots to lossless TIFF files for downstream PDF generation or printing workflows.
 * 3. When a medical imaging application requires converting a folder of WebP scans to TIFF to comply with DICOM‑compatible tools, preserving creation and modification dates for audit trails.
 * 4. When a cloud‑based image processing service needs to normalize incoming WebP assets to TIFF before applying further analysis, ensuring the output files retain the source timestamps for synchronization.
 * 5. When a Windows desktop utility is built to cleanly archive project assets by converting all WebP assets in a directory to TIFF while maintaining the original file names and file system timestamps for version control.
 */