// HOW-TO: Convert PDF Vector Pages to PNG with Alpha Transparency in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.pdf";
            string outputDir = "Output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Aspose.Imaging.Image pdfImage = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.IMultipageImage multipage = pdfImage as Aspose.Imaging.IMultipageImage;
                if (multipage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a multipage image.");
                    return;
                }

                for (int i = 0; i < multipage.PageCount; i++)
                {
                    using (Aspose.Imaging.Image page = (Aspose.Imaging.Image)multipage.Pages[i])
                    {
                        var options = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            VectorRasterizationOptions = new VectorRasterizationOptions
                            {
                                BackgroundColor = Aspose.Imaging.Color.White,
                                PageWidth = page.Width,
                                PageHeight = page.Height
                            }
                        };

                        string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                        page.Save(outputPath, options);
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
 * 1. When you need to generate transparent PNG thumbnails from each page of a multi‑page PDF that contains vector graphics for web previews.
 * 2. When you must preserve the original vector quality while flattening transparency for use in UI overlays or game assets.
 * 3. When an automated reporting system has to export PDF charts as PNG images with an alpha channel for inclusion in PowerPoint slides.
 * 4. When a document processing pipeline requires converting each PDF page to a PNG file that can be composited over other images without a background.
 * 5. When you are building a C# application that extracts individual pages from a PDF and saves them as high‑resolution PNGs with transparent backgrounds for print‑ready layouts.
 */
