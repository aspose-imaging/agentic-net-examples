// HOW-TO: Save Specific PDF Pages As Separate TIFF Files In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.pdf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image pdfImage = Image.Load(inputPath))
            {
                for (int page = 1; page <= 3; page++)
                {
                    string outputPath = Path.Combine("Output", $"page_{page}.tiff");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                    {
                        tiffOptions.MultiPageOptions = new MultiPageOptions(new IntRange(page, page));
                        pdfImage.Save(outputPath, tiffOptions);
                    }
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
 * 1. When you need to extract individual pages from a multi‑page PDF and store each page as a high‑resolution TIFF for archival or printing.
 * 2. When a document workflow requires converting selected PDF pages to TIFF to comply with legacy systems that only accept TIFF images.
 * 3. When generating separate TIFF files for pages 1‑3 of a contract so they can be sent to different departments for review.
 * 4. When creating page‑by‑page TIFF assets for a scanning pipeline that processes each page independently.
 * 5. When automating the preparation of TIFF images for OCR engines that work best with single‑page TIFF inputs.
 */
