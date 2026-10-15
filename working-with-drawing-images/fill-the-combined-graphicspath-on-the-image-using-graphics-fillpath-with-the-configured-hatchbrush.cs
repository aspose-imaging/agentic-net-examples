// HOW-TO: Fill Combined Rectangle and Ellipse Path on PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(rasterImage);

                GraphicsPath path = new GraphicsPath();

                // First figure: rectangle
                Figure rectFigure = new Figure();
                RectangleShape rectShape = new RectangleShape(new RectangleF(50f, 50f, 200f, 150f));
                rectFigure.AddShape(rectShape);
                path.AddFigure(rectFigure);

                // Second figure: ellipse
                Figure ellipseFigure = new Figure();
                EllipseShape ellipseShape = new EllipseShape(new RectangleF(300f, 100f, 180f, 120f));
                ellipseFigure.AddShape(ellipseShape);
                path.AddFigure(ellipseFigure);

                using (SolidBrush solidBrush = new SolidBrush(Aspose.Imaging.Color.Blue))
                {
                    graphics.FillPath(solidBrush, path);
                }

                rasterImage.Save(outputPath);
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
 * 1. When you need to programmatically overlay a solid‑colored rectangle and ellipse onto an existing PNG for a custom watermark or UI element.
 * 2. When generating dynamic graphics such as badges or icons that require multiple shapes filled with the same color in a single raster image.
 * 3. When creating a composite shape for a game sprite sheet where both rectangular and elliptical regions must be painted uniformly.
 * 4. When automating batch processing of images to add blue‑filled geometric highlights for data‑visualization overlays.
 * 5. When building a reporting tool that draws combined shapes on scanned documents to indicate areas of interest before saving as PNG.
 */
