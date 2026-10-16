// HOW-TO: Convert DjVu Pages 2 To 5 To Multipage TIFF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputPath = "output.tif";

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
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(2, 5));
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
 * 1. When you need to extract a specific range of pages from a DjVu document and archive them as a single multipage TIFF for printing or archival purposes.
 * 2. When a document management system requires DjVu scans to be converted to TIFF while preserving only selected pages for faster loading.
 * 3. When you are building a batch conversion tool that processes large DjVu files and outputs only the relevant pages as a TIFF for compatibility with legacy software.
 * 4. When you need to generate a TIFF preview of certain DjVu pages to embed in a PDF or email without converting the entire file.
 * 5. When an OCR pipeline expects TIFF input, and you must supply only pages 2 through 5 from a DjVu source to improve processing speed.
 */
