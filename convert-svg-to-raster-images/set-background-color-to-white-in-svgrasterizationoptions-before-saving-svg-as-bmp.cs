// HOW-TO: How To Set White Background When Converting SVG To BMP In C# (Aspose.Imaging for .NET)
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

            var rasterOptions = new SvgRasterizationOptions();
            rasterOptions.BackgroundColor = Color.White;

            var bmpOptions = new BmpOptions();
            bmpOptions.VectorRasterizationOptions = rasterOptions;

            using (var image = Image.Load(inputPath))
            {
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
 * 1. When you need to generate bitmap thumbnails of SVG icons and require a consistent white canvas behind transparent graphics.
 * 2. When exporting SVG diagrams to BMP for legacy Windows applications that do not support alpha channels.
 * 3. When preparing SVG artwork for printing on white paper and must ensure the background is not transparent in the BMP output.
 * 4. When converting user‑uploaded SVG files to BMP for storage in a database that only accepts non‑transparent raster images.
 * 5. When automating a batch process that rasterizes SVG logos to BMP format for inclusion in a PDF report that expects a solid white background.
 */
