// HOW-TO: Draw a Circle Approximation with Bezier Curves in BMP Using C# (Aspose.Imaging for .NET)
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
            string outputPath = "output\\bezier_circle.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int width = 400;
            int height = 400;
            int radius = 150;
            double k = 0.5522847498;

            BmpOptions options = new BmpOptions();
            options.Source = new FileCreateSource(outputPath, false);

            using (Image image = Image.Create(options, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Aspose.Imaging.Color.White);

                int cx = width / 2;
                int cy = height / 2;
                int kRadius = (int)(k * radius);

                Pen pen = new Pen(Aspose.Imaging.Color.Black, 2);

                // Segment 1
                graphics.DrawBezier(
                    pen,
                    new Point(cx + radius, cy),
                    new Point(cx + radius, cy + kRadius),
                    new Point(cx + kRadius, cy + radius),
                    new Point(cx, cy + radius));

                // Segment 2
                graphics.DrawBezier(
                    pen,
                    new Point(cx, cy + radius),
                    new Point(cx - kRadius, cy + radius),
                    new Point(cx - radius, cy + kRadius),
                    new Point(cx - radius, cy));

                // Segment 3
                graphics.DrawBezier(
                    pen,
                    new Point(cx - radius, cy),
                    new Point(cx - radius, cy - kRadius),
                    new Point(cx - kRadius, cy - radius),
                    new Point(cx, cy - radius));

                // Segment 4
                graphics.DrawBezier(
                    pen,
                    new Point(cx, cy - radius),
                    new Point(cx + kRadius, cy - radius),
                    new Point(cx + radius, cy - kRadius),
                    new Point(cx + radius, cy));

                // Save the image (bound to FileCreateSource)
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
 * 1. When you need to generate a high‑resolution BMP icon that contains a smooth circular shape without using rasterized circles, you can draw it with Bézier curves for precise control.
 * 2. When creating custom vector‑based graphics for engineering diagrams in a .NET application, this code shows how to approximate circles using Bézier segments that can be later edited or scaled.
 * 3. When exporting graphics to legacy BMP files for embedded systems that only support bitmap formats, the example demonstrates how to render a mathematically accurate circle using Aspose.Imaging.
 * 4. When building a drawing tool that lets users create shapes programmatically, you can use the same control‑point calculations to render circles with adjustable radius and line thickness.
 * 5. When you need to produce test images for image‑processing algorithms that require a perfect circular outline, this snippet creates a BMP file with a circle drawn by Bézier curves for consistent results.
 */
