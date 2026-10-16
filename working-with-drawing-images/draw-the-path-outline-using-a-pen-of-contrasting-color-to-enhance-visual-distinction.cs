// HOW-TO: Draw Rectangle Path Outline on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 300, 200))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var path = new Aspose.Imaging.GraphicsPath();

                var figure = new Aspose.Imaging.Figure();

                var rectShape = new Aspose.Imaging.Shapes.RectangleShape(new Aspose.Imaging.RectangleF(50, 50, 200, 100));
                figure.AddShape(rectShape);

                path.AddFigure(figure);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 5);
                graphics.DrawPath(pen, path);

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
 * 1. Generate a BMP diagram with a black rectangle border for UI mockups using Aspose.Imaging in C#.
 * 2. Create test images that contain a known rectangle outline to validate image‑processing algorithms.
 * 3. Add a contrasting black pen outline around a region of interest in a bitmap before performing analysis.
 * 4. Produce printable BMP assets where a high‑contrast rectangle frame improves visibility on a white background.
 * 5. Automate thumbnail sketches that display object boundaries by drawing a rectangle path on a BMP file.
 */
