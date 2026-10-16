// HOW-TO: Generate Multiple BMP Images with Different Shapes Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputDir = "output_shapes";
            Directory.CreateDirectory(outputDir);

            int width = 200;
            int height = 200;

            List<string> shapes = new List<string> { "Line", "Rectangle", "Ellipse", "Polygon", "Bezier", "Arc", "Pie" };

            foreach (string shape in shapes)
            {
                string outputPath = Path.Combine(outputDir, shape + ".bmp");
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (BmpOptions options = new BmpOptions())
                {
                    options.Source = new FileCreateSource(outputPath, false);
                    using (RasterImage image = (RasterImage)Image.Create(options, width, height))
                    {
                        Graphics graphics = new Graphics(image);
                        graphics.Clear(Color.White);
                        Pen pen = new Pen(Color.Black);

                        switch (shape)
                        {
                            case "Line":
                                graphics.DrawLine(pen, 10, 10, width - 10, height - 10);
                                break;
                            case "Rectangle":
                                graphics.DrawRectangle(pen, 20, 20, width - 40, height - 40);
                                break;
                            case "Ellipse":
                                graphics.DrawEllipse(pen, 20, 20, width - 40, height - 40);
                                break;
                            case "Polygon":
                                Point[] polyPoints = new Point[]
                                {
                                    new Point(50, 10),
                                    new Point(width - 10, 50),
                                    new Point(width - 50, height - 10),
                                    new Point(10, height - 50)
                                };
                                graphics.DrawPolygon(pen, polyPoints);
                                break;
                            case "Bezier":
                                Point p1 = new Point(10, height - 10);
                                Point p2 = new Point(10, 10);
                                Point p3 = new Point(width - 10, 10);
                                Point p4 = new Point(width - 10, height - 10);
                                graphics.DrawBezier(pen, p1, p2, p3, p4);
                                break;
                            case "Arc":
                                graphics.DrawArc(pen, 20, 20, width - 40, height - 40, 0, 180);
                                break;
                            case "Pie":
                                graphics.DrawPie(pen, 20, 20, width - 40, height - 40, 0, 90);
                                break;
                        }

                        image.Save();
                    }
                }
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
 * 1. When you need to create a set of sample BMP files showing basic geometric primitives for testing image processing algorithms.
 * 2. When you want to automatically generate icons or placeholders that contain a line, rectangle, ellipse, polygon, bezier curve, arc, or pie for UI mock‑ups.
 * 3. When you are building a teaching tool that demonstrates drawing operations in C# by producing separate BMP files for each shape.
 * 4. When you must prepare a batch of shape‑based assets for a game or simulation that requires individual BMP textures for different objects.
 * 5. When you need to export vector‑style drawings as raster BMP files in a predefined folder structure for documentation or reporting purposes.
 */
