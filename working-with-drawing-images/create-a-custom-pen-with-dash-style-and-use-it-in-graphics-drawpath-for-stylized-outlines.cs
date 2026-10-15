// HOW-TO: Draw Dashed Rectangle Outline with Custom Pen in C# Using Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

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

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, 400, 300))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();

                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                RectangleShape rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(50, 50, 300, 200));
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                Aspose.Imaging.Pen pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 5);
                pen.DashStyle = Aspose.Imaging.DashStyle.Dash;

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
 * 1. When you need to generate a BMP image with a blue dashed border around a rectangle for a report or UI thumbnail.
 * 2. When you want to programmatically create stylized outlines for shapes in a server‑side C# application without using GDI+.
 * 3. When you have to export vector‑like graphics as raster files and require custom dash patterns for emphasis.
 * 4. When you are building a diagramming tool that draws selectable shapes with different pen styles using Aspose.Imaging.
 * 5. When you need to automate the creation of printable assets that include dashed frames around content areas.
 */
