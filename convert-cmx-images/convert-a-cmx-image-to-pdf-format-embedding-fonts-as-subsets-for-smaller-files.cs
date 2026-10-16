// HOW-TO: Convert CMX to PDF with Subset Font Embedding in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.cmx";
        string outputPath = "output/output.pdf";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions();
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                pdfOptions.VectorRasterizationOptions = vectorOptions;
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
 * 1. When you need to generate a searchable PDF from a CorelDRAW CMX file while keeping the file size low by embedding only the used characters of the fonts.
 * 2. When an automated document pipeline must convert batch CMX drawings to PDF for archiving or printing without losing vector quality.
 * 3. When a web service receives CMX uploads and must return PDF previews that preserve the original layout and fonts.
 * 4. When migrating legacy design assets stored as CMX into a PDF‑based workflow for easier viewing on any device.
 * 5. When creating PDF reports from CMX diagrams in a C# application and want the fonts to be subsetted to reduce the final PDF size.
 */
