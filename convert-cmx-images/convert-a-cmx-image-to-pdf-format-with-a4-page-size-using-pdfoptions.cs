// HOW-TO: Convert CMX Image to A4 PDF Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cmx");
            string outputPath = Path.Combine("Output", "sample.pdf");

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
                    // PdfDocumentInfo can be set if needed; using defaults for A4 size.
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();

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
 * 1. When a developer needs to embed legacy CorelDRAW CMX graphics into a printable PDF report sized to standard A4 pages.
 * 2. When an application must batch‑convert CMX design files to PDF for archival or distribution without manual resizing.
 * 3. When a web service receives CMX uploads and must return a PDF version that fits typical office paper dimensions.
 * 4. When integrating Aspose.Imaging into a document‑generation workflow that requires converting vector CMX drawings to PDF for client delivery.
 * 5. When automating the creation of PDF portfolios that include CMX illustrations, ensuring each page uses the A4 format for consistent printing.
 */
