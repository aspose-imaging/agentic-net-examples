// HOW-TO: Draw and Fill Custom Five-Point Polygon to PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output\\custom_polygon.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            var options = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (var image = Aspose.Imaging.Image.Create(options, 500, 500))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var figure = new Aspose.Imaging.Figure();

                Aspose.Imaging.PointF[] points = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(100, 100),
                    new Aspose.Imaging.PointF(400, 100),
                    new Aspose.Imaging.PointF(350, 300),
                    new Aspose.Imaging.PointF(250, 400),
                    new Aspose.Imaging.PointF(150, 300)
                };

                var polygon = new PolygonShape(points);
                figure.AddShape(polygon);

                var path = new Aspose.Imaging.GraphicsPath();
                path.AddFigure(figure);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue);
                graphics.DrawPath(pen, path);

                using (var brush = new SolidBrush(Aspose.Imaging.Color.LightBlue))
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
 * 1. When you need to generate a PNG badge or icon that contains a custom star-shaped polygon for a web dashboard.
 * 2. When you want to programmatically create a filled geometric illustration for a PDF report or slide deck.
 * 3. When you must render a custom map marker with a specific polygon outline and fill color in a C# desktop application.
 * 4. When you are building a game UI and require dynamic polygon textures saved as PNG files.
 * 5. When you need to export a user-drawn shape from a drawing tool into a high-resolution PNG for further processing.
 */
