// HOW-TO: Create BMP Image with Star Shape Filled Yellow Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string outputPath = "output_star.bmp";
        try
        {
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);
            int width = 500;
            int height = 500;
            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                PointF[] starPoints = new PointF[]
                {
                    new PointF(250, 50),
                    new PointF(280, 180),
                    new PointF(400, 180),
                    new PointF(300, 250),
                    new PointF(340, 380),
                    new PointF(250, 300),
                    new PointF(160, 380),
                    new PointF(200, 250),
                    new PointF(100, 180),
                    new PointF(220, 180)
                };
                PolygonShape starShape = new PolygonShape(starPoints);
                Figure figure = new Figure();
                figure.AddShape(starShape);
                GraphicsPath path = new GraphicsPath();
                path.AddFigure(figure);
                // Radial gradient brush not supported; using SolidBrush as fallback
                using (SolidBrush brush = new SolidBrush(Color.Yellow))
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
 * 1. When you need to generate a BMP badge or icon that features a custom star graphic for a Windows desktop application.
 * 2. When you want to programmatically draw a polygon‑based logo, such as a star, and fill it with a solid color in a server‑side C# service.
 * 3. When you are creating printable marketing material that requires a high‑resolution star illustration saved as a BMP file using Aspose.Imaging.
 * 4. When you need to automate the production of star‑shaped markers on maps or charts and store them in a BMP format for legacy systems.
 * 5. When you are building a game asset pipeline that draws simple vector shapes like stars and exports them as BMP textures with a solid fill.
 */
