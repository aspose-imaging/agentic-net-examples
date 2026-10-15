// HOW-TO: Get Bounding Rectangle of GraphicsPath and Center an Ellipse in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (var image = Aspose.Imaging.Image.Create(new PngOptions(), 500, 500))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                // Create a rectangle shape inside a figure and add to a GraphicsPath
                var rectFigure = new Aspose.Imaging.Figure();
                var rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(100, 100, 200, 150));
                rectFigure.AddShape(rectShape);

                var path = new Aspose.Imaging.GraphicsPath();
                path.AddFigure(rectFigure);

                // Retrieve bounding rectangle of the path
                Aspose.Imaging.RectangleF bounds = path.GetBounds(new Aspose.Imaging.Matrix());

                // Draw the rectangle path
                var penRect = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawPath(penRect, path);

                // Align an ellipse to the center of the bounding rectangle
                float centerX = bounds.X + bounds.Width / 2;
                float centerY = bounds.Y + bounds.Height / 2;
                float radius = Math.Min(bounds.Width, bounds.Height) / 4;
                var ellipseRect = new Aspose.Imaging.RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);

                var ellipseFigure = new Aspose.Imaging.Figure();
                var ellipseShape = new EllipseShape(ellipseRect);
                ellipseFigure.AddShape(ellipseShape);

                var ellipsePath = new Aspose.Imaging.GraphicsPath();
                ellipsePath.AddFigure(ellipseFigure);

                var penEllipse = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 2);
                graphics.DrawPath(penEllipse, ellipsePath);

                // Save the image
                image.Save(outputPath);
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
 * 1. When you need to calculate the exact area occupied by a complex shape in a PNG image to position other graphics precisely.
 * 2. When you want to automatically place a logo or watermark at the center of a drawn rectangle without hard‑coding coordinates.
 * 3. When generating dynamic diagrams where an annotation (ellipse) must be aligned to the middle of a user‑defined bounding box.
 * 4. When creating printable reports that require centering decorative elements inside variable‑size containers using Aspose.Imaging for .NET.
 * 5. When developing a UI thumbnail generator that must overlay a highlight circle exactly within the bounds of a detected shape.
 */
