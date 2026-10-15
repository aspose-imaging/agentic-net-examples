// HOW-TO: Convert Multi-Page SVG to High-Resolution PNG Pages in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputDirectory = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                int pageCount = 1;
                if (image is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDirectory, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions
                        {
                            PageWidth = image.Width,
                            PageHeight = image.Height
                        },
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1)),
                        ResolutionSettings = new ResolutionSetting(300, 300)
                    };

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
 * 1. When you need to generate printable 300 DPI PNG images from each page of a multi‑page SVG diagram for a reporting system.
 * 2. When an e‑learning platform requires separate high‑resolution PNG slides extracted from a vector‑based SVG presentation.
 * 3. When a web service must convert user‑uploaded multi‑page SVG files into individual PNG assets for thumbnail galleries.
 * 4. When a desktop application has to rasterize SVG artwork at 300 DPI for inclusion in PDF documents that only accept bitmap images.
 * 5. When an automated build pipeline needs to split a multi‑page SVG logo file into page‑specific PNG files for branding assets.
 */
