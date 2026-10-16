// HOW-TO: Widen Graphics Path By 3 Pixels Using Thick Pen In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 200;
            int height = 200;

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(bmpOptions, width, height))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();

                Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                Aspose.Imaging.RectangleF rect = new Aspose.Imaging.RectangleF(50, 50, 100, 100);
                RectangleShape rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                Aspose.Imaging.Pen thickPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 3);
                path.Widen(thickPen);

                Aspose.Imaging.Pen drawPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 1);
                graphics.DrawPath(drawPen, path);

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
 * 1. When you need to increase the clickable area of a rectangle shape for accurate hit‑testing in a PNG image generated with Aspose.Imaging.
 * 2. When creating a bitmap thumbnail where the border must be expanded by a few pixels to ensure the shape is fully visible after scaling.
 * 3. When implementing a custom selection tool that requires a thicker outline around vector paths to improve user interaction feedback.
 * 4. When generating a red‑outlined diagram on a white background and you must widen the underlying path to match a 3‑pixel black hit‑test region.
 * 5. When converting vector drawings to a BMP file and need to apply a thick pen to the path before rendering to guarantee consistent stroke width across different output formats.
 */
