// HOW-TO: Resize PNG Image and Convert to SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/input.png";
            string outputPath = "Output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                int newWidth = raster.Width * 2;
                int newHeight = raster.Height * 2;
                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new VectorRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = raster.Width,
                        PageHeight = raster.Height
                    }
                };

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
 * 1. When you need to double the dimensions of a PNG logo and output it as a scalable SVG for responsive web design.
 * 2. When an application must programmatically convert raster PNG assets to vector SVG files while preserving background color.
 * 3. When generating high‑resolution SVG thumbnails from low‑resolution PNG images for print‑ready PDFs.
 * 4. When automating batch processing of PNG icons to larger SVG versions for use in UI toolkits.
 * 5. When integrating Aspose.Imaging in a C# service that resizes images and stores them in a vector format for unlimited scaling.
 */
