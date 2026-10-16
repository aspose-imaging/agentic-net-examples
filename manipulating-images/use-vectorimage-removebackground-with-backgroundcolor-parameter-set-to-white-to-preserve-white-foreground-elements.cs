// HOW-TO: Remove SVG Background and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output\\result.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (var image = Image.Load(inputPath))
            {
                var vectorImage = image as VectorImage;
                if (vectorImage != null)
                {
                    var settings = new RemoveBackgroundSettings();
                    vectorImage.RemoveBackground(settings);
                }

                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

                image.Save(outputPath, pngOptions);
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
 * 1. When converting SVG icons to PNG for web UI while discarding the original background.
 * 2. When preparing vector graphics for mobile apps that require transparent PNG assets.
 * 3. When automating batch processing of SVG files to generate PNGs with alpha for PDF reports.
 * 4. When extracting foreground elements from SVG logos to overlay on colored backgrounds in a C# application.
 * 5. When integrating Aspose.Imaging into a build pipeline to create PNG thumbnails without background clutter.
 */
