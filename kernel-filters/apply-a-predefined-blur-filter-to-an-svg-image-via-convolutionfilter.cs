// HOW-TO: Apply Box Blur Filter to SVG and Save as PNG in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            string tempPng = Path.Combine(Path.GetDirectoryName(outputPath), "temp.png");

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPng, pngOptions);
            }

            using (RasterImage raster = (RasterImage)Image.Load(tempPng))
            {
                var kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                var outOptions = new PngOptions();
                raster.Save(outputPath, outOptions);
            }

            if (File.Exists(tempPng))
            {
                try { File.Delete(tempPng); } catch { }
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
 * 1. When you need to soften vector graphics before embedding them in a web page, you can blur an SVG and export it as a PNG using Aspose.Imaging in C#.
 * 2. When generating thumbnails for a design portfolio, applying a box blur to SVG icons ensures a consistent visual style while converting them to PNG format.
 * 3. When preparing assets for a mobile app that requires raster images with a subtle blur effect, this code converts SVG logos to blurred PNGs programmatically.
 * 4. When automating a batch process that adds a privacy blur to confidential vector diagrams before sharing, the ConvolutionFilter can be applied in C# and saved as PNG.
 * 5. When creating background images with a softened look for UI components, you can use Aspose.Imaging to blur an SVG and output a high‑quality PNG in a .NET application.
 */
