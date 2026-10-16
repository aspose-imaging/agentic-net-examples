// HOW-TO: Create Filled and Outlined Rectangle PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Brushes;
using Aspose.Imaging.Shapes;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/output.png";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 300;
            var options = new PngOptions();

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();

                var rect = new RectangleF(50, 50, 300, 200);
                RectangleShape rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);

                path.AddFigure(figure);

                using (SolidBrush fillBrush = new SolidBrush(Color.LightBlue))
                {
                    graphics.FillPath(fillBrush, path);
                }

                Pen outlinePen = new Pen(Color.DarkBlue, 5);
                graphics.DrawPath(outlinePen, path);

                image.Save(outputPath);
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
 * 1. Use this code to generate a PNG badge where FillPath creates a light‑blue rectangle and DrawPath adds a dark‑blue border, ideal for custom UI icons.
 * 2. Apply the FillPath and DrawPath combination to produce highlighted sections in dynamically created diagrams, such as marking a selected area with a filled shape and an outline.
 * 3. Create placeholder images for reports or emails that require a colored rectangle filled with SolidBrush and outlined with Pen to indicate where content will be placed.
 * 4. Generate map overlays where a region is filled with a semi‑transparent color using FillPath and outlined with DrawPath for better visual distinction in a PNG tile.
 * 5. Build thumbnail images for product catalogs that need a solid background rectangle filled and bordered to improve visual separation.
 */
