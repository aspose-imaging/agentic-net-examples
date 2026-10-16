// HOW-TO: Apply Semi Transparent Red Overlay to PNG Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    Graphics graphics = new Graphics(raster);

                    GraphicsPath path = new GraphicsPath();
                    Figure figure = new Figure();

                    RectangleF rect = new RectangleF(0, 0, raster.Width, raster.Height);
                    RectangleShape rectShape = new RectangleShape(rect);
                    figure.AddShape(rectShape);
                    path.AddFigure(figure);

                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(128, 255, 0, 0)))
                    {
                        graphics.FillPath(brush, path);
                    }

                    PngOptions options = new PngOptions();
                    raster.Save(outputPath, options);
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
 * 1. When you need to add a semi‑transparent red tint over a PNG to highlight or mask the entire image in a C# application.
 * 2. When creating a visual warning overlay on screenshots before saving them as PNG files using Aspose.Imaging.
 * 3. When generating a red‑colored heat‑map effect on raster images for data visualization in .NET.
 * 4. When applying a uniform translucent color filter to batch‑process images for branding or UI themes.
 * 5. When implementing a simple red overlay for privacy masking of sensitive areas in images before distribution.
 */
