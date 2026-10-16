// HOW-TO: Resize BMP Image to Half Size and Convert to SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.bmp";
            string outputPath = "Output\\image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                int newWidth = raster.Width / 2;
                int newHeight = raster.Height / 2;

                raster.Resize(newWidth, newHeight, ResizeType.NearestNeighbourResample);

                SvgOptions svgOptions = new SvgOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Color.White,
                        PageWidth = newWidth,
                        PageHeight = newHeight
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
 * 1. When you need to generate scalable vector graphics from a large BMP thumbnail for web display.
 * 2. When you want to reduce the file size of a bitmap by halving its dimensions before embedding it in an SVG document.
 * 3. When creating responsive UI icons that must scale without loss, converting resized BMPs to SVG ensures crisp rendering on any screen.
 * 4. When automating a batch process that prepares legacy BMP assets for modern vector‑based reporting tools.
 * 5. When integrating image processing into a C# application that must output SVG files for further editing in design software.
 */
