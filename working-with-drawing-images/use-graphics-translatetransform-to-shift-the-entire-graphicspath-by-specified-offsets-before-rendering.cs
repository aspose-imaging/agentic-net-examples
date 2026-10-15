// HOW-TO: Shift And Draw A Rectangle On An Image Using TranslateTransform In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.jpg";
        string outputPath = "output/output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                GraphicsPath path = new GraphicsPath();

                Figure figure = new Figure();
                RectangleF rect = new RectangleF(0, 0, 100, 100);
                RectangleShape rectShape = new RectangleShape(rect);
                figure.AddShape(rectShape);
                path.AddFigure(figure);

                Graphics graphics = new Graphics(image);
                graphics.TranslateTransform(50, 30);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawPath(pen, path);

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
 * 1. When you need to add a blue rectangle annotation offset by specific X and Y coordinates to a JPEG photo for visual emphasis.
 * 2. When you want to programmatically shift a GraphicsPath before rendering to align custom shapes with existing content in an image.
 * 3. When creating a simple overlay such as a border or highlight on an image and need to control its position using TranslateTransform.
 * 4. When generating dynamic reports that require drawing shapes at precise locations on scanned documents loaded with Aspose.Imaging.
 * 5. When building a C# application that adds watermarks or markers to images and must adjust their placement without modifying the original shape definitions.
 */
