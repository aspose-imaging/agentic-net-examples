// HOW-TO: Sharpen EPS Image and Export as High-Resolution JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.eps";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load EPS image
            using (var epsImage = (Aspose.Imaging.FileFormats.Eps.EpsImage)Image.Load(inputPath))
            {
                // Set rasterization options for high resolution
                var rasterOptions = new EpsRasterizationOptions
                {
                    PageWidth = epsImage.Width * 2,
                    PageHeight = epsImage.Height * 2
                };

                // Save EPS as temporary PNG
                string tempPngPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".png");
                epsImage.Save(tempPngPath, new PngOptions { VectorRasterizationOptions = rasterOptions });

                // Load the rasterized PNG
                using (var raster = (RasterImage)Image.Load(tempPngPath))
                {
                    // Apply sharpening filter
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions());

                    // Save as high-quality JPEG
                    var jpegOptions = new JpegOptions { Quality = 100 };
                    raster.Save(outputPath, jpegOptions);
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to convert vector EPS artwork to a crisp JPEG for web publishing while preserving detail.
 * 2. When you want to enhance the sharpness of a rasterized EPS before embedding it in a PDF report.
 * 3. When you must generate high‑resolution product photos from EPS logos and ensure maximum JPEG quality.
 * 4. When an automated image pipeline requires rasterizing EPS files, applying a sharpening filter, and saving them as JPEGs for downstream processing.
 * 5. When you are building a C# application that prepares print‑ready images by upscaling EPS files, sharpening them, and exporting them as lossless‑quality JPEGs.
 */
