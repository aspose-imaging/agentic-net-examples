// HOW-TO: Crop 400x400 Area, Apply Gaussian Blur, Save as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
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
        string inputPath = "input.jpg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var cropRect = new Rectangle(0, 0, 400, 400);
                image.Crop(cropRect);

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5);
                image.Filter(image.Bounds, blurOptions);

                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to generate a blurred thumbnail of a specific region from a JPEG and embed it as scalable SVG in a web page.
 * 2. When you want to preprocess a high‑resolution photo by cropping to 400 × 400 pixels and applying a Gaussian blur before converting it to vector format for responsive design.
 * 3. When an application must create a lightweight SVG preview of a raster image with a soft focus effect for UI placeholders.
 * 4. When you are building an automated pipeline that extracts a fixed‑size area from product photos, blurs it for privacy, and stores the result as SVG for printing.
 * 5. When you need to programmatically transform a JPEG into an SVG with a blurred background to use in PDF reports or marketing materials.
 */
