// HOW-TO: Convert CorelDRAW CDR to PDF and Get Page Count in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.cdr");
            string outputPath = Path.Combine("Output", "output.pdf");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (CdrImage cdr = (CdrImage)Image.Load(inputPath))
            {
                int pageCount = cdr.PageCount;
                Console.WriteLine($"Page count: {pageCount}");

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
 * 1. When you need to programmatically convert a CorelDRAW CDR design to a PDF for sharing or printing while also knowing how many pages the document contains.
 * 2. When an automated workflow must verify the number of pages in a CDR file before processing or archiving it.
 * 3. When a server‑side application generates PDF reports from user‑uploaded CDR files and logs the page count for audit purposes.
 * 4. When you want to batch‑convert multiple CDR files to PDFs and record each file’s page count for inventory tracking.
 * 5. When integrating CorelDRAW assets into a .NET application that requires PDF output and needs to display the document’s page count to end users.
 */
