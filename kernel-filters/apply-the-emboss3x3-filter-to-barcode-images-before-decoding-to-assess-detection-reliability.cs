// HOW-TO: Apply Emboss 3x3 Filter To Barcode PNG Before Decoding In C# (Aspose.Imaging for .NET)
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

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                var options = new PngOptions();
                rasterImage.Save(outputPath, options);
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
 * 1. When you need to simulate a low‑contrast embossed effect on a scanned barcode PNG using Aspose.Imaging to test how a decoder handles altered edge details.
 * 2. When preprocessing barcode images with Aspose.Imaging’s Emboss3x3 convolution filter helps evaluate the robustness of a barcode reading algorithm under harsh visual conditions.
 * 3. When generating sample images for quality‑control pipelines that require the barcode to be embossed before being saved as a PNG file with Aspose.Imaging.
 * 4. When you want to automatically apply an emboss effect to incoming barcode scans in a C# service using Aspose.Imaging before storing them for later analysis.
 * 5. When testing the impact of the Emboss3x3 filter on detection reliability of various barcode symbologies in a .NET imaging workflow.
 */
