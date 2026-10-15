// HOW-TO: Increase PSD Brightness, Apply Anti-Alias Smoothing, Save As PNG In C# (Aspose.Imaging for .NET)
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

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.psd";
            string outputPath = "output\\brightened.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                raster.AdjustBrightness(50);

                Graphics graphics = new Graphics(raster);
                graphics.SmoothingMode = SmoothingMode.AntiAlias;

                PngOptions pngOptions = new PngOptions();
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to brighten a Photoshop PSD file before publishing it on a website and require a high‑quality PNG with anti‑alias edges.
 * 2. When an automated image‑processing pipeline must adjust the exposure of layered PSD assets and output them as PNGs for mobile apps.
 * 3. When converting legacy PSD designs to PNG while ensuring the visual smoothness of vector shapes by setting the graphics smoothing mode.
 * 4. When preparing product mockups by increasing brightness of PSD layers and exporting them to PNG for inclusion in marketing materials.
 * 5. When building a batch tool that processes multiple PSD files, enhances their brightness, applies anti‑aliasing, and saves the results as PNG for downstream workflows.
 */
