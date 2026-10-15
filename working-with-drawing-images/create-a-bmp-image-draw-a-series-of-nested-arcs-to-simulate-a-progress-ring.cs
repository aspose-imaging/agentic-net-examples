// HOW-TO: Create a BMP Progress Ring with Nested Arcs in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string outputPath = "progress_ring.bmp";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            int width = 200;
            int height = 200;

            var bmpOptions = new BmpOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            using (Image image = Image.Create(bmpOptions, width, height))
            {
                var graphics = new Graphics(image);
                graphics.Clear(Color.White);

                int centerX = width / 2;
                int centerY = height / 2;
                int maxRadius = Math.Min(width, height) / 2 - 10;
                int arcCount = 5;
                int arcThickness = 8;
                float startAngle = 0f;
                float sweepAngle = 270f;

                for (int i = 0; i < arcCount; i++)
                {
                    int radius = maxRadius - i * (arcThickness + 4);
                    if (radius <= 0) break;

                    var rect = new Rectangle(
                        centerX - radius,
                        centerY - radius,
                        radius * 2,
                        radius * 2);

                    var pen = new Pen(Color.FromArgb(255, 0, 120 + i * 20, 255 - i * 30), arcThickness);
                    graphics.DrawArc(pen, rect, startAngle, sweepAngle);
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
 * 1. When you need to generate a lightweight BMP file that visualizes download or processing progress as a circular ring for inclusion in a desktop application's status screen.
 * 2. When you want to programmatically create custom progress indicators with multiple colored arcs for dashboards or reports without relying on external image assets.
 * 3. When you are building a game or simulation that requires dynamically drawn radial meters and prefer using Aspose.Imaging to render them directly to BMP for fast loading.
 * 4. When you need to produce a series of nested arc graphics for a printable PDF or documentation and want to generate the base BMP images in C# first.
 * 5. When you are automating UI testing and need to create placeholder progress ring images to verify layout and scaling behavior across different resolutions.
 */
