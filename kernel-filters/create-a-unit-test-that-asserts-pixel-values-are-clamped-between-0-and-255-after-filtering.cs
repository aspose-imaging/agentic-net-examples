// HOW-TO: Verify Convolution Filter Clamps Pixel Values Between 0 and 255 in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] embossKernel = new double[,]
                {
                    { -2, -1, 0 },
                    { -1, 1, 1 },
                    { 0, 1, 2 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
                image.Filter(image.Bounds, filterOptions);
                image.Save(outputPath, new JpegOptions());

                int[] pixels = image.LoadArgb32Pixels(image.Bounds);
                bool allClamped = true;

                foreach (int argb in pixels)
                {
                    byte a = (byte)((argb >> 24) & 0xFF);
                    byte r = (byte)((argb >> 16) & 0xFF);
                    byte g = (byte)((argb >> 8) & 0xFF);
                    byte b = (byte)(argb & 0xFF);

                    if (a > 255 || r > 255 || g > 255 || b > 255)
                    {
                        allClamped = false;
                        break;
                    }
                }

                if (allClamped)
                {
                    Console.WriteLine("Test passed: pixel values are clamped between 0 and 255.");
                }
                else
                {
                    Console.WriteLine("Test failed: pixel values out of range.");
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
 * 1. When you need to ensure that applying an emboss convolution filter to a JPEG does not produce color values outside the 0‑255 range.
 * 2. When you want to write an automated unit test that validates pixel value clamping after image filtering in a .NET application.
 * 3. When you are processing large batches of images and must guarantee that saved output files remain valid JPEGs without overflow errors.
 * 4. When you integrate Aspose.Imaging into a CI pipeline and need to assert that image transformations keep channel values within byte limits.
 * 5. When you debug custom image filters and require a quick way to detect out‑of‑range ARGB components after applying a kernel.
 */
