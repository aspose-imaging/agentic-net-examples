using System;
using System.IO;
using Aspose.Imaging;
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
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output file path with .tiff extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save as TIFF
                using (Image image = Image.Load(inputPath))
                {
                    var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, tiffOptions);
                }

                // Preserve original timestamps
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
 * 1. When a developer needs to migrate a collection of WebP product photos to high‑resolution TIFF files for archival storage while keeping the original filenames and file timestamps intact.
 * 2. When an imaging pipeline must convert user‑uploaded WebP screenshots into TIFF format for compatibility with legacy printing software that only accepts TIFF, preserving metadata such as creation and modification dates.
 * 3. When a digital asset management system requires batch processing of WebP assets into TIFF to support lossless editing in Photoshop, and the process must retain the original file timestamps for audit trails.
 * 4. When a medical imaging application has to transform WebP scans into TIFF for integration with DICOM viewers, ensuring that each file’s name and timestamps remain unchanged for regulatory compliance.
 * 5. When a cloud‑based backup service needs to synchronize a folder of WebP images to a TIFF‑only repository, using C# to automate the conversion while preserving the original file timestamps for version control.
 */