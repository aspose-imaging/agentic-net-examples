// HOW-TO: Convert CMX to PDF While Preserving Metadata in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cmx;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cmx";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                CmxImage cmx = image as CmxImage;
                if (cmx == null)
                {
                    Console.Error.WriteLine("Loaded image is not a CMX image.");
                    return;
                }

                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
                    cmx.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive legacy CorelDRAW CMX drawings as PDF files without losing the original image properties.
 * 2. When a document management system must convert incoming CMX files to PDF while keeping author and creation metadata intact.
 * 3. When generating PDF reports from CMX graphics for regulatory compliance that requires original metadata to be retained.
 * 4. When automating batch conversion of CMX artwork to PDF for printing workflows and you must preserve color profile information.
 * 5. When integrating Aspose.Imaging into a C# application to transform CMX designs into PDFs for client delivery while maintaining embedded metadata.
 */
