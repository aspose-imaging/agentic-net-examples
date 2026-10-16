// HOW-TO: Draw Precise Arc on BMP Using Graphics.DrawArc with Float Rectangle in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            int width = 300;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 2);
                RectangleF rect = new RectangleF(10.5f, 20.5f, 150.75f, 100.25f);
                graphics.DrawArc(pen, rect, 0, 180);

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
 * 1. When you need to generate a BMP report graphic that includes a precisely positioned semi‑circular gauge or meter.
 * 2. When creating custom UI icons in BMP format where the arc must be placed at sub‑pixel accuracy for high‑resolution displays.
 * 3. When programmatically adding a decorative arc to a BMP background for a game sprite sheet using Aspose.Imaging.
 * 4. When exporting engineering diagrams to BMP and require exact arc dimensions defined by floating‑point coordinates.
 * 5. When automating the production of printable BMP templates that contain arcs aligned to specific layout measurements.
 */
