// HOW-TO: Convert EPS with Embedded Images to High‑Resolution PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = image.Width,
                        PageHeight = image.Height
                    };
                    pdfOptions.PdfCoreOptions = new PdfCoreOptions
                    {
                        PdfCompliance = PdfComplianceVersion.PdfA1b
                    };

                    image.Save(outputPath, pdfOptions);
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
 * 1. When a developer needs to generate print‑ready PDF files from EPS artwork that contains raster images, preserving the original resolution.
 * 2. When creating PDF/A‑1b compliant documents for archival or legal purposes from vector EPS sources.
 * 3. When an automated workflow must batch‑convert EPS files to PDFs with exact page dimensions matching the source image.
 * 4. When a web service needs to render EPS logos or diagrams as high‑quality PDFs for client download.
 * 5. When integrating Aspose.Imaging into a C# application to replace EPS files with PDFs for downstream printing pipelines.
 */
