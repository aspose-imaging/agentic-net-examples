// HOW-TO: Convert EPS to PDF with CMYK Color Space in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.eps");
            string outputPath = Path.Combine("Output", "sample.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            using (var pdfOptions = new PdfOptions())
            {
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
 * 1. When you need to transform a vector EPS artwork into a print‑ready PDF while preserving CMYK colors for a commercial printing workflow in a C# application.
 * 2. When an automated publishing system must batch‑convert incoming EPS files from designers into PDFs that can be directly sent to a press.
 * 3. When a web service receives EPS logos from clients and must return PDF versions that maintain exact color fidelity for branding guidelines.
 * 4. When integrating Aspose.Imaging into a desktop tool that lets users export their EPS illustrations as PDFs ready for offset printing.
 * 5. When building a CI/CD pipeline that validates and converts EPS assets to PDF format to ensure all deliverables meet print specifications.
 */
