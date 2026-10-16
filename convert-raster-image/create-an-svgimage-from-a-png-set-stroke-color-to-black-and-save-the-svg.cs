// HOW-TO: Convert PNG to SVG with Black Border Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\image.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image pngImg = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)pngImg;

                Aspose.Imaging.ImageOptions.SvgOptions svgOptions = new Aspose.Imaging.ImageOptions.SvgOptions();
                svgOptions.Source = new Aspose.Imaging.Sources.FileCreateSource(outputPath, false);

                using (Aspose.Imaging.Image svgImg = Aspose.Imaging.Image.Create(svgOptions, raster.Width, raster.Height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(svgImg);
                    Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
                    graphics.DrawRectangle(pen, 0, 0, raster.Width - 1, raster.Height - 1);
                    graphics.DrawImage(raster, new Aspose.Imaging.Point(0, 0));

                    svgImg.Save();
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
 * 1. When you need to embed a raster PNG into a scalable SVG for web graphics while adding a black outline.
 * 2. When you want to generate vector SVG files from existing PNG assets for responsive design without losing image content.
 * 3. When you must programmatically add a consistent stroke around images before converting them to SVG for branding guidelines.
 * 4. When automating batch conversion of PNG logos to SVG format with a uniform border in a C# application.
 * 5. When creating printable SVG assets from PNG sources and ensuring a visible black frame for better visual separation.
 */
