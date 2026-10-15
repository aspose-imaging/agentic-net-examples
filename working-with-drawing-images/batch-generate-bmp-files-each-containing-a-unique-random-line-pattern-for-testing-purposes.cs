// HOW-TO: Generate Multiple Random Line BMP Images for Testing in C# (Aspose.Imaging for .NET)
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
            string outputDir = "GeneratedLines";
            Directory.CreateDirectory(outputDir);

            int imageCount = 10;
            int width = 200;
            int height = 200;
            Random rand = new Random();

            for (int i = 0; i < imageCount; i++)
            {
                string outputPath = Path.Combine(outputDir, $"line_{i + 1}.bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                BmpOptions bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (Image image = Image.Create(bmpOptions, width, height))
                {
                    Graphics graphics = new Graphics(image);
                    graphics.Clear(Color.White);

                    int linesPerImage = 5;
                    for (int l = 0; l < linesPerImage; l++)
                    {
                        int x1 = rand.Next(width);
                        int y1 = rand.Next(height);
                        int x2 = rand.Next(width);
                        int y2 = rand.Next(height);

                        Color lineColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256));
                        float thickness = (float)(rand.NextDouble() * 5 + 1);

                        Pen pen = new Pen(lineColor, thickness);
                        graphics.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
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
 * 1. When you need a set of sample BMP files with varied line patterns to stress‑test image‑processing algorithms or OCR pipelines.
 * 2. When creating synthetic data for benchmarking the performance of drawing APIs or graphics libraries in .NET.
 * 3. When you want to populate a folder with placeholder graphics for UI mock‑ups that require different line styles and colors.
 * 4. When generating random line art to validate file‑format converters that must handle BMP input with diverse pixel data.
 * 5. When automating unit tests that require distinct image inputs to verify that image‑comparison logic correctly detects differences.
 */
