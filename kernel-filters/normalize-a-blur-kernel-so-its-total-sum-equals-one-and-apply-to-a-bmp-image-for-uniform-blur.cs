// HOW-TO: Normalize Blur Kernel and Apply Uniform Blur to BMP in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.bmp";
        string outputPath = "output/output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 },
                    { 0.04, 0.04, 0.04, 0.04, 0.04 }
                };

                double sum = 0;
                int rows = kernel.GetLength(0);
                int cols = kernel.GetLength(1);
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        sum += kernel[i, j];
                    }
                }

                double[,] normalized = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        normalized[i, j] = kernel[i, j] / sum;
                    }
                }

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(normalized);
                image.Filter(image.Bounds, filterOptions);

                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to soften a BMP photograph without changing its overall brightness, you can normalize a convolution kernel and apply a uniform blur using Aspose.Imaging.
 * 2. When processing scanned BMP documents and want to reduce noise while preserving average pixel intensity, a normalized blur filter ensures consistent lighting.
 * 3. When creating a preprocessing step for computer‑vision algorithms that require a smooth BMP image, normalizing the kernel prevents unintended darkening or brightening.
 * 4. When generating thumbnails from BMP assets and need a consistent blur effect across different images, a normalized kernel guarantees the same blur strength.
 * 5. When integrating image‑editing features into a C# desktop application and must apply a custom blur to BMP files while keeping the total pixel sum unchanged, this code provides a reliable solution.
 */
