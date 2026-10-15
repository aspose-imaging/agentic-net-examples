// HOW-TO: Convert DjVu Document to PDF with Author Metadata in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.djvu");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    PdfDocumentInfo = new PdfDocumentInfo { Author = "Automated" }
                };
                djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to programmatically archive scanned DjVu files as searchable PDFs and tag them with a consistent author name.
 * 2. When an automated document workflow must convert multi‑page DjVu manuals into PDF format while embedding metadata for downstream indexing.
 * 3. When a batch job processes incoming DjVu submissions and creates PDF versions with the author field set to “Automated” for audit trails.
 * 4. When a C# application integrates Aspose.Imaging to transform legacy DjVu graphics into PDFs and ensure the resulting files carry proper author information.
 * 5. When you want to generate PDFs from DjVu e‑books on the fly, adding author metadata so library systems can display the correct creator.
 */
