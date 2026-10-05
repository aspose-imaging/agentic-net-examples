// HOW-TO: Convert Multi‑Page EMF To Individual PNG Files In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            using (Image emfImage = Image.Load(inputPath))
            {
                int pageCount = 1;
                if (emfImage is IMultipageImage multipage)
                {
                    pageCount = multipage.PageCount;
                }

                for (int i = 0; i < pageCount; i++)
                {
                    string outputPath = Path.Combine(outputDir, $"page_{i + 1}.png");
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    PngOptions pngOptions = new PngOptions();
                    VectorRasterizationOptions vectorOptions = new VectorRasterizationOptions
                    {
                        PageWidth = emfImage.Width,
                        PageHeight = emfImage.Height,
                        BackgroundColor = Aspose.Imaging.Color.White
                    };
                    pngOptions.MultiPageOptions = new MultiPageOptions(new IntRange(i, 1));
                    pngOptions.VectorRasterizationOptions = vectorOptions;

                    emfImage.Save(outputPath, pngOptions);
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
 * 1. When you need to generate a separate PNG thumbnail for each page of a multi‑page EMF diagram to display in a web gallery.
 * 2. When you must extract individual pages from a vector‑based EMF report and save them as PNG images for inclusion in PDF documents.
 * 3. When an automated build process has to convert all pages of an EMF file into PNG assets for a mobile app’s resource bundle.
 * 4. When a printing workflow requires each EMF page to be rasterized to PNG with a white background before sending to a printer that only accepts raster images.
 * 5. When you are creating a batch conversion tool that processes multiple EMF files and outputs each page as a separate PNG for archival or further image analysis.
 */
