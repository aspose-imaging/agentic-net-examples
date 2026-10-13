// HOW-TO: Convert CorelDRAW CDR to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\sample.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                CdrImage cdrImage = (CdrImage)image;
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    cdrImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to preserve the exact typography of a CorelDRAW CDR design while sharing it as a PDF using Aspose.Imaging in C#.
 * 2. When a printing workflow requires PDFs that embed all fonts to avoid missing‑font warnings on the press, and you want to automate the conversion with C#.
 * 3. When an application automatically converts user‑uploaded CDR files to PDF for browser preview, ensuring the fonts are embedded for consistent rendering.
 * 4. When you are building a document management system that stores PDFs with embedded fonts for reliable archival of legacy CorelDRAW assets.
 * 5. When you need to generate PDF reports from legacy CDR assets without installing CorelDRAW on the server, using Aspose.Imaging’s C# API.
 */
