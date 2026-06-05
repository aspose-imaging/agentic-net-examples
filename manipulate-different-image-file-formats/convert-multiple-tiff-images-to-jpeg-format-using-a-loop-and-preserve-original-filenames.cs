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
            string inputDir = @"C:\Images\Tiff";
            string outputDir = @"C:\Images\Jpeg";

            // Get all TIFF files in the input directory
            string[] tiffFiles = Directory.GetFiles(inputDir, "*.tif");

            foreach (string inputPath in tiffFiles)
            {
                // Verify that the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output JPEG path preserving the original filename
                string outputPath = Path.Combine(outputDir, Path.GetFileNameWithoutExtension(inputPath) + ".jpg");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the TIFF image and save it as JPEG
                using (Image image = Image.Load(inputPath))
                {
                    image.Save(outputPath, new JpegOptions());
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
 * 1. When a developer needs to batch‑convert a folder of TIFF scans into JPEGs for faster web delivery while keeping the original file names.
 * 2. When an application must migrate legacy medical imaging files stored as .tif to a more widely supported .jpg format without altering the naming convention.
 * 3. When a photo‑management tool has to generate JPEG thumbnails from a collection of high‑resolution TIFF pictures for display in a gallery view.
 * 4. When an automated ETL pipeline processes incoming TIFF documents and saves them as JPEGs in a separate output directory for downstream analytics.
 * 5. When a C# service needs to ensure that all TIFF assets are converted to JPEG on a scheduled basis, preserving the base filenames for easy reference.
 */