// HOW-TO: Align Image DPI and Apply Median Filter in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

namespace ImagingNet
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputPath = "input.jpg";
                string outputPath = "output/output.jpg";

                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }

                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                using (RasterImage image = (RasterImage)Image.Load(inputPath))
                {
                    double hDpi = image.HorizontalResolution;
                    double vDpi = image.VerticalResolution;
                    double alignedDpi = Math.Max(hDpi, vDpi);
                    image.HorizontalResolution = alignedDpi;
                    image.VerticalResolution = alignedDpi;

                    image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));

                    JpegOptions saveOptions = new JpegOptions();
                    image.Save(outputPath, saveOptions);
                }
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When preparing scanned documents for printing, a developer can align the horizontal and vertical DPI and apply a median filter to remove noise before saving as a JPEG.
 * 2. When normalizing images from different cameras, a developer can set a common DPI value to ensure consistent scaling across the dataset.
 * 3. When preprocessing photos for a web gallery, a developer can equalize DPI and denoise the image to improve visual quality while keeping file size low.
 * 4. When converting legacy raster images to a standardized format, a developer can synchronize DPI and apply a median filter to preserve detail before exporting to JPEG.
 * 5. When building an automated image pipeline that applies correction filters, a developer can first align DPI to avoid distortion and then use a median filter for noise reduction.
 */
