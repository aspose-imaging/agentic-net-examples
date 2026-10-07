// HOW-TO: Batch Convert SVG to PNG with Motion Blur in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.9.0 | Verified: 2026-09-25
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add files and rerun.");
                return;
            }

            if (!Directory.Exists(outputDirectory))
            {
                Directory.CreateDirectory(outputDirectory);
            }

            string[] files = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".png");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    SvgImage svgImage = image as SvgImage;
                    if (svgImage == null)
                    {
                        Console.Error.WriteLine($"Failed to load SVG: {inputPath}");
                        return;
                    }

                    using (MemoryStream ms = new MemoryStream())
                    {
                        PngOptions tempPngOptions = new PngOptions();
                        svgImage.Save(ms, tempPngOptions);
                        ms.Position = 0;

                        using (RasterImage raster = (RasterImage)Image.Load(ms))
                        {
                            MotionWienerFilterOptions blurOptions = new MotionWienerFilterOptions(8, 60.0, 0.0);
                            raster.Filter(raster.Bounds, blurOptions);

                            PngOptions outOptions = new PngOptions();
                            outOptions.Source = new FileCreateSource(outputPath, false);
                            raster.Save(outputPath, outOptions);
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
 * 1. When you need to generate blurred PNG thumbnails from a folder of SVG icons for a web gallery.
 * 2. When you want to preprocess vector graphics with a motion‑blur effect before embedding them in a slide presentation.
 * 3. When an automated build pipeline must convert design assets from SVG to PNG while applying a consistent blur for UI mockups.
 * 4. When a reporting tool requires PNG images with a specific blur angle to simulate motion in data visualizations.
 * 5. When you are creating a batch script to prepare SVG logos for print, adding a motion blur of size 8 and angle 60 before rasterizing to PNG.
 */
