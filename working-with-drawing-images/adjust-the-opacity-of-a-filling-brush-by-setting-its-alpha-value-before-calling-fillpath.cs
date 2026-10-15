// HOW-TO: Set Brush Opacity When Filling Path In BMP Image With C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.BitsPerPixel = 24;
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, 200, 200))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();

                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                Aspose.Imaging.Shapes.RectangleShape rectShape = new Aspose.Imaging.Shapes.RectangleShape(
                    new Aspose.Imaging.RectangleF(50, 50, 100, 100));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.FromArgb(128, 255, 0, 0)))
                {
                    graphics.FillPath(brush, path);
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
 * 1. When you need to create a semi‑transparent rectangle overlay on a BMP image for a watermark effect.
 * 2. When generating UI icons that require a partially opaque shape to blend with background colors.
 * 3. When adding a translucent highlight to scanned documents to indicate areas of interest without obscuring underlying text.
 * 4. When producing preview thumbnails where a colored overlay must be visible but not fully block the original image.
 * 5. When designing custom report graphics that use semi‑transparent fills to differentiate data regions in a bitmap chart.
 */
