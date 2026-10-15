// HOW-TO: Resize Image to Thumbnail and Embed in PDF with Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.jpg";
            string outputPath = "Output\\thumbnail.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage original = (RasterImage)Image.Load(inputPath))
            {
                if (!original.IsCached)
                    original.CacheData();

                int thumbWidth = 150;
                int thumbHeight = 150;
                original.Resize(thumbWidth, thumbHeight, ResizeType.NearestNeighbourResample);

                var pdfOptions = new PdfOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image pdfImage = Image.Create(pdfOptions, thumbWidth, thumbHeight))
                {
                    Graphics graphics = new Graphics(pdfImage);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(original, new Point(0, 0));

                    pdfImage.Save();
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
 * 1. When you need to generate a small preview of a large photo and include it in a PDF report.
 * 2. When an application must create thumbnail PDFs for image catalogs or galleries.
 * 3. When you want to automate the conversion of JPEG files into PDF documents that contain only a reduced-size preview.
 * 4. When a document-generation workflow requires embedding a raster image as a fixed-size thumbnail on a PDF page.
 * 5. When you need to programmatically produce PDF files with consistent thumbnail dimensions for email attachments or web downloads.
 */
