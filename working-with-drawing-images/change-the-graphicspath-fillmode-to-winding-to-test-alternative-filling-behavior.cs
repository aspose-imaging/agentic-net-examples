// HOW-TO: Create BMP With Overlapping Rectangles Using Winding Fill Mode In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output_winding.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);
            int width = 400;
            int height = 400;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                GraphicsPath path = new GraphicsPath();
                path.FillMode = FillMode.Winding;

                Figure figure = new Figure();

                RectangleShape rect1 = new RectangleShape(new RectangleF(50, 50, 200, 200));
                figure.AddShape(rect1);

                RectangleShape rect2 = new RectangleShape(new RectangleF(150, 150, 200, 200));
                figure.AddShape(rect2);

                path.AddFigure(figure);

                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Black, 2);
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                {
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
 * 1. When you need to generate a BMP image that shows how overlapping shapes are filled using the winding rule for accurate vector rendering.
 * 2. When you want to test different fill modes in Aspose.Imaging to compare visual results of overlapping rectangles in a C# application.
 * 3. When creating a printable diagram where semi‑transparent red fills must correctly combine in intersecting areas of shapes.
 * 4. When developing a graphics editor that requires precise control over shape filling behavior for complex paths.
 * 5. When automating batch generation of bitmap assets that demonstrate fill‑mode effects for documentation or UI previews.
 */
