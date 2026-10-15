// HOW-TO: Convert DjVu Document To Multi‑Page Deflate TIFF In C# (Aspose.Imaging for .NET)
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

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                var tiffOptions = new TiffOptions(TiffExpectedFormat.TiffDeflateRgb);
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
 * 1. When you need to archive scanned books stored as DjVu files into compact multi‑page TIFF files for long‑term preservation.
 * 2. When a document workflow requires converting DjVu pages to TIFF with Deflate compression to reduce file size before uploading to a content management system.
 * 3. When integrating Aspose.Imaging in a C# application to batch‑process DjVu reports and generate TIFF images that can be opened by standard image viewers.
 * 4. When creating a print‑ready PDF pipeline that first transforms DjVu source files into TIFF using lossless Deflate compression for reliable rasterization.
 * 5. When developing a digital library that stores original DjVu scans but serves users TIFF images, needing an automated C# routine to perform the conversion on demand.
 */
