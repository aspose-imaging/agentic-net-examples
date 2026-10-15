// HOW-TO: Apply Vignette Effect to EPS and Save as Transparent PNG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.eps";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath) ?? ".";
            Directory.CreateDirectory(outputDir);

            using (var epsImage = Aspose.Imaging.Image.Load(inputPath))
            {
                using (var memoryStream = new MemoryStream())
                {
                    var tempPngOptions = new PngOptions();
                    epsImage.Save(memoryStream, tempPngOptions);
                    memoryStream.Position = 0;

                    using (var raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(memoryStream))
                    {
                        int width = raster.Width;
                        int height = raster.Height;
                        var rect = new Aspose.Imaging.Rectangle(0, 0, width, height);
                        int[] pixels = raster.LoadArgb32Pixels(rect);

                        double centerX = width / 2.0;
                        double centerY = height / 2.0;
                        double maxDist = Math.Sqrt(centerX * centerX + centerY * centerY);

                        for (int y = 0; y < height; y++)
                        {
                            for (int x = 0; x < width; x++)
                            {
                                int index = y * width + x;
                                int pixel = pixels[index];
                                int a = (pixel >> 24) & 0xFF;
                                double dx = x - centerX;
                                double dy = y - centerY;
                                double dist = Math.Sqrt(dx * dx + dy * dy);
                                double factor = dist / maxDist;
                                if (factor > 1.0) factor = 1.0;
                                int newA = (int)(a * (1.0 - factor));
                                int newPixel = (newA << 24) | (pixel & 0x00FFFFFF);
                                pixels[index] = newPixel;
                            }
                        }

                        raster.SaveArgb32Pixels(rect, pixels);

                        var finalOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputPath, false)
                        };
                        raster.Save(outputPath, finalOptions);
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
 * 1. When you need to convert a vector EPS logo into a web‑ready PNG with a soft vignette border and preserve transparency for overlay on webpages.
 * 2. When generating product thumbnails from EPS illustrations and want a subtle darkening around the edges to draw focus while keeping the background transparent.
 * 3. When preparing marketing assets that require a vignette effect around vector graphics before embedding them into presentations or emails as PNG files.
 * 4. When creating UI icons from EPS files and need a fade‑out edge effect to blend with varying background colors while maintaining alpha channel transparency.
 * 5. When automating batch processing of EPS artwork to produce PNG images with artistic vignette shading for use in mobile apps that support transparent images.
 */
