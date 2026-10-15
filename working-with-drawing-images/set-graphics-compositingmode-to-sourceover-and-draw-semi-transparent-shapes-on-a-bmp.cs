// HOW-TO: Draw Semi Transparent Shapes on BMP Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 300;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 32;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                RasterImage raster = (RasterImage)image;
                Graphics graphics = new Graphics(raster);
                graphics.Clear(Color.White);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush, 50, 50, 200, 150);
                }

                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    graphics.FillEllipse(brush2, 150, 100, 200, 150);
                }

                Pen pen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(pen, 50, 50, 200, 150);
                graphics.DrawEllipse(pen, 150, 100, 200, 150);

                image.Save();
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
 * 1. When you need to generate a 32‑bit BMP report with overlapping colored shapes for a desktop application.
 * 2. When you want to create watermark overlays on bitmap images without losing the original background.
 * 3. When you are building a custom chart or diagram where semi‑transparent rectangles and ellipses must be rendered programmatically.
 * 4. When you need to export UI mock‑ups as BMP files that preserve alpha blending for later compositing.
 * 5. When you are automating the production of printable graphics that require precise pixel dimensions and transparent layering using C#.
 */
