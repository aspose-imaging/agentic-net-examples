// HOW-TO: Draw a Custom Five‑Point Star on BMP with Aspose.Imaging C# (Aspose.Imaging for .NET)
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
            string outputPath = "output/star.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            int width = 500;
            int height = 500;

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                double outerRadius = 200;
                double innerRadius = 80;
                int pointsCount = 5;
                List<Point> points = new List<Point>();

                for (int i = 0; i < pointsCount * 2; i++)
                {
                    double angle = Math.PI / pointsCount * i - Math.PI / 2;
                    double radius = (i % 2 == 0) ? outerRadius : innerRadius;
                    int x = centerX + (int)(radius * Math.Cos(angle));
                    int y = centerY + (int)(radius * Math.Sin(angle));
                    points.Add(new Point(x, y));
                }

                Pen pen = new Pen(Color.Yellow, 3);
                for (int i = 0; i < points.Count; i++)
                {
                    Point p1 = points[i];
                    Point p2 = points[(i + 1) % points.Count];
                    graphics.DrawLine(pen, p1.X, p1.Y, p2.X, p2.Y);
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
 * 1. When you need to generate a decorative star logo directly in a BMP file for a Windows desktop application.
 * 2. When you want to create dynamic badge icons with a star shape that can be customized by changing radius or point count at runtime.
 * 3. When you are building a game asset pipeline that requires programmatically drawing polygonal stars onto bitmap textures using C#.
 * 4. When you need to export a star‑shaped diagram to a BMP for printing or embedding in reports without using external design tools.
 * 5. When you are testing the Aspose.Imaging drawing API by rendering geometric shapes such as a multi‑segment star on a blank canvas.
 */
