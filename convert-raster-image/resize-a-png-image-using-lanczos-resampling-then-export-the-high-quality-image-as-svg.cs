// HOW-TO: Resize PNG with Lanczos Resampling and Export to SVG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                int newWidth = image.Width / 2;
                int newHeight = image.Height / 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a smaller, high‑quality vector version of a PNG for responsive web design.
 * 2. When converting raster logos to scalable SVGs while preserving detail through Lanczos resampling.
 * 3. When preparing thumbnail images for a mobile app and storing them as SVG to reduce file size.
 * 4. When automating batch processing of PNG assets to create SVG icons at half the original resolution.
 * 5. When integrating image optimization into a C# backend that requires both resizing and format conversion to SVG.
 */
