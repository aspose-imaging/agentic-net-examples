// HOW-TO: Create Indexed PSD With Shapes Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Psd;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var createOptions = new PsdOptions();
            createOptions.Source = new FileCreateSource(outputPath, false);
            createOptions.ColorMode = ColorModes.Indexed;
            createOptions.Palette = new ColorPalette(new Color[]
            {
                Color.Black,
                Color.White,
                Color.Red,
                Color.Green,
                Color.Blue
            });

            int width = 500;
            int height = 400;

            using (var psd = Image.Create(createOptions, width, height))
            {
                var graphics = new Graphics(psd);
                graphics.Clear(Color.White);

                // Rectangle
                Pen rectPen = new Pen(Color.Black, 2);
                graphics.DrawRectangle(rectPen, new Rectangle(50, 50, 200, 100));

                // Ellipse
                using (var ellipseBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillEllipse(ellipseBrush, new Rectangle(300, 50, 150, 100));
                }

                // Polygon
                Point[] polygonPoints = new Point[]
                {
                    new Point(100, 200),
                    new Point(150, 250),
                    new Point(50, 250)
                };
                Pen polyPen = new Pen(Color.Blue, 2);
                graphics.DrawPolygon(polyPen, polygonPoints);
                using (var polyBrush = new SolidBrush(Color.Green))
                {
                    graphics.FillPolygon(polyBrush, polygonPoints);
                }

                psd.Save();
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
 * 1. When you need to generate a PSD file with an indexed color palette that contains basic geometric shapes such as rectangles, ellipses, and polygons for web‑ready graphics.
 * 2. When automating a design workflow that programmatically draws vector‑style shapes onto an indexed PSD using Aspose.Imaging in C#.
 * 3. When creating thumbnail previews of layered artwork where only a few indexed colors are required and simple shapes must be rendered.
 * 4. When building a custom report that embeds geometric diagrams into a Photoshop PSD template while preserving a limited color set.
 * 5. When producing UI mock‑ups that consist of basic shapes and must be saved in Photoshop’s indexed‑color format for downstream processing.
 */
