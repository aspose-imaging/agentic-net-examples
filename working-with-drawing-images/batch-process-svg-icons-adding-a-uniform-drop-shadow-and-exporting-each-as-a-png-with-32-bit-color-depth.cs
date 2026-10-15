// HOW-TO: Add Drop Shadow to Multiple SVG Icons and Export as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(inputPath))
                {
                    SvgImage svgImage = (SvgImage)img;
                    int svgWidth = svgImage.Width;
                    int svgHeight = svgImage.Height;
                    int offsetX = 5;
                    int offsetY = 5;
                    int canvasWidth = svgWidth + offsetX;
                    int canvasHeight = svgHeight + offsetY;

                    PngOptions pngOptions = new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (Aspose.Imaging.Image pngImg = Aspose.Imaging.Image.Create(pngOptions, canvasWidth, canvasHeight))
                    {
                        PngImage png = (PngImage)pngImg;
                        Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(png);
                        graphics.Clear(Aspose.Imaging.Color.Transparent);

                        using (SolidBrush shadowBrush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, 0, 0, 0)))
                        {
                            graphics.FillRectangle(shadowBrush, new Aspose.Imaging.Rectangle(offsetX, offsetY, svgWidth, svgHeight));
                        }

                        graphics.DrawImage(svgImage, new Aspose.Imaging.Point(0, 0));
                        png.Save();
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
 * 1. When you need to automatically apply a consistent drop shadow to a library of SVG icons before publishing them as high‑quality 32‑bit PNGs for a web UI.
 * 2. When a design pipeline requires converting vector assets into raster PNG files with a uniform shadow effect to ensure visual depth across all button graphics.
 * 3. When you want to streamline the preparation of SVG logos for mobile apps by adding a shadow and exporting them as PNGs with full color depth in a single batch operation.
 * 4. When an automated build process must generate PNG thumbnails from SVG diagrams, adding a subtle shadow to improve readability on dark backgrounds.
 * 5. When a content management system needs to preprocess uploaded SVG illustrations by applying a drop shadow and saving them as 32‑bit PNGs for consistent display across browsers.
 */
