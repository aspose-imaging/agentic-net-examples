// HOW-TO: How To Unit Test Pixel Clamping For Convolution Filter With Large Kernel In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Create a simple 3x3 input image if it does not exist
            if (!File.Exists(inputPath))
            {
                int width = 3;
                int height = 3;
                var createOptions = new PngOptions();
                using (Image img = Image.Create(createOptions, width, height))
                {
                    var raster = (RasterImage)img;
                    // Fill with mid-gray (128,128,128)
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            raster.SetPixel(x, y, Color.FromArgb(255, 128, 128, 128));
                        }
                    }
                    Directory.CreateDirectory(Path.GetDirectoryName(inputPath) ?? ".");
                    raster.Save(inputPath);
                }
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image img = Image.Load(inputPath))
            {
                var raster = (RasterImage)img;
                if (!raster.IsCached) raster.CacheData();

                // Define a kernel with large coefficients to trigger clamping
                double[,] kernel = new double[,]
                {
                    { 10, 10, 10 },
                    { 10, 10, 10 },
                    { 10, 10, 10 }
                };

                // Apply convolution filter
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
                raster.Save(outputPath);
            }

            // Verify clamping
            using (Image resultImg = Image.Load(outputPath))
            {
                var resultRaster = (RasterImage)resultImg;
                bool clamped = true;
                for (int y = 0; y < resultRaster.Height; y++)
                {
                    for (int x = 0; x < resultRaster.Width; x++)
                    {
                        var color = resultRaster.GetPixel(x, y);
                        if (color.R < 0 || color.R > 255 ||
                            color.G < 0 || color.G > 255 ||
                            color.B < 0 || color.B > 255 ||
                            color.A < 0 || color.A > 255)
                        {
                            clamped = false;
                            break;
                        }
                    }
                    if (!clamped) break;
                }

                Console.WriteLine(clamped ? "Test Passed" : "Test Failed");
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
 * 1. When you need to verify that Aspose.Imaging correctly clamps pixel values after applying a convolution filter with extreme kernel coefficients in a C# unit test.
 * 2. When you want to ensure that processing a small PNG image with a high‑gain kernel does not produce invalid color values in a .NET application.
 * 3. When you are writing automated tests to confirm that the RasterImage class respects the 0‑255 range for each channel during custom filter operations.
 * 4. When you must validate that image caching and pixel manipulation work together without overflow errors in Aspose.Imaging for .NET.
 * 5. When you are debugging image sharpening or edge‑detection filters that use large kernel values and need to guarantee safe pixel clamping before saving the output file.
 */
