// HOW-TO: Add a Rectangle Shape to a PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
        try
        {
            string outputPath = "output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int canvasWidth = 200;
            int canvasHeight = 200;

            var options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (var image = Aspose.Imaging.Image.Create(options, canvasWidth, canvasHeight))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var figure = new Aspose.Imaging.Figure();
                var rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(50, 50, 100, 100));
                figure.AddShape(rectShape);

                var path = new Aspose.Imaging.GraphicsPath();
                path.AddFigure(figure);

                var pen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black);
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
 * 1. When you need to programmatically generate a PNG badge with a rectangular border for user avatars.
 * 2. When creating a dynamic report that requires drawing highlighted rectangular sections on a white canvas.
 * 3. When building a custom QR code overlay that includes a rectangle to indicate a scanning area.
 * 4. When automating the production of printable labels that contain a fixed-size rectangle as a placeholder for product images.
 * 5. When developing a simple diagram editor that adds rectangle shapes to an image before saving as PNG.
 */
