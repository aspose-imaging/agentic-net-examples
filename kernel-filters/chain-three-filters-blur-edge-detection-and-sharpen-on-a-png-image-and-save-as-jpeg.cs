// HOW-TO: Apply Gaussian Blur, Edge Detection, and Sharpen to PNG and Save as JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "Input\\image.png";
            string outputPath = "Output\\result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Blur filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions());

                // Edge detection filter using custom kernel
                double[,] edgeKernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  8, -1 },
                    { -1, -1, -1 }
                };
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

                // Sharpen filter
                raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                using (JpegOptions jpegOptions = new JpegOptions())
                {
                    jpegOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to preprocess a PNG photo by smoothing, highlighting edges, and enhancing details before converting it to a JPEG for web publishing.
 * 2. When building an automated image pipeline that applies multiple filters sequentially to improve visual quality of scanned documents before compression.
 * 3. When creating thumbnails that require both noise reduction and edge emphasis to make small JPEG previews clearer.
 * 4. When developing a batch conversion tool that standardizes images by applying blur, edge detection, and sharpening before saving them in a smaller JPEG format.
 * 5. When preparing product images for an e‑commerce site, using a blur to reduce background distraction, edge detection to outline items, and sharpening to make the final JPEG look crisp.
 */
