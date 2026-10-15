// HOW-TO: Apply 10 Pixel Motion Blur to BMP and Save as JPEG in C# (Aspose.Imaging for .NET)
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
            string inputPath = "input.bmp";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Image img = Image.Load(inputPath))
            {
                if (img is RasterImage raster)
                {
                    var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(10, 0);
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    var jpegOptions = new JpegOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, jpegOptions);
                }
                else
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
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
 * 1. When you need to add a subtle motion effect to a scanned BMP before delivering it as a compressed JPEG for web publishing.
 * 2. When converting legacy BMP assets to JPEG while applying a 10‑pixel motion blur to reduce sharp edges for a smoother visual transition.
 * 3. When preprocessing product photos stored as BMP to simulate camera movement and then saving them as JPEG for e‑commerce catalogs.
 * 4. When automating batch processing of BMP files to apply a consistent motion blur filter and output JPEGs for mobile app thumbnails.
 * 5. When preparing BMP screenshots for email attachments, applying motion blur to hide sensitive details and converting them to JPEG to keep file size low.
 */
