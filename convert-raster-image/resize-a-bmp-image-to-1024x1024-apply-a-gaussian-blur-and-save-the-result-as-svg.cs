// HOW-TO: Resize BMP to 1024x1024, Apply Gaussian Blur, Save as SVG in C# (Aspose.Imaging for .NET)
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
        string inputPath = "input.bmp";
        string outputPath = "output/result.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = image as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Loaded image is not a raster image.");
                    return;
                }

                raster.Resize(1024, 1024);
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                raster.Filter(raster.Bounds, blurOptions);
                SvgOptions svgOptions = new SvgOptions();
                raster.Save(outputPath, svgOptions);
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
 * 1. When you need to convert a high‑resolution BMP logo into a scalable SVG for web use while smoothing edges with a Gaussian blur.
 * 2. When preparing product images for responsive design, you resize the bitmap to a fixed 1024×1024 size, blur it to reduce noise, and output SVG for crisp scaling.
 * 3. When generating vector‑based thumbnails from legacy BMP files, applying a blur to create a soft‑focus effect before saving as SVG.
 * 4. When automating a batch process that transforms scanned BMP documents into lightweight SVG graphics with a uniform size and subtle blur for visual consistency.
 * 5. When integrating image preprocessing into a C# application that requires raster images to be resized, blurred, and exported as SVG for further vector editing.
 */
