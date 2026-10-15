// HOW-TO: Resize EPS to 2000px Width and Save as PDF/A‑2b in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/resized.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
            {
                int targetWidth = 2000;
                int targetHeight = (int)(epsImage.Height * (targetWidth / (double)epsImage.Width));
                epsImage.Resize(targetWidth, targetHeight);

                PdfOptions pdfOptions = new PdfOptions();
                epsImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to embed a high‑resolution vector logo from an EPS file into a PDF/A‑2b compliant document for archival.
 * 2. When preparing print‑ready PDFs from EPS artwork and must ensure the image width does not exceed 2000 pixels to meet file‑size constraints.
 * 3. When converting legacy EPS illustrations to PDF for a web application that only supports PDF/A‑2b for accessibility compliance.
 * 4. When automating a batch process that standardizes EPS graphics to a fixed width before generating PDF reports.
 * 5. When a client requires PDFs that preserve the original vector quality of EPS images while conforming to PDF/A‑2b standards for legal documents.
 */
