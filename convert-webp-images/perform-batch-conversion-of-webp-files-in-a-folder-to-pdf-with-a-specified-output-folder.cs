// HOW-TO: Batch Convert WebP Images to PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace WebPToPdfBatch
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Hardcoded input and output folders
                string inputFolder = @"C:\WebPInput";
                string outputFolder = @"C:\PdfOutput";

                // Ensure output folder exists
                Directory.CreateDirectory(outputFolder);

                // Get all WebP files in the input folder
                string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp");

                foreach (string inputPath in webpFiles)
                {
                    if (!File.Exists(inputPath))
                    {
                        Console.Error.WriteLine($"File not found: {inputPath}");
                        continue;
                    }

                    // Load the WebP image
                    using (Image image = Image.Load(inputPath))
                    {
                        // Prepare output PDF path
                        string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + ".pdf";
                        string outputPath = Path.Combine(outputFolder, outputFileName);

                        // Ensure the directory for the output file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save as PDF
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
 * 1. When you need to generate PDF reports from a collection of WebP graphics stored in a folder.
 * 2. When an automated build process must archive web‑optimized images as PDFs for compliance documentation.
 * 3. When a web application uploads WebP files and you must convert them to PDF for printing or sharing.
 * 4. When migrating legacy assets, you want to batch‑convert WebP icons into PDF format for inclusion in a catalog.
 * 5. When a desktop utility must process user‑selected WebP files and save the results in a designated PDF output directory.
 */
