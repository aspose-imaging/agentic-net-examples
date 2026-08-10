// HOW-TO: Batch Convert WebP Images to TIFF While Keeping Filenames and Timestamps in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output directories relative to the current directory
            string baseDir = Directory.GetCurrentDirectory();
            string inputDir = Path.Combine(baseDir, "Input");
            string outputDir = Path.Combine(baseDir, "Output");

            // Ensure the input directory exists; create it if missing and exit
            if (!Directory.Exists(inputDir))
            {
                Directory.CreateDirectory(inputDir);
                Console.WriteLine($"Input directory created at: {inputDir}. Add WebP files and rerun.");
                return;
            }

            // Ensure the output directory exists
            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Retrieve all WebP files from the input directory
            string[] files = Directory.GetFiles(inputDir, "*.webp");

            foreach (string inputPath in files)
            {
                // Validate the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Construct the output file path with a .tiff extension
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDir, fileNameWithoutExt + ".tiff");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image and save it as TIFF
                using (Image image = Image.Load(inputPath))
                {
                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                    image.Save(outputPath, tiffOptions);
                }

                // Preserve original timestamps on the new TIFF file
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
 * 1. When you need to migrate a collection of WebP photos to high‑resolution TIFF files for archival while retaining the original file names.
 * 2. When a document‑management system requires TIFF images but the source assets are stored as WebP, and you must process them in bulk using C#.
 * 3. When you are preparing images for print production that only accepts TIFF, and you want to preserve the original creation dates during conversion.
 * 4. When automating a nightly job that converts newly added WebP files in a folder to TIFF for downstream analytics, keeping timestamps for audit trails.
 * 5. When integrating Aspose.Imaging into a .NET application to transform web‑optimized images to lossless TIFF format without losing metadata such as file timestamps.
 */
