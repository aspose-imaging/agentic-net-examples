// HOW-TO: Generate Multiple BMP Images with Centered Red Ellipse in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "OutputImages";
            Directory.CreateDirectory(outputDir);

            var sizes = new List<(int width, int height)>
            {
                (200, 200),
                (300, 150),
                (400, 300)
            };

            foreach (var (width, height) in sizes)
            {
                string outputPath = Path.Combine(outputDir, $"ellipse_{width}x{height}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                var bmpOptions = new BmpOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                using (var image = Image.Create(bmpOptions, width, height))
                {
                    var graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    using (var brush = new SolidBrush(Color.Red))
                    {
                        graphics.FillEllipse(brush, new RectangleF(0, 0, width, height));
                    }

                    image.Save();
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
 * 1. When you need to automatically generate placeholder BMP files of various dimensions for UI mockups, each showing a centered red ellipse as a visual marker.
 * 2. When a reporting tool requires a set of uniformly formatted BMP charts with a red ellipse overlay to indicate data points across different image resolutions.
 * 3. When preparing test assets for a graphics pipeline, you can batch‑create BMP images of specific sizes with a red ellipse to validate scaling and rendering behavior.
 * 4. When exporting thumbnail previews for a catalog, you can use this code to produce BMP thumbnails of custom dimensions with a red ellipse highlighting the focal area.
 * 5. When automating the creation of watermark‑style graphics for a batch of product images, the script generates BMP files of required sizes with a centered red ellipse as the watermark.
 */
