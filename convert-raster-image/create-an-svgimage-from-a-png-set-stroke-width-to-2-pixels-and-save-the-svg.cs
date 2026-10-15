// HOW-TO: Create SVG From PNG With 2‑Pixel Stroke Border In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "image.png");
            string outputPath = Path.Combine("Output", "image.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image pngImage = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)pngImage;
                int width = raster.Width;
                int height = raster.Height;

                SvgOptions svgOptions = new SvgOptions();

                using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Create(svgOptions, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(svgImage);
                    graphics.Clear(Aspose.Imaging.Color.White);
                    graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
                    pen.Width = 2;
                    graphics.DrawRectangle(pen, new Aspose.Imaging.Rectangle(0, 0, width, height));

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
 * 1. When you need to convert a raster PNG logo into a scalable SVG file and add a consistent 2‑pixel outline for branding purposes.
 * 2. When generating vector graphics for web pages from existing PNG assets while ensuring a uniform border thickness across different screen resolutions.
 * 3. When creating printable SVG diagrams from PNG screenshots and requiring a precise 2‑pixel stroke to meet design specifications.
 * 4. When automating batch processing of PNG icons to SVG format with a defined border for use in UI libraries that rely on vector shapes.
 * 5. When integrating Aspose.Imaging in a C# application to transform raster images into SVGs and programmatically apply a custom stroke width for consistent styling.
 */
