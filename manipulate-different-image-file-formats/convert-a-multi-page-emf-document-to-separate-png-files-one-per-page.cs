// HOW-TO: Convert Multi‑Page EMF to Separate PNG Files in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\multi_page.emf";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image image = Image.Load(inputPath))
            {
                EmfImage emf = image as EmfImage;
                if (emf == null)
                {
                    Console.Error.WriteLine("Failed to load EMF image.");
                    return;
                }

                int pageCount = 1;
                if (image is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine("Output", $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions options = new PngOptions
                    {
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = emf.Width,
                            PageHeight = emf.Height
                        },
                        MultiPageOptions = new MultiPageOptions(new IntRange(i, 1))
                    };

                    emf.Save(outputPath, options);
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
 * 1. When you need to extract each page of a vector‑based EMF report as individual PNG images for web display.
 * 2. When converting multi‑page CAD drawings saved as EMF into raster PNG thumbnails for a document management system.
 * 3. When generating printable PNG assets from each page of an EMF brochure to embed in a PDF generation workflow.
 * 4. When creating separate PNG icons from a multi‑page EMF UI asset for use in different screen resolutions.
 * 5. When processing batch EMF files to produce per‑page PNGs for automated image analysis or machine‑learning pipelines.
 */
