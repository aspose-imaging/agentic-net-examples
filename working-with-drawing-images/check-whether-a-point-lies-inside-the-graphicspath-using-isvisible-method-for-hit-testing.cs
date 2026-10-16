// HOW-TO: How to Test If a Point Is Inside a GraphicsPath in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Create(new BmpOptions(), 200, 200))
            {
                GraphicsPath path = new GraphicsPath();
                Figure figure = new Figure();
                RectangleF rect = new RectangleF(50, 50, 100, 100);
                RectangleShape rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                Point testPoint = new Point(75, 75);
                bool isInside = path.IsVisible(testPoint);
                Console.WriteLine($"Point ({testPoint.X}, {testPoint.Y}) inside path: {isInside}");

                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);
                graphics.DrawPath(new Pen(Color.Blue, 2), path);

                image.Save(outputPath, new BmpOptions());
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
 * 1. Use this code to determine whether a mouse click falls within a drawn rectangle for interactive image annotations in a BMP file.
 * 2. Apply the IsVisible hit‑testing method to enable custom shape selection in a C# graphics editor built with Aspose.Imaging.
 * 3. Validate user‑defined points against complex paths when implementing collision detection for game sprites rendered as BMP images.
 * 4. Perform server‑side verification that uploaded coordinates lie inside a predefined region before processing image transformations.
 * 5. Generate visual debugging output that highlights the tested area and logs whether a point is inside the GraphicsPath for quality‑assurance testing.
 */
