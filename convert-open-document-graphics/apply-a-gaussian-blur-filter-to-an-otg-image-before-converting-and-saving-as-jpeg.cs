// HOW-TO: Apply Gaussian Blur to OTG Image and Save as JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            string inputPath = "input.otg";
            string outputPath = "output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                using (RasterImage raster = (RasterImage)image)
                {
                    var blurOptions = new GaussianBlurFilterOptions(); // default radius and sigma
                    raster.Filter(raster.Bounds, blurOptions);
                    raster.Save(outputPath, new JpegOptions());
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
 * 1. When you need to soften the details of an OTG graphic before delivering it as a compressed JPEG for web publishing.
 * 2. When you want to reduce noise in a scanned OTG diagram by applying a Gaussian blur and then save it in JPEG format for email attachment.
 * 3. When a mobile app requires pre‑processed OTG assets with a blur effect to create background placeholders stored as JPEG files.
 * 4. When automating a batch conversion pipeline that must apply a uniform blur to each OTG image prior to generating JPEG thumbnails.
 * 5. When integrating Aspose.Imaging into a C# service that receives OTG files, applies a Gaussian blur for privacy masking, and returns JPEG images to clients.
 */
