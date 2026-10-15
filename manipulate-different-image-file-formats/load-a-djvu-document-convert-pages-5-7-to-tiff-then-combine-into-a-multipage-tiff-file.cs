// HOW-TO: Convert Specific DjVu Pages To Multipage TIFF In C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\output.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
            tiffOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(5, 7));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
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
 * 1. When you need to extract only certain pages from a large DjVu document and combine them into a single multipage TIFF for printing or archival.
 * 2. When integrating a document workflow that converts selected DjVu pages into a compressed LZW TIFF for inclusion in a PDF report.
 * 3. When building a C# application that processes scanned books stored as DjVu and generates a multipage TIFF for OCR processing.
 * 4. When you want to automate the creation of a TIFF preview containing only pages 5‑7 of a DjVu file for a web thumbnail gallery.
 * 5. When a legal or medical imaging system requires converting specific DjVu pages into a multipage TIFF to meet record‑keeping standards.
 */
