using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.otg";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    BackgroundColor = Aspose.Imaging.Color.White,
                    PageWidth = 800f,
                    PageHeight = 600f
                };

                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = vectorOptions
                };

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
 * 1. When a developer needs to convert an OTG (OpenType Glyph) file into a PDF document with a specific page width and height for inclusion in a printable report using Aspose.Imaging for .NET.
 * 2. When an application must generate PDF brochures from vector‑based OTG graphics while ensuring the output matches a custom page size required by a marketing layout.
 * 3. When a document management system processes uploaded OTG files and needs to store them as PDFs with predefined dimensions for consistent viewing across devices.
 * 4. When a C# service automates the creation of PDF invoices that embed OTG icons and must fit them into a 800 × 600‑pixel page to match the company's template.
 * 5. When a desktop utility converts OTG artwork to PDF for archival purposes, applying a white background and a custom page size to meet archival standards.
 */