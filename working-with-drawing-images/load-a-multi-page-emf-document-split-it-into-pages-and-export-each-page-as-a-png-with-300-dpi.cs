// HOW-TO: Split Multi-Page EMF Into High-Resolution PNG Pages In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (var image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipage)
                {
                    int pageCount = multipage.PageCount;
                    for (int i = 0; i < pageCount; i++)
                    {
                        using (var page = multipage.Pages[i])
                        {
                            var options = new PngOptions
                            {
                                ResolutionSettings = new ResolutionSetting(300, 300)
                            };

                            string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            page.Save(outputPath, options);
                        }
                    }
                }
                else
                {
                    var options = new PngOptions
                    {
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

                    string outputPath = Path.Combine(outputDirectory, "page_1.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    image.Save(outputPath, options);
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
 * 1. When you need to convert each page of a vector‑based EMF report into separate high‑resolution PNG images for web preview.
 * 2. When a printing workflow requires extracting individual pages from a multi‑page EMF file and saving them as 300 DPI PNGs for accurate print scaling.
 * 3. When generating thumbnails for each page of a multi‑page EMF diagram to display in a document management system.
 * 4. When migrating legacy EMF assets to raster PNG format while preserving page separation and DPI for archival purposes.
 * 5. When automating batch processing of EMF files to create page‑by‑page PNG assets for use in mobile applications.
 */
