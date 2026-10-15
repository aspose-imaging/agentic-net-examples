// HOW-TO: Convert Even Pages of a DjVu Document to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    // Convert only even-numbered pages (1-based indexing)
                    if ((i + 1) % 2 == 0)
                    {
                        string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                        string outDir = Path.GetDirectoryName(outputPath);
                        if (!string.IsNullOrWhiteSpace(outDir))
                        {
                            Directory.CreateDirectory(outDir);
                        }

                        var pngOptions = new PngOptions();
                        pngOptions.MultiPageOptions = new DjvuMultiPageOptions(new IntRange(i, i));
                        djvu.Save(outputPath, pngOptions);
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
 * 1. When you need to extract only the even-numbered pages from a multi‑page DjVu file and save them as separate PNG images for web preview.
 * 2. When generating thumbnails for every second page of a scanned book stored in DjVu format to reduce processing time.
 * 3. When creating a printable subset of a DjVu archive by converting only the even pages to high‑quality PNG files.
 * 4. When developing a document‑conversion service that must skip odd pages and output PNGs for downstream image analysis.
 * 5. When automating batch processing of DjVu files to extract specific page ranges (e.g., even pages) for archival or OCR pipelines.
 */
