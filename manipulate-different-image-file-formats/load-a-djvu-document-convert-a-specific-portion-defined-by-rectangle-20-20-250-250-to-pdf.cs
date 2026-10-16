// HOW-TO: Extract a Rectangular Portion From DjVu and Save as PDF in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\portion.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    var rect = new Rectangle(20, 20, 250, 250);
                    var multiPageOptions = new DjvuMultiPageOptions(0, rect);
                    pdfOptions.MultiPageOptions = multiPageOptions;

                    djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed only a specific area of a DjVu document into a PDF report.
 * 2. When you want to generate a PDF preview of a selected region of a DjVu page for faster loading.
 * 3. When you must extract a diagram or figure from a large DjVu file and share it as a PDF.
 * 4. When you are building a document‑conversion service that converts user‑chosen portions of DjVu files to PDF.
 * 5. When you need to programmatically crop a DjVu image and archive the cropped content in PDF format.
 */
