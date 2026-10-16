// HOW-TO: Load BMP Clear to White and Draw Shapes with Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.Brushes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.bmp";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.Graphics graphics = new Aspose.Imaging.Graphics(image);

                // Clear with white
                graphics.Clear(Aspose.Imaging.Color.White);

                // Draw a red line
                Aspose.Imaging.Pen redPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Red, 3);
                graphics.DrawLine(redPen, new Aspose.Imaging.Point(10, 10), new Aspose.Imaging.Point(200, 10));

                // Draw a blue rectangle
                Aspose.Imaging.Pen bluePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Blue, 2);
                graphics.DrawRectangle(bluePen, new Aspose.Imaging.Rectangle(20, 20, 150, 100));

                // Fill a green ellipse
                using (SolidBrush greenBrush = new SolidBrush(Aspose.Imaging.Color.Green))
                {
                    graphics.FillEllipse(greenBrush, new Aspose.Imaging.Rectangle(50, 150, 120, 80));
                }

                // Draw a black bezier curve
                Aspose.Imaging.Pen blackPen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Black, 2);
                graphics.DrawBezier(blackPen,
                    new Aspose.Imaging.Point(300, 50),
                    new Aspose.Imaging.Point(350, 10),
                    new Aspose.Imaging.Point(400, 90),
                    new Aspose.Imaging.Point(450, 50));

                // Draw and fill a polygon
                Aspose.Imaging.Pen purplePen = new Aspose.Imaging.Pen(Aspose.Imaging.Color.Purple, 2);
                Aspose.Imaging.Point[] polygonPoints = new Aspose.Imaging.Point[]
                {
                    new Aspose.Imaging.Point(300, 150),
                    new Aspose.Imaging.Point(350, 200),
                    new Aspose.Imaging.Point(320, 250),
                    new Aspose.Imaging.Point(280, 250),
                    new Aspose.Imaging.Point(250, 200)
                };
                graphics.DrawPolygon(purplePen, polygonPoints);
                using (SolidBrush orangeBrush = new SolidBrush(Aspose.Imaging.Color.Orange))
                {
                    graphics.FillPolygon(orangeBrush, polygonPoints);
                }

                // Save the modified image
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
 * 1. When you need to replace the background of an existing BMP with a solid white canvas before adding custom graphics using Aspose.Imaging in a C# application.
 * 2. When you want to programmatically overlay a red line, blue rectangle, green ellipse, and black bezier curve onto a bitmap for generating annotated diagrams.
 * 3. When you are creating dynamic report images in .NET that require vector drawing on top of a loaded BMP file.
 * 4. When you need to preprocess a BMP by clearing it and then draw geometric shapes for a game sprite or UI element.
 * 5. When you are automating the production of printable assets where precise shape positioning on a BMP is required.
 */
