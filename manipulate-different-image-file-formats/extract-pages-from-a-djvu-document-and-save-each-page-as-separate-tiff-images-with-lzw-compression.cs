// HOW-TO: Extract DjVu Pages to Separate LZW Compressed TIFF Files in C# (Aspose.Imaging for .NET)
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
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.tif");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.TiffLzwRgb);
                    djvu.Pages[i].Save(outputPath, tiffOptions);
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
 * 1. When you need to convert each page of a multi‑page DjVu document into individual LZW‑compressed TIFF files for lossless archival or printing.
 * 2. When a document‑management system must split scanned DjVu books into separate TIFF images to feed an OCR engine that only accepts TIFF input.
 * 3. When a web service processes user‑uploaded DjVu files and stores each page as a compressed TIFF to reduce storage while preserving image quality.
 * 4. When you are preparing DjVu technical manuals for inclusion in a legacy workflow that requires TIFF images with LZW compression for compatibility with older software.
 * 5. When a batch job extracts pages from DjVu lecture notes and saves them as TIFF files to be imported into a slide‑show or e‑learning platform that only supports TIFF format.
 */
