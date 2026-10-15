// HOW-TO: Create SVG From JPEG With Custom Viewbox Size In C# (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\sample.jpg";
        string outputPath = "Output\\result.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image rasterImage = Image.Load(inputPath))
            {
                int width = 800;
                int height = 600;

                using (SvgOptions svgOptions = new SvgOptions())
                {
                    svgOptions.Source = new FileCreateSource(outputPath, false);

                    using (SvgImage svgImage = (SvgImage)Image.Create(svgOptions, width, height))
                    {
                        Graphics graphics = new Graphics(svgImage);
                        graphics.DrawImage(rasterImage, new Point(0, 0));
                        svgImage.Save();
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
 * 1. When you need to embed a high‑resolution photograph into a scalable vector graphic for responsive web design, you can convert the JPEG to SVG with a defined viewbox using Aspose.Imaging in C#.
 * 2. When generating printable marketing materials that require vector‑based layouts but start from raster logos, this code creates an SVG with precise dimensions to maintain quality.
 * 3. When building a desktop application that converts user‑uploaded images into SVG icons with a fixed canvas size, the snippet shows how to draw the raster onto an SVG and save it.
 * 4. When automating batch processing of product images to produce lightweight SVG thumbnails with custom width and height, the example demonstrates the necessary steps in .NET.
 * 5. When integrating image conversion into a reporting system that outputs SVG charts containing background pictures, the code provides a way to place the raster image inside a vector container with a specific viewbox.
 */
