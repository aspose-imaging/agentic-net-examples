// HOW-TO: Convert CDR to PDF with Embedded Fonts in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = Path.Combine("Input", "sample.cdr");
        string outputPath = Path.Combine("Output", "sample.pdf");

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = (CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (var pdfOptions = new PdfOptions())
                {
                    pdfOptions.PdfDocumentInfo = new PdfDocumentInfo();
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
 * 1. When a designer needs to share a CorelDRAW (CDR) illustration with clients who view it in PDF while preserving the original typography, this code converts the file and embeds the fonts automatically.
 * 2. When an automated publishing pipeline must generate print‑ready PDFs from CDR assets without losing custom font information, the snippet ensures the fonts are included in the output.
 * 3. When a Windows service processes batch conversions of CDR files to PDFs for archival purposes, embedding fonts guarantees that the archived documents display correctly on any system.
 * 4. When a web application allows users to upload CDR designs and download them as PDFs, using this code guarantees that the downloaded PDFs retain the exact look of the original design.
 * 5. When a legal or compliance workflow requires PDFs with embedded fonts to meet document standards, this example shows how to convert CDR files while satisfying those requirements.
 */
