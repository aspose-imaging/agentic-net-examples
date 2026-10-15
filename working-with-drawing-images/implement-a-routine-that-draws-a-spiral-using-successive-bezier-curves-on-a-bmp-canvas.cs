// HOW-TO: Create a Spiral Drawing with Bezier Curves on BMP in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/spiral.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 800;
            int height = 800;
            var bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (RasterImage image = (RasterImage)Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 2);

                float centerX = width / 2f;
                float centerY = height / 2f;
                float radiusStep = 20f;
                int segments = 12;
                float angle = 0f;
                float radius = 0f;

                for (int i = 0; i < segments; i++)
                {
                    float startAngle = angle;
                    float endAngle = angle + (float)Math.PI / 2f;
                    float startRadius = radius;
                    float endRadius = radius + radiusStep;

                    PointF p0 = new PointF(
                        centerX + startRadius * (float)Math.Cos(startAngle),
                        centerY + startRadius * (float)Math.Sin(startAngle));

                    PointF p3 = new PointF(
                        centerX + endRadius * (float)Math.Cos(endAngle),
                        centerY + endRadius * (float)Math.Sin(endAngle));

                    float ctrlRadius = startRadius + radiusStep / 2f;
                    float ctrlAngle1 = startAngle + (float)Math.PI / 4f;
                    float ctrlAngle2 = endAngle - (float)Math.PI / 4f;

                    PointF p1 = new PointF(
                        centerX + ctrlRadius * (float)Math.Cos(ctrlAngle1),
                        centerY + ctrlRadius * (float)Math.Sin(ctrlAngle1));

                    PointF p2 = new PointF(
                        centerX + ctrlRadius * (float)Math.Cos(ctrlAngle2),
                        centerY + ctrlRadius * (float)Math.Sin(ctrlAngle2));

                    graphics.DrawBezier(pen, p0, p1, p2, p3);

                    angle = endAngle;
                    radius = endRadius;
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
 * 1. When you need to generate a decorative spiral pattern for a bitmap logo or background programmatically using C# and Aspose.Imaging.
 * 2. When you want to create a series of smooth Bezier‑based arcs to illustrate mathematical spirals in scientific visualizations saved as BMP files.
 * 3. When an application must produce printable spiral graphics for CNC or laser‑cutting templates without relying on external design tools.
 * 4. When you are building a game or UI component that requires dynamically drawn spiral animations rendered to a raster image.
 * 5. When you need to export a custom spiral illustration to a BMP file for legacy systems that only accept uncompressed bitmap formats.
 */
