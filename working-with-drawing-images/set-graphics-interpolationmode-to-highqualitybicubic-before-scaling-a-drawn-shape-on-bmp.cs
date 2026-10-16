// HOW-TO: Scale and Draw High‑Quality BMP Shapes with InterpolationMode in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.bmp";
            string outputPath = "output/output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                Graphics graphics = new Graphics(image);
                graphics.Clear(Color.White);

                Pen pen = new Pen(Color.Blue, 3);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 100, 100));

                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.ScaleTransform(1.5f, 1.5f);
                graphics.DrawRectangle(pen, new Rectangle(50, 50, 100, 100));

                BmpOptions options = new BmpOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to generate a BMP image with crisp, scaled vector graphics for printing or UI assets.
 * 2. When you want to apply high‑quality bicubic interpolation to avoid pixelation while enlarging drawn shapes in a bitmap.
 * 3. When you must programmatically clear a bitmap background, draw shapes, and then resize them for thumbnails or previews.
 * 4. When you are creating custom graphics in C# that require precise control over scaling and rendering quality before saving as BMP.
 * 5. When you need to automate batch processing of BMP files, adding scaled annotations with professional visual quality.
 */
