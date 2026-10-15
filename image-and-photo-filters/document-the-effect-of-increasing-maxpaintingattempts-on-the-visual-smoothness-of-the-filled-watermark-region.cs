// HOW-TO: How Does MaxPaintingAttempts Affect Watermark Fill Smoothness In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPattern = "output_attempts_{0}.png";

            using (var image = Image.Load(inputPath))
            {
                var rasterImage = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                int[] attemptsValues = new int[] { 2, 4, 6, 8, 10 };
                foreach (int attempts in attemptsValues)
                {
                    var options = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask)
                    {
                        MaxPaintingAttempts = attempts
                    };

                    var result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(rasterImage, options);
                    string outPath = string.Format(outputPattern, attempts);
                    string outDir = Path.GetDirectoryName(outPath);
                    if (!string.IsNullOrEmpty(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }

                    result.Save(outPath, new PngOptions());
                    result.Dispose();
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
 * 1. When you need to compare how different MaxPaintingAttempts values change the visual quality of a content‑aware filled watermark in a PNG image using Aspose.Imaging for .NET.
 * 2. When you want to generate multiple output files that show the effect of increasing painting attempts on the smoothness of an elliptical mask applied to a raster image.
 * 3. When you are troubleshooting artifacts in a watermark removal workflow and need to determine the optimal MaxPaintingAttempts setting for clean edges.
 * 4. When you are building an automated batch process that saves versioned PNG results for each MaxPaintingAttempts value to evaluate performance versus image fidelity.
 * 5. When you are creating a demo or documentation that illustrates how content‑aware fill parameters influence the appearance of filled regions in images processed with Aspose.Imaging’s WatermarkRemover.
 */
