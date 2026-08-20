// HOW-TO: Batch Convert WebP Images to PDF in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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
            string inputFolder = @"C:\InputWebP";
            string outputFolder = @"C:\OutputPDF";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Get all WebP files in the input folder
            string[] webpFiles = Directory.GetFiles(inputFolder, "*.webp", SearchOption.TopDirectoryOnly);

            foreach (string inputPath in webpFiles)
            {
                // Verify the input file exists
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                // Build the output PDF path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputFolder, fileNameWithoutExt + ".pdf");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the WebP image
                using (Image image = Image.Load(inputPath))
                {
                    // Save as PDF using default options
                    PdfOptions pdfOptions = new PdfOptions();
                    image.Save(outputPath, pdfOptions);
                }

                Console.WriteLine($"Converted: {inputPath} -> {outputPath}");
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
 * 1. When you need to generate printable PDF reports from a collection of WebP graphics stored in a server folder.
 * 2. When an e‑commerce platform must convert product photos saved as WebP into PDF catalogs for offline distribution.
 * 3. When a document management system requires batch transformation of WebP assets into PDF for archival compliance.
 * 4. When a mobile app backend processes user‑uploaded WebP images and needs to bundle them as PDFs for email attachment.
 * 5. When a batch script automates the migration of WebP marketing banners to PDF format for printing press workflows.
 */
