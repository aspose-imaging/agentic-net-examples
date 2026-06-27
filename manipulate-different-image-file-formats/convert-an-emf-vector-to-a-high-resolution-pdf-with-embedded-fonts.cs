using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Emf;

class Program
{
    static void Main()
    {
        try
        {
            // Hard‑coded input and output file paths
            string inputPath = @"C:\Images\input.emf";
            string outputPath = @"C:\Images\output.pdf";

            // Verify that the source EMF file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (creates it if missing)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the EMF vector image
            using (Image image = Image.Load(inputPath))
            {
                // Configure rasterization options for high‑resolution rendering
                var rasterOptions = new EmfRasterizationOptions
                {
                    PageSize = image.Size,   // Preserve original page size
                    BorderX = 0,
                    BorderY = 0
                    // Additional high‑resolution settings can be added here if needed
                };

                // Set up PDF export options, linking the rasterization options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = rasterOptions,
                    UseOriginalImageResolution = true   // Preserve original DPI
                };

                // Save the EMF as a PDF with embedded fonts
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
 * 1. When a Windows desktop application needs to export user‑drawn EMF diagrams to high‑resolution PDF reports with embedded fonts for printing.
 * 2. When a batch‑processing service must convert a library of legacy EMF icons into PDF assets while preserving original DPI and page size.
 * 3. When an automated document generation pipeline has to embed vector graphics from EMF files into PDF invoices to ensure crisp rendering on any device.
 * 4. When a GIS or CAD system exports map or schematic drawings stored as EMF to PDF for regulatory submission, requiring exact dimensions and font embedding.
 * 5. When a cloud‑based API receives EMF files from clients and needs to return PDF files that retain vector quality and embedded fonts for archival purposes.
 */