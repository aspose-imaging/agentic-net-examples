// HOW-TO: Convert SVG To 8-Bit BMP With Indexed Palette In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input\\image.svg";
        string outputPath = "Output\\image.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var svgImage = (Aspose.Imaging.FileFormats.Svg.SvgImage)image;

                BmpOptions bmpOptions = new BmpOptions
                {
                    BitsPerPixel = 8,
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        BackgroundColor = Aspose.Imaging.Color.White,
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height
                    }
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
 * 1. When you need to embed vector graphics in legacy Windows applications that only support 8-bit BMP files.
 * 2. When you must generate low-size bitmap thumbnails from SVG icons for email attachments or mobile bandwidth constraints.
 * 3. When you are preparing assets for a game engine that requires indexed-color BMP textures.
 * 4. When you need to convert SVG logos to BMP format while preserving a specific color palette for printing workflows.
 * 5. When you automate batch processing of SVG diagrams into BMP files for reporting tools that only accept raster images.
 */
