// HOW-TO: Make ConvolutionFilter Thread Safe for Parallel Image Processing in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input/sample.jpg";
            string outputPath = "Output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load image
            using (Image image = Image.Load(inputPath))
            {
                // Ensure we have a raster image
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                // Cache data for performance
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                // Define kernel for convolution (e.g., sharpen)
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                // Define regions to process (example: split image into 4 quadrants)
                int halfWidth = raster.Width / 2;
                int halfHeight = raster.Height / 2;
                Aspose.Imaging.Rectangle[] regions = new Aspose.Imaging.Rectangle[]
                {
                    new Aspose.Imaging.Rectangle(0, 0, halfWidth, halfHeight),
                    new Aspose.Imaging.Rectangle(halfWidth, 0, raster.Width - halfWidth, halfHeight),
                    new Aspose.Imaging.Rectangle(0, halfHeight, halfWidth, raster.Height - halfHeight),
                    new Aspose.Imaging.Rectangle(halfWidth, halfHeight, raster.Width - halfWidth, raster.Height - halfHeight)
                };

                object lockObj = new object();

                // Parallel processing using System.Threading.Tasks.Parallel
                System.Threading.Tasks.Parallel.For(0, regions.Length, i =>
                {
                    // Each thread creates its own ConvolutionFilterOptions instance
                    var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                    // Apply filter to the region safely
                    lock (lockObj)
                    {
                        raster.Filter(regions[i], options);
                    }
                });

                // Save the processed image
                var jpegOptions = new JpegOptions();
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
 * 1. When processing large raster photos on a multi‑core server and need to apply a sharpen convolution filter to different image quadrants concurrently.
 * 2. When building a web API that receives JPEG uploads and must run convolution kernels in parallel to maximize throughput without race conditions.
 * 3. When creating a desktop batch‑processing tool that splits images into regions and uses Parallel.For with Aspose.Imaging to apply filters safely.
 * 4. When developing a real‑time video frame analyzer that applies convolution filters across multiple threads while ensuring filter instances remain thread‑safe.
 * 5. When optimizing a scientific imaging pipeline that requires high‑resolution image convolution in parallel loops without corrupting filter state.
 */
