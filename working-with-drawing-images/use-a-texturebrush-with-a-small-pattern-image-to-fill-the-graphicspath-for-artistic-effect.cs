// HOW-TO: Fill a Rectangle with a Repeating Pattern Using TextureBrush in C# (Aspose.Imaging for .NET)
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
        string patternPath = "pattern.png";
        string outputPath = "output\\result.png";

        if (!File.Exists(patternPath))
        {
            Console.Error.WriteLine($"File not found: {patternPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Aspose.Imaging.RasterImage patternImage = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(patternPath))
            {
                int width = 500;
                int height = 500;
                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);

                using (Aspose.Imaging.RasterImage canvas = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Create(options, width, height))
                {
                    Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(canvas);
                    graphics.Clear(Aspose.Imaging.Color.White);

                    Aspose.Imaging.GraphicsPath path = new Aspose.Imaging.GraphicsPath();
                    Aspose.Imaging.Figure figure = new Aspose.Imaging.Figure();
                    Aspose.Imaging.RectangleF rect = new Aspose.Imaging.RectangleF(50, 50, 400, 400);
                    RectangleShape rectangleShape = new RectangleShape(rect);
                    figure.AddShape(rectangleShape);
                    path.AddFigure(figure);

                    using (TextureBrush textureBrush = new TextureBrush(patternImage))
                    {
                        graphics.FillPath(textureBrush, path);
                    }

                    canvas.Save();
                }
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
 * 1. When you need to create a decorative PNG where a small tile image repeats to fill a shape such as a rectangle.
 * 2. When generating custom UI assets that require a patterned background applied to vector paths using Aspose.Imaging in C#.
 * 3. When producing printable graphics that combine a high‑resolution canvas with a low‑resolution texture for artistic effects.
 * 4. When automating the creation of branded badges or logos that use a repeatable pattern inside geometric shapes.
 * 5. When building a server‑side image service that dynamically fills shapes with user‑supplied pattern images and returns PNG files.
 */
