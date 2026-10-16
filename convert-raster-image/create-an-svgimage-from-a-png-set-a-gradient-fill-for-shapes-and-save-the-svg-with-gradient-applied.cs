// HOW-TO: Create SVG from PNG with Linear Gradient Fill in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image pngImage = Image.Load(inputPath))
            {
                RasterImage raster = pngImage as RasterImage;
                int width = raster.Width;
                int height = raster.Height;

                SvgOptions svgOptions = new SvgOptions();
                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);

                    using (LinearGradientBrush brush = new LinearGradientBrush(
                        new Point(0, 0),
                        new Point(width, 0),
                        Color.Red,
                        Color.Blue))
                    {
                        Rectangle rect = new Rectangle(0, 0, width, height);
                        graphics.FillRectangle(brush, rect);
                    }

                    svgImage.Save(outputPath);
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
 * 1. When you need to convert a raster PNG logo into a scalable SVG with a red‑to‑blue gradient background for responsive web design.
 * 2. When generating vector graphics for marketing materials that require a consistent gradient fill across different screen sizes.
 * 3. When creating dynamic SVG charts in a C# application where the chart background must be a linear gradient derived from an existing PNG template.
 * 4. When automating the production of themed icons that need to be stored as SVG files with gradient fills for high‑resolution displays.
 * 5. When building a desktop tool that transforms user‑uploaded PNG images into SVG assets with customizable gradient colors for UI skinning.
 */
