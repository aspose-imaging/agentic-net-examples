// HOW-TO: Create BMP with Light Blue Background and Overlapping Transparent Rectangles in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\result.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 400;

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            bmpOptions.BitsPerPixel = 32;

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.FromArgb(255, 173, 216, 230));

                using (SolidBrush brush1 = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillRectangle(brush1, 50, 50, 200, 150);
                }
                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(128, 0, 255, 0)))
                {
                    graphics.FillRectangle(brush2, 150, 100, 200, 150);
                }
                using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(128, 0, 0, 255)))
                {
                    graphics.FillRectangle(brush3, 100, 200, 200, 150);
                }

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
 * 1. When you need to generate a BMP report card with a light‑blue canvas and layered colored highlights to indicate different score ranges.
 * 2. When creating a game map thumbnail where semi‑transparent red, green, and blue zones overlap to show territory control.
 * 3. When producing a UI mockup that requires a background color and overlapping translucent buttons rendered directly to a BMP file.
 * 4. When automating the creation of printable labels that use colored transparent overlays to mark priority levels on a light‑blue background.
 * 5. When building a diagnostic tool that visualizes sensor zones as overlapping semi‑transparent rectangles on a BMP image for easy analysis.
 */
