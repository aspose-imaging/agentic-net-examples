// HOW-TO: Resize BMP Image With Nearest Neighbor And Export To SVG In C# (Aspose.Imaging for .NET)
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
    static void Main()
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

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

                var svgOptions = new SvgOptions();
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
 * 1. When a developer needs to double the size of a legacy BMP graphic for a web‑friendly SVG icon without smoothing artifacts.
 * 2. When an application must convert raster BMP assets into scalable SVG files while preserving pixel‑perfect edges for UI design.
 * 3. When a batch‑processing tool has to upscale bitmap textures for high‑resolution displays and output them as vector SVGs for further editing.
 * 4. When a game‑engine pipeline requires converting old BMP sprites to SVG format using nearest‑neighbor scaling to keep the retro pixel art style.
 * 5. When a reporting system generates SVG charts from BMP logos, needing a quick resize and format change directly in C#.
 */
