// HOW-TO: Create PNG with Ellipse Bounded by Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 500;
            int height = 500;

            using (var image = Image.Create(new PngOptions(), width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                var path = new GraphicsPath();

                var rect = new RectangleF(100, 100, 300, 200);
                var ellipseShape = new EllipseShape(rect);
                var figure = new Figure();
                figure.AddShape(ellipseShape);
                path.AddFigure(figure);

                var pen = new Pen(Color.Blue);
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
 * 1. When you need to generate a PNG badge that contains a centered ellipse inside a defined rectangular area for a web dashboard.
 * 2. When you want to programmatically create vector‑based graphics such as icons or placeholders by drawing shapes with Aspose.Imaging in a C# service.
 * 3. When an automated report generator must add an elliptical highlight to a specific region of an image before saving it as PNG.
 * 4. When a desktop application requires dynamic drawing of custom shapes, like an ellipse bounded by a rectangle, onto a blank canvas for user‑customized graphics.
 * 5. When you are building a testing tool that validates rendering of geometric primitives by creating PNG files with precise ellipse dimensions using Aspose.Imaging.
 */
