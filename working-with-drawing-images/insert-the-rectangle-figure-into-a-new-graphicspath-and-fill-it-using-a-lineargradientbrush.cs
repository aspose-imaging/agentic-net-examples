// HOW-TO: Create PNG with Filled Rectangle Using GraphicsPath in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.png";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 200;
            int height = 200;

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Create(new PngOptions(), width, height))
            {
                var graphicsPath = new Aspose.Imaging.GraphicsPath();

                var figure = new Aspose.Imaging.Figure();
                var rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(20, 20, 160, 160));
                figure.AddShape(rectShape);
                graphicsPath.AddFigure(figure);

                using (var brush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    var graphics = new Aspose.Imaging.Graphics(image);
                    graphics.FillPath(brush, graphicsPath);
                }

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
 * 1. When you need to programmatically generate a PNG badge that contains a solid‑colored rectangle for branding or placeholder graphics.
 * 2. When creating custom thumbnails for documents where a rectangle shape must be drawn and filled using Aspose.Imaging’s GraphicsPath in C#.
 * 3. When building a reporting tool that adds highlighted rectangular sections to charts or diagrams before exporting them as PNG images.
 * 4. When developing a game UI overlay that requires drawing solid rectangular panels dynamically at runtime with .NET.
 * 5. When automating the production of printable labels that include a filled rectangle as a background element in a PNG file.
 */
