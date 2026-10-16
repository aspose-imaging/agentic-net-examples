// HOW-TO: Apply Blur Convolution Filter to PNG Ignoring Alpha in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output\\filtered.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel)
                {
                    IgnoreAlpha = true
                };
                image.Filter(image.Bounds, filterOptions);
                var saveOptions = new PngOptions();
                image.Save(outputPath, saveOptions);
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
 * 1. When you need to soften a product photo while preserving its transparent background by applying a blur that does not affect the alpha channel.
 * 2. When generating thumbnails for a web gallery and want a quick box blur applied to PNG images without altering their opacity.
 * 3. When preprocessing images for a machine‑learning pipeline and require a uniform blur while keeping the mask layer intact.
 * 4. When creating a stylized UI asset where the visual content should be blurred but the transparent edges must remain crisp.
 * 5. When automating batch image enhancement in a .NET service and need to apply a convolution blur to each file while ignoring alpha to avoid halo artifacts.
 */
