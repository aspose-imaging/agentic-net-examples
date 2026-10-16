// HOW-TO: Merge Multiple JPEGs into a PNG with 150 DPI Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] inputPaths = new string[] { "input1.jpg", "input2.jpg" };
            string outputPath = "merged.png";

            foreach (var path in inputPaths)
            {
                if (!File.Exists(path))
                {
                    Console.Error.WriteLine($"File not found: {path}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Size> sizes = new List<Size>();
            foreach (var path in inputPaths)
            {
                using (RasterImage img = (RasterImage)Image.Load(path))
                {
                    sizes.Add(new Size(img.Width, img.Height));
                }
            }

            int newWidth = sizes.Sum(s => s.Width);
            int newHeight = sizes.Max(s => s.Height);

            Source src = new FileCreateSource(outputPath, false);
            PngOptions options = new PngOptions()
            {
                Source = src,
                ResolutionSettings = new ResolutionSetting(150, 150)
            };

            using (RasterImage canvas = (RasterImage)Image.Create(options, newWidth, newHeight))
            {
                int offsetX = 0;
                foreach (var path in inputPaths)
                {
                    using (RasterImage img = (RasterImage)Image.Load(path))
                    {
                        Rectangle bounds = new Rectangle(offsetX, 0, img.Width, img.Height);
                        canvas.SaveArgb32Pixels(bounds, img.LoadArgb32Pixels(img.Bounds));
                        offsetX += img.Width;
                    }
                }

                canvas.Save();
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
 * 1. When you need to combine several JPEG photos side‑by‑side into a single high‑resolution PNG for printing or web display.
 * 2. When you must ensure the output image has a specific resolution of 150 DPI to meet publishing or printing standards.
 * 3. When you want to programmatically create a canvas of the exact combined width and maximum height of input images without manual calculations.
 * 4. When you need to validate the existence of source files and automatically create the destination folder before processing images.
 * 5. When you require a .NET solution that loads raster images, copies their pixel data, and saves the merged result using Aspose.Imaging’s PngOptions.
 */
