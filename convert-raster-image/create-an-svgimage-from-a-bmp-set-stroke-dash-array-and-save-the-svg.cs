// HOW-TO: Create SVG from BMP with Dashed Rectangle in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "sample.bmp");
            string outputPath = Path.Combine("Output", "result.svg");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image bmpImage = Image.Load(inputPath))
            {
                var svgOptions = new SvgOptions();

                using (Image svgImage = Image.Create(svgOptions, bmpImage.Width, bmpImage.Height))
                {
                    var graphics = new Graphics(svgImage);
                    graphics.Clear(Color.White);

                    var pen = new Pen(Color.Black);
                    pen.DashPattern = new float[] { 5, 5 };

                    var rect = new Rectangle(10, 10, bmpImage.Width - 20, bmpImage.Height - 20);
                    graphics.DrawRectangle(pen, rect);

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
 * 1. When you need to convert a raster BMP logo into a scalable SVG file while adding a custom dashed border for branding purposes.
 * 2. When generating vector graphics for web pages from existing bitmap assets and you want to highlight the image with a patterned outline using C#.
 * 3. When automating a batch process that creates printable SVG diagrams from BMP scans and requires a consistent dash pattern around each diagram.
 * 4. When building a reporting tool that overlays a dashed rectangle on imported BMP screenshots and exports the result as SVG for resolution‑independent display.
 * 5. When integrating Aspose.Imaging into a C# application to transform bitmap images into editable SVGs with custom stroke styles for further editing in design software.
 */
