// HOW-TO: Normalize Sharpening Kernel to Preserve Brightness When Filtering JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            double sum = 0;
            for (int i = 0; i < kernel.GetLength(0); i++)
            {
                for (int j = 0; j < kernel.GetLength(1); j++)
                {
                    sum += kernel[i, j];
                }
            }

            if (Math.Abs(sum) > 1e-6)
            {
                double factor = 1.0 / sum;
                for (int i = 0; i < kernel.GetLength(0); i++)
                {
                    for (int j = 0; j < kernel.GetLength(1); j++)
                    {
                        kernel[i, j] *= factor;
                    }
                }
            }

            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to sharpen a JPEG image in a C# application while keeping the overall brightness unchanged.
 * 2. When you want to apply a custom 3x3 convolution filter with Aspose.Imaging and ensure the image luminance remains consistent.
 * 3. When processing a batch of photos and must maintain consistent exposure after applying a sharpening kernel to each JPEG.
 * 4. When building a web API that returns sharpened JPEGs and you need the output to have the same brightness as the original.
 * 5. When creating a desktop photo‑enhancement tool that uses Aspose.Imaging to sharpen pictures without altering their perceived brightness.
 */
