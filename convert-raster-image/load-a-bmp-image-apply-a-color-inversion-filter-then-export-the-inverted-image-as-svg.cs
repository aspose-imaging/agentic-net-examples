// HOW-TO: Invert BMP Colors and Export as SVG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
    static void Main(string[] args)
    {
        string inputPath = "input/input.bmp";
        string outputPath = "output/output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                for (int i = 0; i < pixels.Length; i++)
                {
                    int pixel = pixels[i];
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    r = 255 - r;
                    g = 255 - g;
                    b = 255 - b;
                    pixels[i] = (a << 24) | (r << 16) | (g << 8) | b;
                }
                raster.SaveArgb32Pixels(raster.Bounds, pixels);
                SvgOptions svgOptions = new SvgOptions();
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
 * 1. When you need to generate a negative‑style version of a legacy BMP graphic for web display as scalable SVG.
 * 2. When converting scanned BMP assets into vector‑compatible SVG files while applying a full color inversion for branding purposes.
 * 3. When automating a batch process that reads BMP images, inverts their colors, and saves the result as SVG for responsive UI components.
 * 4. When creating artistic effects by programmatically flipping the RGB values of a BMP and exporting the result to an SVG for further editing.
 * 5. When integrating Aspose.Imaging into a C# application to transform bitmap icons into inverted SVG icons for high‑resolution displays.
 */
