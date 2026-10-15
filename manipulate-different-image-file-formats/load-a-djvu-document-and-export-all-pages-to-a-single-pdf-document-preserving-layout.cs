// HOW-TO: Convert Multi‑Page DjVu Document To Single PDF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.pdf";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvuImage = (DjvuImage)Image.Load(inputPath))
            {
                var pdfOptions = new PdfOptions
                {
                    MultiPageOptions = new DjvuMultiPageOptions()
                };
                djvuImage.Save(outputPath, pdfOptions);
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
 * 1. When you need to archive scanned books stored as DjVu files by converting the entire multi‑page document into a single PDF for easy distribution.
 * 2. When a web application must generate PDF previews of user‑uploaded DjVu files without losing the original page layout.
 * 3. When an automated batch process has to transform a collection of DjVu manuals into PDF format for compliance reporting.
 * 4. When integrating document conversion into a C# desktop tool that consolidates DjVu lecture notes into one PDF for printing.
 * 5. When a cloud service requires converting DjVu invoices into PDF to attach them to email notifications while preserving each page’s formatting.
 */
