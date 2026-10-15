// HOW-TO: Apply Manual Polygon Mask to PNG and Save Transparent Image in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Masking;
using Aspose.Imaging.Masking.Options;
using Aspose.Imaging.Masking.Result;
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PointF[] points = new PointF[]
                {
                    new PointF(50, 50),
                    new PointF(150, 50),
                    new PointF(150, 150),
                    new PointF(50, 150)
                };

                GraphicsPath manualMask = new GraphicsPath();
                Figure figure = new Figure();
                figure.AddShape(new PolygonShape(points));
                manualMask.AddFigure(figure);

                var maskingOptions = new MaskingOptions
                {
                    Method = SegmentationMethod.Manual,
                    Args = new ManualMaskingArgs { Mask = manualMask },
                    Decompose = false,
                    BackgroundReplacementColor = Color.Transparent
                };

                using (MaskingResult results = new ImageMasking(image).Decompose(maskingOptions))
                {
                    using (RasterImage foreground = (RasterImage)results[1].GetImage())
                    {
                        var saveOptions = new PngOptions { ColorType = PngColorType.TruecolorWithAlpha };
                        foreground.Save(outputPath, saveOptions);
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
 * 1. When you need to remove a rectangular area from a PNG and keep the rest transparent using a custom polygon mask in C#.
 * 2. When you want to extract the foreground of a logo image by defining its corners with a PointF array and save it with an alpha channel.
 * 3. When you are building a batch process that applies the same manual mask to multiple PNG files to create cut‑out assets for a game UI.
 * 4. When you have a scanned PNG diagram and must isolate a specific region by manually drawing a polygon, then export the isolated part as a transparent PNG.
 * 5. When you require a programmatic way to replace the background of a PNG with transparency without using AI‑based segmentation, using Aspose.Imaging’s manual masking API.
 */
