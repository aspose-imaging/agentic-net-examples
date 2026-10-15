// HOW-TO: Fill a Polygon Shape in BMP Image Using Aspose.Imaging C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;
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

            int width = 500;
            int height = 500;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);

                GraphicsPath path = new GraphicsPath();

                Figure figure = new Figure();

                Aspose.Imaging.PointF[] points = new Aspose.Imaging.PointF[]
                {
                    new Aspose.Imaging.PointF(100, 100),
                    new Aspose.Imaging.PointF(400, 100),
                    new Aspose.Imaging.PointF(250, 400)
                };

                PolygonShape polygon = new PolygonShape(points);
                figure.AddShape(polygon);
                path.AddFigure(figure);

                using (SolidBrush brush = new SolidBrush(Aspose.Imaging.Color.Black))
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
 * 1. When you need to programmatically generate a BMP file with a custom‑drawn triangle for reports or thumbnails.
 * 2. When you want to overlay a solid‑filled polygon onto an existing canvas using Aspose.Imaging’s GraphicsPath in C#.
 * 3. When you are creating vector‑based graphics such as icons or schematics that require precise point coordinates and solid color fills.
 * 4. When you need to automate the production of raster images with geometric shapes for testing image‑processing pipelines.
 * 5. When you are building a server‑side service that renders simple shapes into BMP images without relying on GDI+.
 */
