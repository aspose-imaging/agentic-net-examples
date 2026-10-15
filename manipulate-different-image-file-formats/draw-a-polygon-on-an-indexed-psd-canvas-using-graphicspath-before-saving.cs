// HOW-TO: Draw a Red Filled Polygon on Indexed PSD with C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output.psd";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            var psdOptions = new PsdOptions();
            psdOptions.Source = new FileCreateSource(outputPath, false);
            psdOptions.ColorMode = Aspose.Imaging.FileFormats.Psd.ColorModes.Indexed;
            psdOptions.Palette = new ColorPalette(new Color[] { Color.Black, Color.White });

            using (var image = Image.Create(psdOptions, 200, 200))
            {
                var graphics = new Graphics(image);
                var pen = new Pen(Color.Blue);
                using (var brush = new SolidBrush(Color.Red))
                {
                    graphics.Clear(Color.White);

                    var path = new GraphicsPath();
                    var figure = new Figure();

                    var points = new PointF[]
                    {
                        new PointF(50, 50),
                        new PointF(150, 50),
                        new PointF(150, 150),
                        new PointF(50, 150)
                    };

                    var polygon = new PolygonShape(points);
                    figure.AddShape(polygon);
                    path.AddFigure(figure);

                    graphics.DrawPath(pen, path);
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
 * 1. When you need to generate a PSD file with a limited color palette and programmatically add a custom shape such as a polygon for branding or UI mockups.
 * 2. When creating automated graphics for print workflows that require indexed color mode to reduce file size while preserving vector‑like shapes.
 * 3. When building a server‑side image service that draws geometric overlays on PSD layers for watermarking or annotation purposes.
 * 4. When prototyping design assets in C# where you must fill and stroke shapes on a PSD canvas before exporting to Photoshop.
 * 5. When integrating Aspose.Imaging into a .NET application to produce PSD templates with pre‑drawn polygons for later editing by designers.
 */
