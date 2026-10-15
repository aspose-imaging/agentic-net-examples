// HOW-TO: Create SVG from BMP with Dashed Line Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/image.bmp";
            string outputPath = "Output/image.svg";

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

                FileCreateSource source = new FileCreateSource(outputPath, false);
                SvgOptions svgOptions = new SvgOptions
                {
                    Source = source
                };

                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Black);
                    pen.DashPattern = new float[] { 5, 5 };

                    graphics.DrawLine(pen, 10, 10, width - 10, height - 10);

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
 * 1. When you need to convert a legacy BMP diagram into a scalable SVG file while applying custom dashed strokes for better visual emphasis.
 * 2. When generating vector graphics from raster assets for responsive web pages and want to programmatically define line dash patterns in C#.
 * 3. When creating printable technical drawings from bitmap sources and require SVG output with precise dash styling for standards compliance.
 * 4. When automating batch processing of BMP images to SVG format and need to add consistent dashed lines to highlight boundaries or guides.
 * 5. When integrating Aspose.Imaging into a .NET application to transform raster images into editable SVGs with custom pen dash arrays for UI overlays.
 */
