// HOW-TO: Create Animated APNG from SVG with Custom Size and Background in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Apng;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.apng";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        var outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        try
        {
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageWidth = 200,
                    PageHeight = 200,
                    BackgroundColor = Color.White
                };

                using (var memoryStream = new MemoryStream())
                {
                    using (var pngOptions = new PngOptions())
                    {
                        pngOptions.VectorRasterizationOptions = rasterOptions;
                        svgImage.Save(memoryStream, pngOptions);
                    }

                    memoryStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                    {
                        var source = new FileCreateSource(outputPath, false);
                        using (var apngOptions = new ApngOptions())
                        {
                            apngOptions.Source = source;
                            apngOptions.DefaultFrameTime = 100;
                            apngOptions.ColorType = PngColorType.TruecolorWithAlpha;

                            using (ApngImage apng = (ApngImage)Image.Create(apngOptions, raster.Width, raster.Height))
                            {
                                apng.RemoveAllFrames();
                                for (int i = 0; i < 5; i++)
                                {
                                    apng.AddFrame(raster);
                                }
                                apng.Save();
                            }
                        }
                    }
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
 * 1. When you need to generate a lightweight animated PNG from a scalable vector logo for a web UI.
 * 2. When you want to programmatically convert SVG icons into a looping APNG with a specific canvas size and white background for a mobile app.
 * 3. When you have to create an animated image sequence from a single SVG to embed in an email newsletter without using GIF.
 * 4. When you require server‑side rendering of vector graphics into an APNG to ensure consistent dimensions across different browsers.
 * 5. When you need to automate the production of animated PNG assets with defined frame timing for game UI elements.
 */
