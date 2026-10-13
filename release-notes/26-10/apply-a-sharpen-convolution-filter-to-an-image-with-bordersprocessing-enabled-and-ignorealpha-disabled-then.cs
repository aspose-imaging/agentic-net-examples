// HOW-TO: Apply Sharpen Convolution Filter with Borders Processing and No Alpha Ignoring in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
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
            string inputPath = "input\\image.jpg";
            string outputPath = "output\\sharpened.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel)
                {
                    BordersProcessing = true,
                    IgnoreAlpha = false
                };

                image.Filter(image.Bounds, filterOptions);

                var jpegOptions = new JpegOptions();
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to enhance edge details of a JPEG photo while preserving the image borders and keeping the alpha channel intact.
 * 2. When preparing product images for an e‑commerce site and you want a sharper look without losing transparent background information.
 * 3. When processing scanned documents to improve readability and you must keep the original image dimensions unchanged.
 * 4. When creating thumbnails for a gallery and you require a consistent sharpening effect across all images, including edge pixels.
 * 5. When automating batch image enhancement in a C# application and you need to control border handling and ensure the alpha channel is not ignored.
 */
