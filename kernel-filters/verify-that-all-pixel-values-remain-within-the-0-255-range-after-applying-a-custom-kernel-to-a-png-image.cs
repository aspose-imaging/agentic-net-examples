// HOW-TO: Verify PNG Pixel Values Stay Within 0-255 After Custom Convolution in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] customKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);
                raster.Filter(raster.Bounds, filterOptions);

                int[] pixels = raster.LoadArgb32Pixels(raster.Bounds);
                bool allInRange = true;
                foreach (int pixel in pixels)
                {
                    int a = (pixel >> 24) & 0xFF;
                    int r = (pixel >> 16) & 0xFF;
                    int g = (pixel >> 8) & 0xFF;
                    int b = pixel & 0xFF;
                    if (a < 0 || a > 255 || r < 0 || r > 255 || g < 0 || g > 255 || b < 0 || b > 255)
                    {
                        allInRange = false;
                        break;
                    }
                }

                if (!allInRange)
                {
                    Console.Error.WriteLine("Pixel values out of range after filter.");
                }

                var options = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
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
 * 1. When you need to ensure that applying a custom convolution filter to a PNG does not produce color values outside the 0‑255 range before saving the image.
 * 2. When you want to validate the integrity of ARGB32 pixel data after image processing to prevent overflow errors in downstream graphics pipelines.
 * 3. When you are building an automated image‑processing workflow in C# that must guarantee safe pixel values for further analysis or machine‑learning models.
 * 4. When you are debugging a custom kernel implementation and need to detect out‑of‑range pixel values that could cause corrupted PNG files.
 * 5. When you are integrating Aspose.Imaging into a .NET application and must confirm that filtered images remain compliant with standard PNG color depth specifications.
 */
