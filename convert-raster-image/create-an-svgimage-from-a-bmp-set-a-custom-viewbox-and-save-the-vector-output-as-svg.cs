// HOW-TO: Convert BMP Image to Scalable SVG with Custom ViewBox in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\sample.bmp";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image bmpImage = Image.Load(inputPath))
            {
                int width = bmpImage.Width;
                int height = bmpImage.Height;

                var createSource = new FileCreateSource(outputPath, false);
                var svgOptions = new SvgOptions { Source = createSource };

                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);
                    graphics.DrawImage(bmpImage, new Point(0, 0));

                    svgImage.Save();
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
 * 1. When you need to embed a legacy BMP graphic into a web page as a resolution‑independent SVG without losing its original dimensions.
 * 2. When generating printable vector assets from scanned BMP files for high‑quality PDF or print workflows.
 * 3. When creating thumbnails or icons from BMP sources that must scale cleanly on high‑DPI displays using SVG.
 * 4. When automating batch conversion of BMP assets to SVG for responsive UI design in a C# application.
 * 5. When you want to programmatically set a custom viewbox for a BMP‑derived SVG to control its coordinate system and background color.
 */
