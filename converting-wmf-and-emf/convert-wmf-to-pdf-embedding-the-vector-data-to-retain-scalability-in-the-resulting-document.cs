// HOW-TO: Convert WMF to PDF with Vector Preservation in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\sample.wmf";
            string outputPath = @"C:\Images\sample.pdf";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load WMF image
            using (Image image = Image.Load(inputPath))
            {
                // Set up vector rasterization options to preserve vector data
                var vectorOptions = new WmfRasterizationOptions
                {
                    PageSize = image.Size
                };

                // Configure PDF options with the vector rasterization settings
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

                // Save as PDF, embedding the vector content
                image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to embed scalable vector graphics from legacy WMF files into PDF reports without rasterizing the artwork.
 * 2. When an application must generate printable PDFs from Windows Metafile diagrams while keeping the original vector quality for zoom‑in clarity.
 * 3. When a document‑management system requires converting user‑uploaded WMF logos to PDF format while preserving edit‑able vector data.
 * 4. When a batch‑processing tool automates migration of old WMF assets to PDF for archiving, ensuring the files remain resolution‑independent.
 * 5. When a C# service creates PDF invoices that include WMF‑based charts and wants the charts to remain crisp at any size.
 */
