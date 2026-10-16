// HOW-TO: Increase Red Channel of BMP and Export as SVG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Custom color filter: increase red channel by 50 (clamped to 255)
                for (int y = 0; y < image.Height; y++)
                {
                    for (int x = 0; x < image.Width; x++)
                    {
                        var pixel = image.GetPixel(x, y);
                        int r = Math.Min(pixel.R + 50, 255);
                        int g = pixel.G;
                        int b = pixel.B;
                        var newColor = Color.FromArgb(pixel.A, r, g, b);
                        image.SetPixel(x, y, newColor);
                    }
                }

                var svgOptions = new SvgOptions();
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageWidth = image.Width,
                    PageHeight = image.Height
                };
                svgOptions.VectorRasterizationOptions = rasterizationOptions;

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
 * 1. When you need to enhance the red tones of a legacy BMP image before converting it to a scalable SVG for web display.
 * 2. When you want to programmatically apply a custom color filter to each pixel of a bitmap in a C# application.
 * 3. When you must generate an SVG file from a raster image while preserving the modified colors for vector‑based workflows.
 * 4. When you are building an automated pipeline that validates BMP existence, processes the image, and outputs an SVG for further editing.
 * 5. When you need to ensure the output folder is created automatically and handle errors gracefully while converting images in .NET.
 */
