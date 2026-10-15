// HOW-TO: Remove Motion Blur from PNG and Sharpen Edges Using Aspose.Imaging C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new MotionWienerFilterOptions(5, 1.0, 0.5));
                raster.Filter(raster.Bounds, new SharpenFilterOptions());

                PngOptions options = new PngOptions();
                options.Source = new FileCreateSource(outputPath, false);
                raster.Save(outputPath, options);
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
 * 1. When a photo taken from a moving vehicle appears blurry, a developer can use this code to deblur the PNG and enhance its edges before displaying it in a web app.
 * 2. When processing scanned documents that were captured with camera shake, the Motion Wiener filter followed by sharpening restores readability of the PNG files in an automated batch workflow.
 * 3. When preparing product images for an e‑commerce site, the code removes motion blur caused by handheld shooting and sharpens details to meet catalog quality standards.
 * 4. When building a desktop application that restores old digital artwork saved as PNG, the filter sequence cleans up blur and improves edge definition for better visual fidelity.
 * 5. When integrating image cleanup into a C# microservice that receives user‑uploaded PNGs, the routine automatically reduces motion blur and applies sharpening before storing the files.
 */
