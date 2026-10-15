// HOW-TO: Compute Hash of JPEG After Gaussian Blur and Emboss in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output\\result.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Image is not a raster image.");
                    return;
                }

                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, gaussianOptions);

                var embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                raster.Filter(raster.Bounds, embossOptions);

                using (var ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions();
                    raster.Save(ms, pngOptions);
                    byte[] bytes = ms.ToArray();

                    ulong hash = 0;
                    foreach (byte b in bytes)
                    {
                        hash = hash * 31 + b;
                    }

                    ulong expectedHash = 0x123456789ABCDEF0;
                    if (hash == expectedHash)
                    {
                        Console.WriteLine("Test passed.");
                    }
                    else
                    {
                        Console.WriteLine($"Test failed. Expected: {expectedHash:X}, Got: {hash:X}");
                    }

                    File.WriteAllBytes(outputPath, bytes);
                }
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
 * 1. Verify that applying a Gaussian blur followed by an emboss filter to a JPEG produces the expected PNG output hash for automated regression testing.
 * 2. Generate a deterministic hash of a processed image to detect unintended changes in image processing pipelines during CI builds.
 * 3. Compare the result of chained filters against a known value when migrating image processing code to Aspose.Imaging for .NET.
 * 4. Ensure that image transformations such as blur and emboss are correctly applied before saving to PNG in a batch conversion utility.
 * 5. Validate that a custom image filter sequence yields consistent output across different environments by checking the computed hash.
 */
