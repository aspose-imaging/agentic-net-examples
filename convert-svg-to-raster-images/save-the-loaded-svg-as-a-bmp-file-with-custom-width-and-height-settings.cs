// HOW-TO: Convert SVG to BMP with Specific Width and Height in C# (Aspose.Imaging for .NET)
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

            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageWidth = 800,
                PageHeight = 600
            };

            var bmpOptions = new BmpOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            using (Image image = Image.Load(inputPath))
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
 * 1. When you need to generate a bitmap thumbnail of an SVG logo at a fixed 800×600 size for a Windows desktop application.
 * 2. When you must convert scalable vector graphics to BMP format for legacy systems that only accept raster images with specific dimensions.
 * 3. When you are creating printable assets and require the SVG to be rasterized to a BMP with exact width and height to match a layout template.
 * 4. When you need to batch‑process SVG icons and save them as BMP files with uniform size for use in a game engine that does not support SVG.
 * 5. When you want to embed a vector illustration into a document that only supports BMP, ensuring the image is rendered at the desired resolution using Aspose.Imaging in C#.
 */
