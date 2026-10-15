// HOW-TO: Generate Multiple BMP Images with Centered Colored Circles in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "OutputImages";
            Directory.CreateDirectory(outputDir);

            List<int> radii = new List<int> { 20, 40, 60, 80 };
            int canvasSize = 200;

            foreach (int radius in radii)
            {
                string fileName = $"circle_{radius}.bmp";
                string outputPath = Path.Combine(outputDir, fileName);
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                Source source = new FileCreateSource(outputPath, false);
                BmpOptions options = new BmpOptions() { Source = source };

                using (RasterImage canvas = (RasterImage)Image.Create(options, canvasSize, canvasSize))
                {
                    Graphics graphics = new Graphics(canvas);
                    graphics.Clear(Color.White);

                    using (SolidBrush circleBrush = new SolidBrush(Color.Red))
                    {
                        int diameter = radius * 2;
                        int x = (canvasSize - diameter) / 2;
                        int y = (canvasSize - diameter) / 2;
                        graphics.FillEllipse(circleBrush, x, y, diameter, diameter);
                    }

                    canvas.Save();
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
 * 1. When you need to create a set of BMP icons that display circles of different sizes for UI testing or design previews.
 * 2. When generating placeholder graphics for a game level editor that requires centered red circles with varying radii.
 * 3. When producing batch image assets for printing calibration where each BMP must contain a precise circle diameter.
 * 4. When automating the creation of sample data for computer‑vision algorithms that detect circular shapes in raster images.
 * 5. When building a reporting tool that outputs BMP charts with circles representing data points of different magnitudes.
 */
