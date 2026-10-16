// HOW-TO: Batch Apply Elliptical Telea Inpainting to PNG Images in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Shapes;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "InputImages";
            string outputDirectory = "OutputImages";

            if (!Directory.Exists(inputDirectory))
            {
                Directory.CreateDirectory(inputDirectory);
                Console.WriteLine($"Input directory created at: {inputDirectory}. Add PNG files and rerun.");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            string[] files = Directory.GetFiles(inputDirectory, "*.png");

            foreach (string inputPath in files)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    continue;
                }

                string fileName = Path.GetFileName(inputPath);
                string outputPath = Path.Combine(outputDirectory, fileName);

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (Image image = Image.Load(inputPath))
                {
                    RasterImage raster = (RasterImage)image;

                    var mask = new GraphicsPath();
                    var figure = new Figure();
                    figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                    mask.AddFigure(figure);

                    var options = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);

                    using (RasterImage result = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, options))
                    {
                        var saveOptions = new PngOptions
                        {
                            ColorType = PngColorType.TruecolorWithAlpha,
                            Source = new FileCreateSource(outputPath, false)
                        };
                        result.Save(outputPath, saveOptions);
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
 * 1. When you need to automatically remove a circular watermark from dozens of PNG files using the Telea inpainting algorithm.
 * 2. When you want to apply the same elliptical mask to a whole folder of product photos to hide sensitive areas before publishing.
 * 3. When you must batch‑process scanned documents in PNG format, restoring missing content inside a defined ellipse with Aspose.Imaging.
 * 4. When you are building a C# utility that cleans up PNG assets by painting over unwanted regions with Telea‑based reconstruction.
 * 5. When you require a repeatable script that loads each PNG, applies an ellipse shape mask, and saves the edited image to an output directory.
 */
