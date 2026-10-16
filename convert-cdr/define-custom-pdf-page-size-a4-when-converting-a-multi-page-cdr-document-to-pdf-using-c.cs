// HOW-TO: Set A4 PDF Page Size When Converting Multi-Page CDR to PDF in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\Converted.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                PdfOptions pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = 595,
                        PageHeight = 842
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
 * 1. When you need to generate printable A4 PDFs from CorelDRAW (.cdr) files for document archiving.
 * 2. When a batch conversion tool must preserve the original layout of multi‑page designs while fitting them to standard A4 dimensions.
 * 3. When integrating Aspose.Imaging into a C# application that creates PDF reports from vector graphics and requires a specific page size.
 * 4. When automating the preparation of marketing materials where each CDR page must be exported as an A4 PDF for consistent printing.
 * 5. When a developer wants to ensure the converted PDF uses a white background and exact A4 measurements to meet publishing guidelines.
 */
