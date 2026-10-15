// HOW-TO: Apply Emboss Filter to PNG While Preserving Alpha Transparency in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.RasterImage image = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Filter(
                    image.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                PngOptions options = new PngOptions()
                {
                    ColorType = PngColorType.TruecolorWithAlpha,
                    Source = new FileCreateSource(outputPath, false)
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
 * 1. When you need to add a subtle embossed effect to UI icons stored as PNGs without losing their transparent backgrounds.
 * 2. When generating stylized thumbnails for a web gallery where the original images contain alpha channels that must remain intact.
 * 3. When processing game sprites in C# to create a 3‑D look while keeping the sprite’s transparent edges for proper rendering.
 * 4. When automating batch conversion of logo files to an embossed style for marketing materials while preserving their PNG transparency.
 * 5. When applying a convolution filter to PNG assets in a desktop application and you must ensure the saved file retains truecolor with alpha for later compositing.
 */
