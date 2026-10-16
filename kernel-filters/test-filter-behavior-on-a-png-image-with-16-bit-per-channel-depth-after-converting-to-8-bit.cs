// HOW-TO: Convert 16‑Bit PNG to 8‑Bit PNG Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Save as 8-bit PNG
                PngOptions options = new PngOptions
                {
                    BitDepth = 8,
                    ColorType = PngColorType.Truecolor,
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, options);
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
 * 1. When you need to reduce a high‑depth PNG to 8‑bit for faster web page loading while preserving true‑color fidelity.
 * 2. When a legacy system only accepts 8‑bit PNG files and you must down‑sample 16‑bit source images programmatically.
 * 3. When preparing images for mobile apps that require smaller file sizes, you can convert 16‑bit PNGs to 8‑bit using Aspose.Imaging in C#.
 * 4. When performing batch image processing to ensure consistent color depth across a catalog of photos, this code standardizes all PNGs to 8‑bit.
 * 5. When testing how PNG filter algorithms behave after reducing bit depth, you can save the converted image and compare results.
 */
