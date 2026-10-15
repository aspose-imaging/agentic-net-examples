// HOW-TO: Generate Multiple BMP Images with Colored Backgrounds and Centered Ellipse in C# (Aspose.Imaging for .NET)
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
            var colors = new (Color color, string name)[]
            {
                (Color.Red, "Red"),
                (Color.Green, "Green"),
                (Color.Blue, "Blue"),
                (Color.Yellow, "Yellow"),
                (Color.Cyan, "Cyan"),
                (Color.Magenta, "Magenta"),
                (Color.White, "White"),
                (Color.Gray, "Gray")
            };

            int width = 200;
            int height = 200;

            foreach (var item in colors)
            {
                string outputPath = $"output_{item.name}.bmp";
                string dir = Path.GetDirectoryName(outputPath);
                Directory.CreateDirectory(dir ?? ".");

                var bmpOptions = new BmpOptions();
                bmpOptions.Source = new FileCreateSource(outputPath, false);

                using (var image = Image.Create(bmpOptions, width, height) as RasterImage)
                {
                    var graphics = new Graphics(image);
                    graphics.Clear(item.color);

                    Pen pen = new Pen(Color.Black, 2);
                    int ellipseWidth = width / 2;
                    int ellipseHeight = height / 2;
                    int x = (width - ellipseWidth) / 2;
                    int y = (height - ellipseHeight) / 2;
                    graphics.DrawEllipse(pen, x, y, ellipseWidth, ellipseHeight);

                    image.Save();
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
 * 1. When a developer needs to create a set of BMP icons with different solid colors for UI themes, each containing a centered black ellipse as a placeholder graphic.
 * 2. When generating test assets for image‑processing pipelines that require BMP files of the same size but varied background colors to validate color‑handling logic.
 * 3. When producing sample images for documentation or tutorials that demonstrate how to draw shapes on a raster canvas using Aspose.Imaging in C#.
 * 4. When automating the creation of colored markers for a game map, where each BMP tile must have a distinct background hue and a consistent central ellipse marker.
 * 5. When preparing a batch of printable labels where the background color indicates category and the black ellipse serves as a visual anchor for barcode placement.
 */
