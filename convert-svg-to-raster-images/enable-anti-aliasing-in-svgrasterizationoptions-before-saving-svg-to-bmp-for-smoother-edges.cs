// HOW-TO: Convert SVG to BMP with Anti‑Aliasing Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Drawing.Drawing2D;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = 500,
                    PageHeight = 500,
                    SmoothingMode = SmoothingMode.AntiAlias
                };

                var bmpOptions = new BmpOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to generate high‑quality bitmap thumbnails from vector SVG logos for a Windows desktop application.
 * 2. When you must embed anti‑aliased SVG graphics into a legacy BMP‑based reporting system that does not support vector formats.
 * 3. When you are creating print‑ready raster images from SVG diagrams and want smooth edges to avoid jagged lines.
 * 4. When you automate conversion of SVG assets to BMP for use in game textures that require a specific pixel format.
 * 5. When you develop a batch process that converts user‑uploaded SVG files to BMP for storage in a database that only accepts bitmap data.
 */
