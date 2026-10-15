// HOW-TO: Save PNG With Truecolor With Alpha Using Aspose.Imaging In C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                PngOptions options = new PngOptions
                {
                    ColorType = PngColorType.TruecolorWithAlpha
                };

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
 * 1. When you need to preserve full‑color transparency while converting or re‑saving PNG files in a .NET application.
 * 2. When generating thumbnails for UI assets that require an alpha channel to blend correctly over different backgrounds.
 * 3. When processing user‑uploaded PNG images and must ensure the output remains true‑color with alpha for downstream graphics pipelines.
 * 4. When exporting charts or diagrams from a server‑side service and want the resulting PNG to retain transparent backgrounds without color loss.
 * 5. When batch‑optimizing a collection of PNG assets and need to explicitly set the color type to Truecolor with Alpha to avoid palette reduction.
 */
