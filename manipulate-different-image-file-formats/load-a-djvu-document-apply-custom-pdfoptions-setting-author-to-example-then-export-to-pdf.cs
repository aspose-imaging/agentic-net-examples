// HOW-TO: Convert DjVu to PDF with Custom Author Metadata in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.djvu";
            string outputPath = "Output/output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            using (Image image = Image.Load(inputPath))
            {
                // Ensure the loaded image is a DjvuImage (optional cast)
                DjvuImage djvu = image as DjvuImage;
                if (djvu == null)
                {
                    Console.Error.WriteLine("The loaded file is not a DjVu image.");
                    return;
                }

                PdfOptions pdfOptions = new PdfOptions();
                pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                pdfOptions.PdfDocumentInfo.Author = "Example";

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
 * 1. When you need to archive scanned DjVu documents as searchable PDFs while embedding the author's name for proper attribution.
 * 2. When a publishing workflow requires converting multi-page DjVu files to PDF and setting PDF metadata programmatically in a C# application.
 * 3. When building a document management system that must preserve source author information during DjVu‑to‑PDF conversion using Aspose.Imaging.
 * 4. When automating batch processing of DjVu manuals into PDF format and you want to add a consistent author tag to each output file.
 * 5. When integrating file format conversion into a .NET service and you must ensure the resulting PDF contains custom metadata like the author field.
 */
