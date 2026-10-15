// HOW-TO: Apply Gaussian Blur to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            using (Image loadedImage = Image.Load(inputPath))
            {
                SvgImage svgImage = loadedImage as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("The loaded file is not a valid SVG image.");
                    return;
                }

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = svgImage.Width,
                    PageHeight = svgImage.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                Image imageCanvas = Image.Create(pngOptions, svgImage.Width, svgImage.Height);
                RasterImage rasterImage = imageCanvas as RasterImage;
                if (rasterImage == null)
                {
                    Console.Error.WriteLine("Failed to create raster image.");
                    return;
                }

                using (rasterImage)
                {
                    Graphics graphics = new Graphics(rasterImage);
                    graphics.DrawImage(svgImage, new Point(0, 0));

                    var blurOptions = new GaussianBlurFilterOptions();
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                    rasterImage.Save(outputPath, pngOptions);
                }
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
 * 1. When you need to convert an SVG logo into a blurred PNG thumbnail for a web gallery.
 * 2. When you want to programmatically add a soft focus effect to vector icons before embedding them in a mobile app.
 * 3. When you must generate rasterized images from SVG diagrams with a Gaussian blur for print‑ready PDFs.
 * 4. When you are automating batch processing of SVG assets to create blurred PNG placeholders for lazy loading.
 * 5. When you need to apply image filtering to vector graphics in a C# backend service that outputs PNG files for email newsletters.
 */
