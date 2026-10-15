// HOW-TO: Convert OTG to PDF with Custom Author and Title Metadata in C# (Aspose.Imaging for .NET)
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
            string inputPath = Path.Combine("Input", "sample.otg");
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
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo
                    {
                        Author = "Author Name",
                        Title = "Title Name"
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
 * 1. When you need to generate a searchable PDF from an OTG design file while embedding the creator’s name and document title for compliance reporting.
 * 2. When an automated workflow must batch‑convert OTG graphics to PDFs and add consistent author and title information for archival in a document management system.
 * 3. When a web service receives OTG uploads and must return PDFs that include metadata so downstream applications can display proper attribution.
 * 4. When integrating Aspose.Imaging in a C# desktop application to export OTG drawings to PDF with embedded author and title fields for printing catalogs.
 * 5. When creating PDF reports from OTG images in a CI/CD pipeline and you want to programmatically set PDFDocumentInfo to satisfy metadata standards.
 */
