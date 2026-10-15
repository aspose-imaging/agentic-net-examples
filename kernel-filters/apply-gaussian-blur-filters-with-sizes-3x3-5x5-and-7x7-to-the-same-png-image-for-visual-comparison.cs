// HOW-TO: Apply 3x3 5x5 and 7x7 Gaussian Blur to PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath3 = "output_gaussian_3x3.png";
            string outputPath5 = "output_gaussian_5x5.png";
            string outputPath7 = "output_gaussian_7x7.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath3) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath5) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath7) ?? ".");

            using (RasterImage img3 = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel3 = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(3, 1.0);
                var options3 = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel3);
                img3.Filter(img3.Bounds, options3);
                img3.Save(outputPath3);
            }

            using (RasterImage img5 = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel5 = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                var options5 = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel5);
                img5.Filter(img5.Bounds, options5);
                img5.Save(outputPath5);
            }

            using (RasterImage img7 = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel7 = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(7, 1.0);
                var options7 = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel7);
                img7.Filter(img7.Bounds, options7);
                img7.Save(outputPath7);
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
 * 1. When you need to compare the visual effect of different Gaussian blur radii on a PNG before choosing the optimal level for a UI thumbnail.
 * 2. When generating multiple blurred versions of the same image for progressive loading or placeholder graphics in a web application.
 * 3. When testing how varying kernel sizes (3x3, 5x5, 7x7) impact image sharpness in a computer‑vision preprocessing pipeline.
 * 4. When creating side‑by‑side before‑and‑after samples for documentation or marketing materials that demonstrate smoothing effects.
 * 5. When automating batch processing of PNG assets to produce preset blur levels for artistic filters in a photo‑editing tool.
 */
