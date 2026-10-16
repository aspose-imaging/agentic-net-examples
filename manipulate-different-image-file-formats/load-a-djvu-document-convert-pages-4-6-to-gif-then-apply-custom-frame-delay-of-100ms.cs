// HOW-TO: Convert DjVu Pages 4 To 6 Into Multi‑Page GIF Using C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\document.djvu";
            string outputPath = "Output\\pages4to6.gif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                GifOptions gifOptions = new GifOptions
                {
                    MultiPageOptions = new MultiPageOptions(new IntRange(4, 6))
                };

                djvu.Save(outputPath, gifOptions);
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
 * 1. When you need to extract a subset of pages from a DjVu document and share them as a single animated GIF for web preview.
 * 2. When you want to generate a lightweight GIF slideshow of selected DjVu pages for inclusion in an email newsletter.
 * 3. When you are building a document‑conversion service that must convert specific DjVu pages to GIF to meet client‑specified page ranges.
 * 4. When you need to create an animated preview of particular DjVu pages for a mobile app without loading the entire file.
 * 5. When you are automating batch processing to convert multiple DjVu files’ middle pages into GIFs for archival or indexing purposes.
 */
