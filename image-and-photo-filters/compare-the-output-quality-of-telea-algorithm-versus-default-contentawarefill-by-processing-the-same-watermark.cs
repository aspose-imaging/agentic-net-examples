// HOW-TO: Compare Telea Vs ContentAwareFill Watermark Removal Quality In C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.png";
        string outputTeleaPath = "output_telea.png";
        string outputCafPath = "output_caf.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string dirTelea = Path.GetDirectoryName(outputTeleaPath);
            if (!string.IsNullOrEmpty(dirTelea))
                Directory.CreateDirectory(dirTelea);

            string dirCaf = Path.GetDirectoryName(outputCafPath);
            if (!string.IsNullOrEmpty(dirCaf))
                Directory.CreateDirectory(dirCaf);

            using (var image = Image.Load(inputPath))
            {
                var raster = (RasterImage)image;

                var mask = new GraphicsPath();
                var figure = new Figure();
                figure.AddShape(new EllipseShape(new RectangleF(50, 50, 200, 200)));
                mask.AddFigure(figure);

                var teleaOptions = new Aspose.Imaging.Watermark.Options.TeleaWatermarkOptions(mask);
                using (var resultTelea = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, teleaOptions))
                {
                    resultTelea.Save(outputTeleaPath, new PngOptions());
                }

                var cafOptions = new Aspose.Imaging.Watermark.Options.ContentAwareFillWatermarkOptions(mask);
                using (var resultCaf = Aspose.Imaging.Watermark.WatermarkRemover.PaintOver(raster, cafOptions))
                {
                    resultCaf.Save(outputCafPath, new PngOptions());
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
 * 1. When you need to evaluate which algorithm—Telea or the default ContentAwareFill—produces cleaner results for removing a circular watermark from a PNG image in a C# application.
 * 2. When you want to generate side‑by‑side PNG outputs to visually compare Telea and ContentAwareFill watermark removal for quality assurance.
 * 3. When you are building an automated pipeline that applies a custom ellipse mask to remove watermarks and must choose the most effective algorithm for consistent image processing.
 * 4. When you are testing performance and visual fidelity of Aspose.Imaging’s TeleaWatermarkOptions versus ContentAwareFillWatermarkOptions on raster images.
 * 5. When you need to demonstrate to clients or stakeholders the difference in output quality between Telea and ContentAwareFill watermark removal techniques using C# code.
 */
