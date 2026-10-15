// HOW-TO: Remove Motion Blur from PNG and Save as TIFF Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;
using Aspose.Imaging.FileFormats.Tiff.Enums;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\input.png";
            string outputPath = "Output\\output.tiff";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                int size = 5;
                double angle = 45.0;
                var motionKernel = ConvolutionFilter.GetBlurMotion(size, angle);
                var deconvOptions = new DeconvolutionFilterOptions(motionKernel);
                raster.Filter(raster.Bounds, deconvOptions);

                using (TiffOptions tiffOptions = new TiffOptions(TiffExpectedFormat.Default))
                {
                    tiffOptions.Source = new FileCreateSource(outputPath, false);
                    raster.Save(outputPath, tiffOptions);
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
 * 1. When you need to restore a blurred PNG captured by a moving camera and store the corrected image in a lossless TIFF for archival.
 * 2. When processing scanned documents that suffered motion blur, you can apply a deconvolution filter in C# to improve readability before converting to TIFF for printing.
 * 3. When building an automated image‑processing pipeline that receives PNG assets with motion blur, you can clean them up and output TIFF files for downstream GIS or CAD systems.
 * 4. When a web service receives user‑uploaded PNG photos with motion blur, you can programmatically deblur them and save as TIFF to meet client‑specified format requirements.
 * 5. When preparing high‑resolution PNG screenshots for medical or scientific analysis, you can remove motion blur and convert to TIFF to preserve pixel data for further analysis.
 */
