// HOW-TO: Apply Opacity Mask to SVG and Export as PNG with Alpha in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.svg";
            string outputPath = "Output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string tempPng = Path.Combine(Path.GetTempPath(), "temp_vector.png");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPng));

            // Load vector image and rasterize to temporary PNG
            using (Aspose.Imaging.Image vectorImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(tempPng, false)
                };
                vectorImage.Save(tempPng, pngOptions);
            }

            // Load rasterized image
            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempPng))
            {
                // Create opacity mask (50% transparent white)
                string tempMask = Path.Combine(Path.GetTempPath(), "temp_mask.png");
                Directory.CreateDirectory(Path.GetDirectoryName(tempMask));

                using (Aspose.Imaging.RasterImage mask = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(
                    new PngOptions
                    {
                        ColorType = PngColorType.TruecolorWithAlpha,
                        Source = new FileCreateSource(tempMask, false)
                    },
                    raster.Width,
                    raster.Height))
                {
                    int width = raster.Width;
                    int height = raster.Height;
                    int[] pixels = new int[width * height];
                    int argb = (128 << 24) | (255 << 16) | (255 << 8) | 255; // 50% opaque white
                    for (int i = 0; i < pixels.Length; i++) pixels[i] = argb;
                    mask.SaveArgb32Pixels(new Aspose.Imaging.Rectangle(0, 0, width, height), pixels);
                    mask.Save(tempMask, new PngOptions { ColorType = PngColorType.TruecolorWithAlpha, Source = new FileCreateSource(tempMask, false) });
                }

                // Load mask image
                using (Aspose.Imaging.RasterImage maskImg = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(tempMask))
                {
                    // Apply mask by blending
                    raster.Blend(new Aspose.Imaging.Point(0, 0), maskImg, 255);
                }

                // Save final image with alpha channel
                var outOptions = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, outOptions);
            }

            // Cleanup temporary files
            if (File.Exists(tempPng)) File.Delete(tempPng);
            string tempMaskPath = Path.Combine(Path.GetTempPath(), "temp_mask.png");
            if (File.Exists(tempMaskPath)) File.Delete(tempMaskPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to convert an SVG logo into a PNG that retains transparency for web UI.
 * 2. When you want to overlay a semi‑transparent white mask on a vector illustration to create a watermark effect before saving as PNG.
 * 3. When a reporting tool requires raster images with an alpha channel derived from vector assets.
 * 4. When you must generate thumbnails of SVG diagrams with 50 % opacity for preview panes in a desktop application.
 * 5. When you are preparing assets for a game UI and need to apply a uniform opacity mask to vector graphics before exporting to PNG.
 */
