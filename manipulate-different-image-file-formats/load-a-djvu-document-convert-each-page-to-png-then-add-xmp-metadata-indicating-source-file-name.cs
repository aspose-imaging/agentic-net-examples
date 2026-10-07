// HOW-TO: Convert DjVu Pages To PNG Images In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
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
        string inputPath = "input.djvu";
        string outputDir = "Output";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int pageCount = djvu.Pages.Length;
                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (RasterImage page = (RasterImage)djvu.Pages[i])
                    {
                        using (PngOptions pngOptions = new PngOptions())
                        {
                            page.Save(outputPath, pngOptions);
                        }
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
 * 1. When you need to extract each page of a multi‑page DjVu document as separate PNG files for web preview or further image analysis.
 * 2. When automating a workflow that converts scanned DjVu archives into lossless PNG images to preserve quality before OCR processing.
 * 3. When building a .NET service that receives DjVu files and must generate thumbnail PNGs for each page to display in a document management system.
 * 4. When migrating legacy DjVu manuals to a modern format by programmatically saving every page as PNG for inclusion in e‑learning platforms.
 * 5. When creating a batch script that processes a folder of DjVu files and outputs page‑by‑page PNGs for archival or printing purposes.
 */
