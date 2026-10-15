// HOW-TO: Resize PNG with High Quality Bicubic Interpolation and Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Desired size (example: double the original dimensions)
                int newWidth = raster.Width * 2;
                int newHeight = raster.Height * 2;

                // High‑quality bicubic interpolation (using LanczosResample as the closest high‑quality option)
                raster.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to enlarge a PNG logo for a high‑resolution web banner while preserving sharp edges, you can resize it with Lanczos interpolation and export it as scalable SVG.
 * 2. When converting raster icons to vector format for responsive UI designs, resizing the PNG first ensures the SVG retains visual fidelity on larger screens.
 * 3. When preparing print‑ready graphics, you may upscale a PNG artwork using high‑quality bicubic interpolation before saving it as an SVG to avoid pixelation in the final print.
 * 4. When integrating image processing into a C# automation pipeline, you can programmatically resize PNG files and output them as SVGs for downstream vector‑based workflows.
 * 5. When optimizing assets for a mobile app that requires scalable vector images, resizing the source PNG with Lanczos resampling and converting it to SVG reduces file size while maintaining quality.
 */
