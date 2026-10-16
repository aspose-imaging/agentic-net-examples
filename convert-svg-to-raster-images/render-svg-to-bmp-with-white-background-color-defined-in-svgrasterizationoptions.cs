// HOW-TO: Render SVG to BMP with White Background Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;

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
                var rasterizationOptions = new SvgRasterizationOptions();
                rasterizationOptions.BackgroundColor = Color.White;

                var bmpOptions = new BmpOptions();
                bmpOptions.VectorRasterizationOptions = rasterizationOptions;

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
 * 1. When you need to convert vector SVG graphics into raster BMP files for legacy Windows applications while ensuring a solid white background.
 * 2. When generating thumbnail previews of SVG icons for a desktop software that only supports BMP format.
 * 3. When preparing SVG diagrams for printing on devices that require BMP images with a defined background color to avoid transparency issues.
 * 4. When automating batch processing of SVG assets into BMP for a game engine that cannot handle SVG transparency.
 * 5. When creating BMP assets from SVG logos for inclusion in reports where a consistent white background is required.
 */
