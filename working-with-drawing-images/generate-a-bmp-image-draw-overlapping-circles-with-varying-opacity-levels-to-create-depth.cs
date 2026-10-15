// HOW-TO: Create BMP Image with Overlapping Transparent Circles in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                // Circle 1: semi-transparent red
                using (SolidBrush brush1 = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillEllipse(brush1, 150 - 100, 150 - 100, 200, 200);
                }

                // Circle 2: more transparent green
                using (SolidBrush brush2 = new SolidBrush(Color.FromArgb(96, 0, 255, 0)))
                {
                    graphics.FillEllipse(brush2, 250 - 120, 200 - 120, 240, 240);
                }

                // Circle 3: less transparent blue
                using (SolidBrush brush3 = new SolidBrush(Color.FromArgb(160, 0, 0, 255)))
                {
                    graphics.FillEllipse(brush3, 200 - 80, 300 - 80, 160, 160);
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
 * 1. When you need to generate a BMP thumbnail that visualizes layered data by drawing semi‑transparent circles to indicate depth.
 * 2. When you want to programmatically create a simple diagram for a report, using overlapping colored circles with different opacity levels to highlight relationships.
 * 3. When you are building a game UI and require a background texture composed of blended circles rendered directly to a BMP file.
 * 4. When you need to export a custom legend or icon set where each element is drawn with varying transparency to convey hierarchy.
 * 5. When you are testing image‑processing pipelines and need a reproducible BMP file containing overlapping shapes with alpha blending for validation.
 */
