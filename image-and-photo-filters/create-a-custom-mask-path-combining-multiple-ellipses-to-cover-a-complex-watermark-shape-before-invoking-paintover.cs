// HOW-TO: Create Custom Elliptical Mask for Watermark Removal in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
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
            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();

                var fig1 = new Figure();
                fig1.AddShape(new EllipseShape(new RectangleF(10, 10, 100, 50)));
                mask.AddFigure(fig1);

                var fig2 = new Figure();
                fig2.AddShape(new EllipseShape(new RectangleF(150, 80, 120, 60)));
                mask.AddFigure(fig2);

                var fig3 = new Figure();
                fig3.AddShape(new EllipseShape(new RectangleF(300, 30, 80, 120)));
                mask.AddFigure(fig3);

                var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                using (var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                {
                    result.Save(outputPath, new PngOptions());
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
 * 1. When you need to erase a multi‑part watermark composed of overlapping oval shapes from a PNG image using Aspose.Imaging in C#.
 * 2. When you want to programmatically define a custom mask with several ellipses to protect specific regions while applying the PaintOver watermark removal method.
 * 3. When an automated batch process must clean scanned documents that contain irregular, elliptical watermarks without affecting the surrounding content.
 * 4. When integrating Aspose.Imaging into a .NET application to remove brand logos that are spread across different areas of an image by combining multiple ellipse shapes into one mask.
 * 5. When you require a reproducible way to generate a complex mask path for Telea watermark removal on raster images stored in PNG format.
 */
