// HOW-TO: Convert Multi‑Page EMF to Separate PNG Files in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Emf;
using Aspose.Imaging.FileFormats.Tiff.Enums;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "Input\\multi.emf";
                string outputDirectory = "Output";

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

                        using (PngOptions options = new PngOptions())
                        {
                            options.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                            image.Save(outputPath, options);
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
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract each page of a multi‑page EMF diagram into individual PNG images for web display.
 * 2. When generating thumbnails for each page of a vector‑based report saved as EMF to embed in a document management system.
 * 3. When converting a multi‑page EMF logo file into PNG assets for use in mobile applications that only support raster formats.
 * 4. When automating the batch processing of EMF drawings to create separate PNG files for printing each page on different printers.
 * 5. When preparing separate PNG layers from a multi‑page EMF for further image analysis or OCR processing in a C# workflow.
 */
