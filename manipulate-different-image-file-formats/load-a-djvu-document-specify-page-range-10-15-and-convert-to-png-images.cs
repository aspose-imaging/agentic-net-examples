// HOW-TO: Convert DjVu Pages 10 To 15 To PNG Images In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.djvu";
            string outputDirectory = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (DjvuImage djvu = (DjvuImage)Image.Load(inputPath))
            {
                int startPage = 10;
                int endPage = 15;

                for (int i = startPage; i <= endPage; i++)
                {
                    if (i < 0 || i >= djvu.Pages.Length)
                    {
                        Console.Error.WriteLine($"Page index out of range: {i}");
                        continue;
                    }

                    string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    using (var options = new PngOptions())
                    {
                        options.MultiPageOptions = new DjvuMultiPageOptions(i);
                        options.Source = new FileCreateSource(outputPath, false);
                        djvu.Save(outputPath, options);
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
 * 1. When you need to extract a subset of pages from a multi‑page DjVu file and save them as separate PNG files for web preview.
 * 2. When you want to generate high‑resolution PNG thumbnails of specific DjVu pages for a document management system.
 * 3. When you are building a batch conversion tool that processes only selected pages of scanned DjVu archives into PNG for archival purposes.
 * 4. When you need to programmatically convert DjVu pages 10‑15 into PNG to feed into an OCR pipeline that only supports PNG input.
 * 5. When you are creating a custom viewer that loads only certain DjVu pages and renders them as PNG images for faster loading on mobile devices.
 */
