// HOW-TO: Convert OTG to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.pdf";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the OTG image
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                // Set custom page size (e.g., 800x600 points)
                var otgOptions = new OtgRasterizationOptions
                {
                    PageSize = new Aspose.Imaging.SizeF(800, 600)
                };

                // Configure PDF save options
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = otgOptions
                };

                // Save as PDF
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
 * 1. When you need to embed an OTG vector graphic into a PDF report and specify the exact page dimensions for consistent layout.
 * 2. When generating printable PDFs from OTG files for a marketing brochure that requires a custom 800 × 600‑point page size.
 * 3. When automating batch conversion of OTG assets to PDF for archival purposes while preserving a predefined page size across all documents.
 * 4. When integrating OTG images into a C# application that creates PDF invoices and must match the invoice page size standards.
 * 5. When preparing OTG diagrams for legal documentation where the resulting PDF must conform to a specific page size for compliance.
 */
