// HOW-TO: Create a BMP Logo with Rectangles and Ellipses in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "output/logo.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            BmpOptions bmpOptions = new BmpOptions();
            bmpOptions.Source = new FileCreateSource(outputPath, false);

            int width = 200;
            int height = 200;

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen rectPen = new Pen(Color.Red, 5);
                Rectangle rect = new Rectangle(20, 20, 160, 160);
                graphics.DrawRectangle(rectPen, rect);

                Pen ellipsePen = new Pen(Color.Blue, 5);
                Rectangle ellipseRect = new Rectangle(50, 50, 100, 100);
                graphics.DrawEllipse(ellipsePen, ellipseRect);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 0, 255, 0)))
                {
                    graphics.FillEllipse(brush, ellipseRect);
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
 * 1. When you need to generate a simple company badge or logo on the fly as a BMP file using C# and Aspose.Imaging.
 * 2. When an application must create placeholder graphics with basic geometric shapes for testing UI layouts.
 * 3. When you want to programmatically add a colored ellipse overlay to a rectangular frame for custom watermarking.
 * 4. When a reporting tool requires embedding a dynamically drawn BMP icon that combines red borders and semi‑transparent green fills.
 * 5. When you are building a batch process that produces multiple BMP assets with consistent shape‑based designs for game sprites or icons.
 */
