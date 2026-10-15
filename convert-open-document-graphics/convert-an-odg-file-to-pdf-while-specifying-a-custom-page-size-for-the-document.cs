// HOW-TO: Convert ODG to PDF with Custom Page Size in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.odg";
            string outputPath = "Output/sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        PageWidth = 595,   // custom width in points
                        PageHeight = 842,  // custom height in points
                        BackgroundColor = Color.White
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
 * 1. When a developer needs to generate printable PDF reports from OpenDocument graphics (ODG) files with a specific A4 page layout.
 * 2. When integrating a document conversion service that must preserve vector quality while fitting the output to a predefined page dimension.
 * 3. When automating batch processing of ODG diagrams into PDFs for archiving, requiring a uniform page size across all documents.
 * 4. When creating PDFs for mobile or web preview where the page width and height must match a custom design specification.
 * 5. When building a C# application that converts user‑uploaded ODG files to PDFs and needs to set a white background and exact page dimensions for consistent rendering.
 */
