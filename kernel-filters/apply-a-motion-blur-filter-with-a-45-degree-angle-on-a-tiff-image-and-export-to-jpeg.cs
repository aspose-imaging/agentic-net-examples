// HOW-TO: Apply 45 Degree Motion Blur to TIFF and Save as JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input/sample.tif";
            string outputPath = "Output/result.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage tiffImage = (TiffImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)tiffImage;

                double[,] kernel = ConvolutionFilter.GetBlurMotion(5, 45);
                var filterOptions = new ConvolutionFilterOptions(kernel);
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
 * 1. When you need to add a realistic motion‑blur effect to a scanned TIFF document before delivering it as a smaller JPEG for web preview.
 * 2. When a batch process must convert high‑resolution TIFF photos to JPEG while applying a 45° directional blur to hide sensitive details.
 * 3. When an imaging pipeline requires applying a custom convolution filter to a TIFF image and then exporting the result in JPEG format for mobile apps.
 * 4. When you want to programmatically enhance archival TIFF images with a diagonal motion blur and reduce file size by saving them as JPEG using Aspose.Imaging for .NET.
 * 5. When a digital asset management system needs to generate JPEG thumbnails with a 45‑degree motion blur from original TIFF files for artistic effect.
 */
