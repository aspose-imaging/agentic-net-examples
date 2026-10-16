// HOW-TO: Convert Selected DjVu Pages to PDF with Low Memory in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input DjVu files (hardcoded)
            string[] inputPaths = {
                "Input/file1.djvu",
                "Input/file2.djvu"
            };

            // Page range to export (inclusive start, inclusive end)
            int startPage = 0; // first page index
            int endPage = 2;   // last page index

            foreach (string inputPath in inputPaths)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                // Prepare low‑memory load options
                LoadOptions loadOptions = new LoadOptions
                {
                    BufferSizeHint = 1024 * 1024 // 1 MB buffer
                };

                using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath, loadOptions))
                {
                    // Construct output PDF path
                    string outputFileName = Path.GetFileNameWithoutExtension(inputPath) + "_pages.pdf";
                    string outputPath = Path.Combine("Output", outputFileName);

                    // Ensure output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Set PDF options with DjVu page range
                    PdfOptions pdfOptions = new PdfOptions();
                    pdfOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(startPage, endPage));

                    // Save selected pages to PDF
                    djvu.Save(outputPath, pdfOptions);
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
 * 1. When you need to batch‑process large DjVu documents on a server without exhausting RAM, you can load each file with a small buffer and export only the required pages to PDF.
 * 2. When generating PDF previews of specific chapters from multi‑page DjVu manuals, you can select a page range and save those pages as a separate PDF file.
 * 3. When integrating DjVu‑to‑PDF conversion into an automated workflow that handles many files, the low‑memory strategy keeps the .NET application responsive.
 * 4. When creating archival PDFs from selected pages of scanned DjVu books while preserving disk space, you can extract and convert only those pages.
 * 5. When building a .NET utility that converts user‑chosen DjVu pages to PDF on a low‑resource device, the example shows how to handle file checks, directory creation, and page‑range options.
 */
