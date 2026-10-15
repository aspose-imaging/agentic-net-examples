// HOW-TO: Add a Figure with Rectangle to GraphicsPath and Save BMP in C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/output.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 300;

            var bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            using (var image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                var path = new GraphicsPath();

                var figure = new Figure();

                var rect = new RectangleF(50, 50, 200, 100);
                var rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);

                path.AddFigure(figure);

                var pen = new Pen(Color.Blue);
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
 * 1. When you need to programmatically generate a BMP file with a blue rectangle for a report thumbnail.
 * 2. When you want to create vector‑based drawings using Aspose.Imaging’s GraphicsPath and Figure objects in a C# application.
 * 3. When you need to overlay simple geometric shapes on a white canvas before adding custom annotations.
 * 4. When you are building a batch process that creates placeholder images for UI mockups using rectangle shapes.
 * 5. When you require a reproducible way to draw and save basic shapes without relying on GDI+ in .NET.
 */
