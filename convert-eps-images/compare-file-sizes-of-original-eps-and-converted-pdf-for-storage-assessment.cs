// HOW-TO: Compare EPS and PDF File Sizes After Conversion in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.eps";
            string outputPath = "Output/sample.pdf";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                image.Save(outputPath, new PdfOptions());
            }

            long epsSize = new FileInfo(inputPath).Length;
            long pdfSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"EPS size: {epsSize} bytes");
            Console.WriteLine($"PDF size: {pdfSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to evaluate whether converting legacy EPS artwork to PDF reduces storage requirements before archiving.
 * 2. When you want to programmatically verify the size difference between original vector EPS files and their PDF equivalents in a .NET batch process.
 * 3. When you are building a migration tool that assesses disk space savings by comparing EPS and PDF file sizes after conversion.
 * 4. When you must generate a report of EPS versus PDF file sizes to decide which format to store in a cloud repository.
 * 5. When you are testing Aspose.Imaging’s EPS‑to‑PDF conversion performance and need to log the resulting file size for quality control.
 */
