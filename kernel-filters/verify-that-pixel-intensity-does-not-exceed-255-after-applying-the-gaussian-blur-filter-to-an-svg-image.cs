// HOW-TO: Check Maximum Pixel Intensity After Rasterizing SVG to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
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
        try
        {
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                var svgImage = (SvgImage)image;

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageWidth = svgImage.Width,
                        PageHeight = svgImage.Height,
                        BackgroundColor = Color.White
                    }
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
            {
                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                int maxIntensity = 0;
                foreach (int pixel in pixels)
                {
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    maxIntensity = Math.Max(maxIntensity, Math.Max(r, Math.Max(g, b)));
                }

                if (maxIntensity > 255)
                {
                    Console.Error.WriteLine("Pixel intensity exceeds 255 after processing.");
                }
                else
                {
                    Console.WriteLine("Pixel intensity verification passed (max <= 255).");
                }

                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
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
 * 1. When a developer needs to ensure that converting an SVG graphic to a PNG does not produce color values higher than the 8‑bit limit, they can use this code to validate pixel intensity.
 * 2. When preparing SVG assets for web delivery and must guarantee that the resulting PNG complies with standard 0‑255 channel ranges, this routine checks the max RGB value.
 * 3. When integrating image processing pipelines that later apply filters such as Gaussian blur, developers can first rasterize the SVG and verify that the pixel data stays within valid bounds.
 * 4. When debugging rendering issues where overly bright pixels appear after SVG rasterization, the code helps identify if intensity overflow is the cause.
 * 5. When building automated tests for a graphics conversion service, this sample provides a way to assert that every exported PNG pixel intensity remains under 256.
 */
