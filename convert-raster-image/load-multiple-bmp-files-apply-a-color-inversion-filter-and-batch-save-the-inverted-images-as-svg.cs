// HOW-TO: Batch Invert BMP Images and Save as SVG Using C# (Aspose.Imaging for .NET)
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

            string[] files = Directory.GetFiles(inputDirectory, "*.bmp");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                string fileName = Path.GetFileNameWithoutExtension(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName + ".svg");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;
                    int width = raster.Width;
                    int height = raster.Height;
                    var rect = new Rectangle(0, 0, width, height);
                    int[] pixels = raster.LoadArgb32Pixels(rect);
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
                    raster.SaveArgb32Pixels(rect, pixels);
                    SvgOptions svgOptions = new SvgOptions();
                    image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate negative‑style graphics from a collection of BMP files for web or print, you can batch invert the colors and export them as scalable SVG vectors.
 * 2. When a legacy application stores icons as BMP and you must provide them in a resolution‑independent format, this code converts and inverts them to SVG in one step.
 * 3. When preparing assets for a dark‑mode UI, you can automatically flip the colors of multiple BMP assets and output them as SVG for crisp rendering on any screen size.
 * 4. When automating a graphics pipeline that requires color‑inverted SVGs for laser‑engraving or CNC machining, this routine processes all BMP inputs without manual editing.
 * 5. When migrating a photo archive to a vector‑friendly format while applying a visual effect, the code batch processes BMP files, inverts their palette, and saves the results as SVG files using Aspose.Imaging for .NET.
 */
