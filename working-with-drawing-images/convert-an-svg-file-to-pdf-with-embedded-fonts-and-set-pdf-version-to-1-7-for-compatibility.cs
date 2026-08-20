// HOW-TO: Convert SVG to PDF with Embedded Fonts and PDF/A-1b Compliance in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.svg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    },
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height,
                        TextRenderingHint = TextRenderingHint.SingleBitPerPixel,
                        SmoothingMode = SmoothingMode.None
                    }
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
 * 1. When you need to generate a print‑ready PDF from an SVG logo while preserving the exact typography for branding guidelines.
 * 2. When an application must export scalable vector graphics to PDF/A‑1b for long‑term archival in compliance with ISO standards.
 * 3. When a reporting tool creates invoices as SVG diagrams and must deliver them as PDFs that embed all fonts for consistent viewing on any device.
 * 4. When a web service converts user‑uploaded SVG illustrations to PDFs with a specific PDF version to ensure compatibility with older PDF viewers.
 * 5. When automating batch processing of design assets, converting multiple SVG files to PDFs with embedded fonts to avoid missing text in downstream workflows.
 */
