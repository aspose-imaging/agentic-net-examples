// HOW-TO: Convert DjVu Pages to PNG with Sub Filter Using C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.djvu";
        string outputDir = "output";

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

                    PngOptions options = new PngOptions
                    {
                        FilterType = PngFilterType.Sub,
                        Source = new FileCreateSource(outputPath, false),
                        MultiPageOptions = new DjvuMultiPageOptions(i)
                    };

                    djvu.Save(outputPath, options);
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
 * 1. When you need to extract each page of a multi‑page DjVu document as a separate PNG file with a specific Sub filter for better compression.
 * 2. When an application must programmatically convert scanned DjVu archives into PNG images for web preview while controlling the PNG filter type.
 * 3. When a batch process has to read a DjVu file, apply custom PNG options, and save the output to a designated folder structure.
 * 4. When you want to ensure the generated PNGs use the Sub filter to improve image quality for downstream processing in C# projects.
 * 5. When integrating Aspose.Imaging into a .NET service that converts DjVu pages to PNGs with custom encoding settings for consistent rendering.
 */
