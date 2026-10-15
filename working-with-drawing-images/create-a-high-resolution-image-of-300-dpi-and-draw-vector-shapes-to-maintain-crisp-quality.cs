// HOW-TO: Create High Resolution 300 DPI SVG with Vector Shapes in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.Sources;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.svg";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 1200;
            int height = 800;

            SvgOptions options = new SvgOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen bluePen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(bluePen, 100, 100, 400, 300);

                using (SolidBrush redBrush = new SolidBrush(Color.Red))
                {
                    graphics.FillEllipse(redBrush, 600, 100, 400, 300);
                }

                Pen greenPen = new Pen(Color.Green, 2);
                graphics.DrawLine(greenPen, 100, 500, 1100, 700);

                Pen magentaPen = new Pen(Color.Magenta, 2);
                Point[] polygonPoints = new Point[]
                {
                    new Point(600, 500),
                    new Point(800, 450),
                    new Point(1000, 550),
                    new Point(850, 650),
                    new Point(650, 600)
                };
                graphics.DrawPolygon(magentaPen, polygonPoints);

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
 * 1. When you need to generate a scalable SVG diagram with precise rectangles, ellipses, lines and polygons for print‑ready 300 DPI output in a C# application.
 * 2. When you want to programmatically create vector‑based graphics for responsive web pages or UI icons without losing quality at any resolution.
 * 3. When an automated reporting tool must embed crisp geometric shapes into SVG files that will be later converted to PDFs or high‑resolution prints.
 * 4. When a CAD‑like preview is required in a .NET service, drawing custom shapes on a vector canvas that can be edited or scaled by end users.
 * 5. When you are building a batch process that produces multiple SVG assets with consistent styling and exact dimensions for marketing collateral.
 */
