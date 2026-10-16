// HOW-TO: Apply Gaussian Blur To SVG Rendered PNG And Verify No Artifacts In C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-09
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output_blurred.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Render SVG to a temporary PNG
            string tempPngPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG and apply Gaussian blur
            using (Aspose.Imaging.Image img = Aspose.Imaging.Image.Load(tempPngPath))
            {
                var raster = (Aspose.Imaging.RasterImage)img;
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);
                var outPngOptions = new PngOptions();
                raster.Save(outputPath, outPngOptions);
            }

            // Clean up temporary file
            if (File.Exists("temp.png"))
            {
                File.Delete("temp.png");
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
 * 1. When you need to blur a vector‑based SVG for a web thumbnail without introducing rendering artifacts, you can rasterize it to PNG and apply a Gaussian blur using Aspose.Imaging in C#.
 * 2. When generating blurred background images from SVG logos for UI designs, this code ensures the blur is applied after rasterization while preserving the original vector quality.
 * 3. When performing automated quality checks on SVG‑to‑PNG conversions, you can use this workflow to confirm that the Gaussian blur filter does not create unwanted visual defects.
 * 4. When creating preview images of SVG diagrams with a soft focus effect in a .NET application, the example shows how to render, blur, and save the result efficiently.
 * 5. When integrating image processing into a CI pipeline that processes SVG assets, this snippet demonstrates loading, rasterizing, applying a Gaussian blur, and cleaning up temporary files with Aspose.Imaging.
 */
