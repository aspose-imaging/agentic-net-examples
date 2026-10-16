// HOW-TO: Adjust Gamma of PSD and Export to PNG with Anti-Aliasing in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.psd";
            string outputPath = "Output/enhanced.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image psdImage = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)psdImage;
                raster.AdjustGamma(2.2f);

                int width = raster.Width;
                int height = raster.Height;

                PngOptions pngOptions = new PngOptions();
                pngOptions.Source = new FileCreateSource(outputPath, false);

                using (Image pngImage = Image.Create(pngOptions, width, height))
                {
                    Graphics graphics = new Graphics(pngImage);
                    graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    graphics.DrawImage(raster, new Rectangle(0, 0, width, height));
                    pngImage.Save();
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
 * 1. When a developer needs to correct the brightness of a Photoshop PSD by applying gamma adjustment before converting it to a web‑ready PNG.
 * 2. When an application must ensure consistent color appearance across monitors by setting a specific gamma value on PSD images prior to export.
 * 3. When generating thumbnails from PSD files and wants smooth edges, the code enables anti‑aliasing during the raster‑to‑PNG conversion.
 * 4. When converting layered PSD assets into a single‑layer PNG while preserving image quality through gamma correction and smoothing.
 * 5. When automating a batch workflow that prepares print‑ready PSDs for online publishing, applying gamma and anti‑aliasing before saving as PNG.
 */
