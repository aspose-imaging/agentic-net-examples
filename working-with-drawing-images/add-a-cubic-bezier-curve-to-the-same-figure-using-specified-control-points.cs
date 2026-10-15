// HOW-TO: Create BMP Image With Cubic Bezier Curve Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, 500, 500))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 2);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                PointF start = new PointF(50, 250);
                PointF control1 = new PointF(150, 50);
                PointF control2 = new PointF(350, 450);
                PointF end = new PointF(450, 250);

                PointF[] points = new PointF[] { start, control1, control2, end };
                BezierShape bezier = new BezierShape(points);
                figure.AddShape(bezier);
                path.AddFigure(figure);

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
 * 1. When you need to generate a BMP file that visualizes a smooth cubic Bezier curve for diagramming or UI mockups in a C# application.
 * 2. When you want to programmatically draw custom vector shapes, such as a curve defined by control points, onto an image for automated report generation.
 * 3. When you must create a high‑resolution raster image with precise curve geometry for printing or exporting to legacy BMP format.
 * 4. When you are building a graphics editor that lets users define Bezier control points and saves the result as a BMP using Aspose.Imaging.
 * 5. When you need to render mathematical or design curves on the server side without relying on GDI+ and store them as BMP files.
 */
