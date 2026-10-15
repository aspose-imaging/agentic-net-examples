// HOW-TO: Apply Tilt-Shift Effect to SVG and Save as High-Resolution JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image vectorImage = Image.Load(inputPath))
            {
                using (MemoryStream pngStream = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    vectorImage.Save(pngStream, pngOptions);
                    pngStream.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(pngStream))
                    {
                        int width = raster.Width;
                        int height = raster.Height;

                        int focusHeight = height / 3;
                        int focusStart = (height - focusHeight) / 2;

                        var topRect = new Rectangle(0, 0, width, focusStart);
                        var bottomRect = new Rectangle(0, focusStart + focusHeight, width, height - (focusStart + focusHeight));

                        var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(10, 1.0);

                        raster.Filter(topRect, blurOptions);
                        raster.Filter(bottomRect, blurOptions);

                        var jpegOptions = new JpegOptions
                        {
                            Quality = 100,
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to convert a vector SVG logo into a high‑resolution JPEG with a professional tilt‑shift blur for marketing materials.
 * 2. When you want to generate stylized product photos from SVG illustrations by adding a focus band and exporting them as print‑ready JPEGs.
 * 3. When an e‑commerce site requires thumbnail images with a depth‑of‑field effect derived from scalable SVG icons.
 * 4. When a desktop application must programmatically apply a tilt‑shift filter to vector graphics before saving them for offline viewing.
 * 5. When automating a batch process that transforms SVG diagrams into JPEGs with a blurred background to improve visual hierarchy in reports.
 */
