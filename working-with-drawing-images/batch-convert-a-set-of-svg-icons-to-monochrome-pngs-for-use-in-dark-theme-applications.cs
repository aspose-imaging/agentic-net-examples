// HOW-TO: Batch Convert SVG Icons to Monochrome PNGs in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string baseDir = Directory.GetCurrentDirectory();
            string inputDirectory = Path.Combine(baseDir, "Input");
            string outputDirectory = Path.Combine(baseDir, "Output");

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
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileNameWithoutExt + ".png");

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image svgImage = Image.Load(inputPath))
                {
                    int width = svgImage.Width;
                    int height = svgImage.Height;

                    PngOptions pngOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false),
                        VectorRasterizationOptions = new VectorRasterizationOptions
                        {
                            BackgroundColor = Color.White,
                            PageWidth = width,
                            PageHeight = height
                        }
                    };

                    svgImage.Save(outputPath, pngOptions);
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image pngImage = Image.Load(outputPath))
                {
                    RasterCachedImage raster = (RasterCachedImage)pngImage;
                    if (!raster.IsCached) raster.CacheData();

                    raster.Grayscale();
                    raster.BinarizeFixed(128);

                    raster.Save(outputPath);
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
 * 1. When you need to generate white‑on‑black icons for a dark‑mode UI by converting a folder of SVG assets to PNG files automatically.
 * 2. When a build pipeline must rasterize vector graphics into fixed‑size PNGs for platforms that only support bitmap images.
 * 3. When you want to create a set of monochrome PNG resources from designer‑provided SVG icons without manually editing each file.
 * 4. When an application requires pre‑processed PNG icons with a white background for consistent rendering across different browsers.
 * 5. When you are preparing assets for a mobile app that uses PNG icons and you need to batch convert them from SVG using Aspose.Imaging in C#.
 */
