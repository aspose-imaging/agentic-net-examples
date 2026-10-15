// HOW-TO: Convert CorelDRAW CDR to PDF with Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.cdr";
            string outputPath = "Output\\result.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                CdrImage cdr = (CdrImage)image;
                using (PdfOptions pdfOptions = new PdfOptions())
                {
                    cdr.Save(outputPath, pdfOptions);
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
 * 1. When you need to generate a printable PDF from a CorelDRAW CDR file using Aspose.Imaging in an automated C# workflow.
 * 2. When a web service must accept CDR uploads and return PDF previews for user download with Aspose.Imaging.
 * 3. When batch processing a directory of CDR drawings to create PDF archives for document management in .NET.
 * 4. When integrating CorelDRAW artwork into a reporting system that only supports PDF output via C# code.
 * 5. When converting legacy CDR artwork to PDF to ensure compatibility with modern PDF viewers and printers.
 */
