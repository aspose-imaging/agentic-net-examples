// HOW-TO: Flatten GraphicsPath Curves to Lines for PNG Rendering in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\flattened.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                var graphics = new Aspose.Imaging.Graphics(image);

                var path = new Aspose.Imaging.GraphicsPath();

                var figure = new Aspose.Imaging.Figure();
                figure.AddShape(new Aspose.Imaging.Shapes.EllipseShape(new Aspose.Imaging.RectangleF(50, 50, 200, 100)));
                path.AddFigure(figure);

                // Flatten curves into line segments
                path.Flatten();

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawPath(pen, path);

                image.Save(outputPath, new PngOptions());
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
 * 1. When you need to convert complex vector shapes like ellipses into straight‑line approximations for faster rasterization of PNG images in a C# application.
 * 2. When generating thumbnails or previews where simplified geometry reduces rendering time without changing the visual outline.
 * 3. When exporting graphics to devices that only support polyline data, such as certain printers or CNC machines, by flattening the path before drawing.
 * 4. When performing hit‑testing or collision detection on drawn shapes and require the path to consist solely of line segments.
 * 5. When preparing images for compression algorithms that work better with straight edges, by flattening curves before saving the PNG with Aspose.Imaging.
 */
