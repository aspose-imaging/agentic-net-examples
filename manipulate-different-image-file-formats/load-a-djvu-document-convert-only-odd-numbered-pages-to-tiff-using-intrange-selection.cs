// HOW-TO: Convert Odd Pages Of DjVu To Multi‑Page TIFF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output_odd_pages.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrWhiteSpace(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                // Determine the last page index
                int lastIndex = djvu.Pages.Length - 1;

                // Select odd-numbered pages (1-based): indices 0,2,4,...
                IntRange oddPagesRange = new IntRange(0, lastIndex, 2);

                DjvuMultiPageOptions multiPageOptions = new DjvuMultiPageOptions(oddPagesRange);

                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.MultiPageOptions = multiPageOptions;

                djvu.Save(outputPath, tiffOptions);
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
 * 1. When you need to extract only the odd‑numbered pages from a scanned DjVu document and archive them as a single multi‑page TIFF file for compatibility with legacy systems.
 * 2. When a publishing workflow requires converting selected pages of a DjVu e‑book into TIFF format for high‑resolution printing while ignoring even pages to reduce file size.
 * 3. When an OCR pipeline processes only the odd pages of a DjVu file and you must provide those pages as a TIFF image stack for the OCR engine.
 * 4. When a legal document management system stores case files in DjVu but needs to generate TIFF previews of every other page for quick review.
 * 5. When a digital archiving script must batch‑convert DjVu files, preserving only odd pages, into TIFF to meet archival standards that mandate TIFF format.
 */
