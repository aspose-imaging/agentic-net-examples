// HOW-TO: Resize BMP to 500x500, Apply Median Filter and Save as SVG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                raster.Resize(500, 500);

                var medianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3);
                raster.Filter(raster.Bounds, medianOptions);

                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When converting legacy BMP assets to scalable SVG graphics for responsive web design while ensuring consistent size and noise reduction.
 * 2. When preparing bitmap icons for inclusion in a vector‑based UI library, needing a fixed 500 px dimension and a median filter to smooth pixel artifacts.
 * 3. When automating batch processing of scanned BMP documents, resizing them and applying a median filter before exporting to SVG for lossless scaling.
 * 4. When integrating image preprocessing into a C# application that must output clean, resized vector files for printing or CAD workflows.
 * 5. When optimizing game sprites stored as BMPs by reducing their dimensions, removing speckle noise, and converting them to SVG for resolution‑independent rendering.
 */
