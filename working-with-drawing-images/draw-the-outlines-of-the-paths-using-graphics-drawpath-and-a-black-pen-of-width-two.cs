// HOW-TO: Draw Rectangle and Ellipse Outlines on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded output path
            string outputPath = "output/output.bmp";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Define canvas size
            int width = 500;
            int height = 400;

            // Create BMP options with file source
            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            // Create image canvas
            using (Image image = Image.Create(options, width, height))
            {
                // Create graphics object
                Graphics graphics = new Graphics(image);

                // Create a graphics path
                GraphicsPath path = new GraphicsPath();

                // First figure: rectangle
                Figure rectFigure = new Figure();
                RectangleShape rectShape = new RectangleShape(new Aspose.Imaging.RectangleF(50, 50, 200, 150));
                rectFigure.AddShape(rectShape);
                path.AddFigure(rectFigure);

                // Second figure: ellipse
                Figure ellipseFigure = new Figure();
                EllipseShape ellipseShape = new EllipseShape(new Aspose.Imaging.RectangleF(300, 100, 150, 150));
                ellipseFigure.AddShape(ellipseShape);
                path.AddFigure(ellipseFigure);

                // Create black pen with width 2
                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);

                // Draw the path outlines
                graphics.DrawPath(pen, path);

                // Save the image (output is already bound to the file)
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
 * 1. When you need to generate a BMP file that highlights geometric shapes such as rectangles and ellipses with a thick black outline for reports or UI thumbnails.
 * 2. When creating a server‑side image rendering service that draws vector outlines on a bitmap without filling the shapes, using Aspose.Imaging in a C# web application.
 * 3. When automating the production of diagram assets where only the borders of shapes are required, for example for technical documentation or schematics.
 * 4. When you want to programmatically add a 2‑pixel black border around multiple shapes on a fixed‑size canvas before embedding the image into a PDF or email.
 * 5. When building a testing tool that verifies the correct placement and size of drawn paths by rendering them to a BMP and comparing the pixel output.
 */
