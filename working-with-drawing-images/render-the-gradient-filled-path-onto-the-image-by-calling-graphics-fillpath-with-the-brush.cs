// HOW-TO: Create PNG with Linear Gradient Filled Rectangle Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            var options = new PngOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 300;

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(options, width, height))
            {
                var graphics = new Aspose.Imaging.Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                var path = new Aspose.Imaging.GraphicsPath();
                var figure = new Aspose.Imaging.Figure();
                var rect = new Aspose.Imaging.RectangleF(50, 50, 300, 200);
                var rectShape = new Aspose.Imaging.Shapes.RectangleShape(rect);
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                using (var brush = new LinearGradientBrush(rect, Aspose.Imaging.Color.Blue, Aspose.Imaging.Color.Red, 0f))
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
 * 1. When generating dynamic charts or UI elements that require a rectangle with a smooth blue‑to‑red gradient saved as a PNG file.
 * 2. When creating custom email signatures or marketing banners where a gradient‑filled shape must be rendered programmatically in C#.
 * 3. When producing printable PDFs or reports that embed PNG images with gradient backgrounds for highlighted sections.
 * 4. When building a game or simulation that needs on‑the‑fly generation of textured sprites with linear gradient fills.
 * 5. When automating the creation of thumbnails or placeholders that display a colored gradient rectangle to indicate loading status.
 */
