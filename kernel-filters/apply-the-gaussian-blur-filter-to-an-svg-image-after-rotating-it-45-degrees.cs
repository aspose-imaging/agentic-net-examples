// HOW-TO: Rotate SVG 45 Degrees and Apply Gaussian Blur to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    }
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        raster.Rotate(45f, true, Color.White);
                        raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions());

                        raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to generate a rotated and softened thumbnail of an SVG logo for a web page, you can use this code to rasterize, rotate 45°, apply Gaussian blur, and save as PNG.
 * 2. When creating print‑ready assets that require a slight tilt and smooth blur effect on vector illustrations, this approach converts the SVG to a raster image, rotates it, blurs it, and outputs a high‑quality PNG.
 * 3. When building a C# service that automatically processes user‑uploaded SVG icons by adding a decorative blur and a fixed 45° rotation before storing them as PNG files.
 * 4. When preparing graphics for a mobile app where vector icons must be pre‑rotated and softened to match a design theme, the code handles the conversion and filtering in one pipeline.
 * 5. When implementing a batch job that standardizes a collection of SVG diagrams by applying a consistent rotation and Gaussian blur, then exporting them to PNG for downstream analytics or reporting.
 */
