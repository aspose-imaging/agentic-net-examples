// HOW-TO: Convert DjVu Pages To 32‑Bit BMP Images In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.djvu";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                for (int i = 0; i < djvu.Pages.Length; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.bmp");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    BmpOptions bmpOptions = new BmpOptions();
                    bmpOptions.BitsPerPixel = 32;
                    bmpOptions.MultiPageOptions = new DjvuMultiPageOptions(i);

                    djvu.Save(outputPath, bmpOptions);
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
 * 1. When you need to extract each page of a multi‑page DjVu document as a high‑color‑depth BMP for printing or archival.
 * 2. When a Windows desktop application requires 32‑bit BMP files from scanned DjVu files to preserve transparency or alpha channel data.
 * 3. When batch‑processing a library of DjVu ebooks to generate BMP thumbnails for a document management system.
 * 4. When converting DjVu technical drawings to BMP so they can be edited in legacy graphics tools that only support BMP.
 * 5. When preparing DjVu pages for a machine‑vision pipeline that expects 32‑bit BMP input for accurate pixel analysis.
 */
