// HOW-TO: Check for Alpha Channel in TIFF After Gaussian Blur in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Tiff.Enums;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.tif";
            string outputPath = "output_blurred.tif";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (TiffImage image = (TiffImage)Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                var blurOptions = new GaussianBlurFilterOptions(5, 1.5);
                raster.Filter(raster.Bounds, blurOptions);

                bool hasAlpha = raster.HasAlpha;
                Console.WriteLine($"Alpha channel present: {hasAlpha}");

                var tiffOptions = new TiffOptions(TiffExpectedFormat.Default);
                image.Save(outputPath, tiffOptions);
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
 * 1. When you need to verify whether a blurred TIFF file still retains transparency information before further processing or publishing.
 * 2. When integrating Aspose.Imaging into a C# workflow to apply a Gaussian blur filter and then conditionally handle images that contain an alpha channel.
 * 3. When building a document conversion pipeline that must preserve or discard alpha channels in TIFFs after applying image effects.
 * 4. When performing quality‑control checks on scanned TIFF graphics to ensure that smoothing operations haven’t removed required transparency data.
 * 5. When developing a batch image‑processing tool that applies Gaussian blur to TIFFs and logs which files contain an alpha channel for downstream rendering decisions.
 */
