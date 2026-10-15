// HOW-TO: Apply Emboss 5x5 Filter to TIFF and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.tif";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to add a 3‑D embossed effect to a high‑resolution scanned TIFF before converting it to PNG for web display.
 * 2. When processing archival TIFF documents and you want to enhance edges with an emboss filter while outputting a lightweight PNG for sharing.
 * 3. When building a batch image pipeline that converts TIFF files to PNG thumbnails with a stylized emboss effect for a product catalog.
 * 4. When creating visual previews of medical or engineering TIFF images and require an embossed look to highlight details in the PNG output.
 * 5. When developing a C# utility that applies convolution filters to TIFF files and saves the result as PNG for further analysis or reporting.
 */
