// HOW-TO: Resize PNG to Max Width 1200 and Convert to PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
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
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                int originalWidth = image.Width;
                int originalHeight = image.Height;

                if (originalWidth > 1200)
                {
                    int newWidth = 1200;
                    int newHeight = (int)Math.Round((double)originalHeight * newWidth / originalWidth);
                    image.Resize(newWidth, newHeight, Aspose.Imaging.ResizeType.LanczosResample);
                }

                PdfOptions pdfOptions = new PdfOptions();
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
 * 1. When you need to generate a PDF brochure from high‑resolution PNG graphics while ensuring the file fits within a 1200‑pixel width for faster loading.
 * 2. When an e‑commerce site must downsize product PNG images before embedding them in PDF invoices to keep email attachments small.
 * 3. When a reporting tool converts user‑uploaded PNG charts into PDFs, preserving the original aspect ratio and limiting width to 1200 pixels.
 * 4. When a document‑automation workflow requires converting PNG logos to PDF format with consistent dimensions for print‑ready files.
 * 5. When a mobile app backend processes PNG screenshots, resizes them to a maximum width and stores them as PDFs for archival purposes.
 */
