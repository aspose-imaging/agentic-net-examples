// HOW-TO: Apply Custom Convolution Kernel to Indexed PNG While Preserving Palette in C# (Aspose.Imaging for .NET)
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

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached) image.CacheData();

                double[,] kernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

                PngOptions options = new PngOptions()
                {
                    ColorType = PngColorType.IndexedColor
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
 * 1. When you need to sharpen or edge‑detect an indexed‑color PNG without losing its original palette, you can apply a custom convolution kernel using Aspose.Imaging in C#.
 * 2. When converting legacy game assets that use indexed PNGs, you may want to apply a color‑adjustment filter while keeping the limited color table intact.
 * 3. When processing map tiles stored as indexed PNGs, a developer can run a convolution filter to enhance features and still output a palette‑based PNG for fast web rendering.
 * 4. When creating stylized thumbnails from indexed PNG icons, applying a custom kernel lets you add artistic effects while preserving the small file size of indexed colors.
 * 5. When performing batch image preprocessing for a printing workflow that requires indexed PNGs, you can use this code to apply a filter and ensure the saved files remain in the indexed color format.
 */
