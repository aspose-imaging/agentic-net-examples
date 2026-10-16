// HOW-TO: Convert EPS to PDF with Landscape Orientation for Wide Images in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.eps";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                float pageWidth = image.Width;
                float pageHeight = image.Height;

                if (pageHeight > pageWidth)
                {
                    // Swap to enforce landscape orientation
                    pageWidth = image.Height;
                    pageHeight = image.Width;
                }

                var pdfOptions = new PdfOptions
                {
                    PageSize = new SizeF(pageWidth, pageHeight)
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
 * 1. When you need to generate printable PDFs from EPS artwork that is wider than tall, ensuring the PDF pages are landscape so the design fits without scaling.
 * 2. When automating a batch process that converts EPS logos or banners to PDF for inclusion in reports, and the source files have varying orientations.
 * 3. When creating PDF previews of large-format EPS diagrams for web viewers, and you want the preview pages to match the diagram's landscape layout.
 * 4. When integrating Aspose.Imaging into a C# application that prepares marketing materials, converting EPS flyers to PDF with correct page orientation for printing.
 * 5. When developing a document pipeline that receives EPS files from designers and must output PDFs that preserve the original aspect ratio without rotating the content.
 */
