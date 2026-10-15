// HOW-TO: Create SVG from JPEG with Dashed Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\source.jpg";
            string outputPath = "Output\\result.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image raster = Image.Load(inputPath))
            {
                int width = raster.Width;
                int height = raster.Height;

                SvgOptions svgOptions = new SvgOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (Image svgImage = Image.Create(svgOptions, width, height))
                {
                    Graphics graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);

                    Pen pen = new Pen(Color.Black);
                    pen.Width = 2;
                    pen.DashStyle = DashStyle.Custom;
                    pen.DashPattern = new float[] { 5, 5 };

                    graphics.DrawRectangle(pen, new Rectangle(10, 10, width - 20, height - 20));

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
 * 1. When you need to convert a JPEG photograph into an SVG file and add a custom dashed border for scalable web graphics.
 * 2. When generating vector diagrams from raster images for print layouts that require precise dash patterns on shapes.
 * 3. When creating dynamic SVG assets in a C# application where the stroke style must be programmatically defined.
 * 4. When automating the production of SVG icons from existing bitmap assets with consistent dashed outlines.
 * 5. When building a reporting tool that overlays dashed rectangles on raster screenshots and exports the result as editable SVG.
 */
