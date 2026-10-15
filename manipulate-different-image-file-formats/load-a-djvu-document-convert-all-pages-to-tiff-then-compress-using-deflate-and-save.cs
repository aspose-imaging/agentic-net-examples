// HOW-TO: Convert Multi-Page DjVu To Deflate-Compressed TIFF In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputPath = "Output\\result.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb);
                tiffOptions.MultiPageOptions = new DjvuMultiPageOptions();
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
 * 1. When you need to archive scanned documents originally in DjVu format as lossless, multi-page TIFF files with Deflate compression for long-term storage.
 * 2. When a document management system requires all pages of a DjVu file to be delivered as a single TIFF bundle that can be opened by standard image viewers.
 * 3. When you are building a C# batch-processing tool that converts a library of DjVu manuals into compressed TIFFs to reduce file size while preserving image quality.
 * 4. When integrating Aspose.Imaging into a workflow that extracts each page of a DjVu e-book and saves it as a Deflate-compressed TIFF for printing or OCR preprocessing.
 * 5. When migrating legacy DjVu archives to a format supported by Windows printers, converting them to multi-page TIFF with Deflate compression using .NET.
 */
