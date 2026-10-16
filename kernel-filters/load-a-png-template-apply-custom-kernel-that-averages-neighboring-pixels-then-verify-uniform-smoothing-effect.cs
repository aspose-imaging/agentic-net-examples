// HOW-TO: Apply Custom Averaging Convolution Filter to PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] customKernel = new double[,]
            {
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 }
            };

            using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel));

                PngOptions options = new PngOptions();
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
 * 1. When you need to reduce noise in a PNG template before overlaying dynamic graphics in a C# web application.
 * 2. When you want to create a uniformly blurred background for a game UI using Aspose.Imaging’s convolution filter.
 * 3. When preprocessing scanned PNG documents to smooth pixel variations for better OCR accuracy in a .NET service.
 * 4. When generating thumbnail previews that require a subtle smoothing effect to improve visual consistency across different devices.
 * 5. When applying a custom kernel to a PNG logo to achieve a consistent soft‑edge effect for branding materials in an automated build pipeline.
 */
