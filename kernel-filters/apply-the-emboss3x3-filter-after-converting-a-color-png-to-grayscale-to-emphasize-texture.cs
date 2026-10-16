// HOW-TO: Apply Emboss Filter to Grayscale PNG in C# with Aspose Imaging (Aspose.Imaging for .NET)
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
        string inputPath = "Input\\sample.png";
        string outputPath = "Output\\embossed.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                raster.Grayscale();

                double[,] customKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);

                var options = new PngOptions();
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
 * 1. When you need to highlight surface details in product photos by converting color PNGs to grayscale and applying an emboss filter for a tactile visual effect.
 * 2. When generating stylized thumbnails for a web gallery where texture emphasis on grayscale images improves visual interest.
 * 3. When preprocessing scanned documents to accentuate handwriting or printed text edges before OCR, using a convolution emboss kernel in C#.
 * 4. When creating artistic map overlays where terrain features are emphasized by embossing grayscale PNG layers with Aspose.Imaging.
 * 5. When building a C# desktop application that converts user‑uploaded PNGs to a grayscale embossed version for printable embossing previews.
 */
