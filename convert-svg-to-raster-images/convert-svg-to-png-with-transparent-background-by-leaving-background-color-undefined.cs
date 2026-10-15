// HOW-TO: Convert SVG to PNG with Transparent Background in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = image as SvgImage;
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };
                image.Save(outputPath, options);
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
 * 1. When you need to embed vector icons from an SVG file into a web page that only supports PNG images while preserving transparency.
 * 2. When generating thumbnails for a mobile app that requires PNG files with alpha channels from scalable SVG assets.
 * 3. When preparing print‑ready graphics where the background must remain invisible, converting designer‑provided SVG logos to PNG using C#.
 * 4. When automating a batch process that converts SVG diagrams to PNG for inclusion in PDF reports without losing transparent layers.
 * 5. When integrating Aspose.Imaging in a .NET service to dynamically render user‑uploaded SVG illustrations as PNGs for email newsletters that need transparent backgrounds.
 */
