// HOW-TO: Batch Convert Raster Images to PDF with Original Filenames in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace RasterToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFolder = "input";
                string outputFolder = "output";

                // Ensure output root folder exists
                Directory.CreateDirectory(outputFolder);

                // Get all files in the input folder
                string[] files = Directory.GetFiles(inputFolder);

                foreach (string inputPath in files)
                {
                    // Verify input file exists
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        return;
                    }

                    // Preserve original filename, change extension to .pdf
                    string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                    string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                    // Ensure the directory for the output file exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Load the raster image and save as PDF using default settings
                    using (Image image = Image.Load(inputPath))
                    {
                        image.Save(outputPath, new PdfOptions());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to generate printable PDF versions of a large set of scanned photos or screenshots automatically, preserving each file’s original name.
 * 2. When an application must archive user‑uploaded raster files (JPEG, PNG, BMP) as PDFs for compliance or storage without manually renaming each document.
 * 3. When a reporting tool has to batch‑convert chart images into PDF reports while keeping the source filenames for easy reference.
 * 4. When a migration script moves legacy image assets into a PDF‑based document management system, using default Aspose.Imaging settings for speed.
 * 5. When a background service processes a folder of product images nightly, creating PDF catalogs that match the original image filenames.
 */
