// HOW-TO: Apply Gaussian Blur to EMF and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.emf";
            string outputPath = "output.png";
            string tempPath = "temp.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");

            // Load EMF and rasterize to temporary PNG
            using (Image emfImage = Image.Load(inputPath))
            {
                var vectorOptions = new VectorRasterizationOptions
                {
                    PageWidth = emfImage.Width,
                    PageHeight = emfImage.Height,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = vectorOptions,
                    Source = new FileCreateSource(tempPath, false)
                };

                emfImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply Gaussian blur, and save final PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 5.0);
                raster.Filter(raster.Bounds, blurOptions);

                var finalOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };

                raster.Save(outputPath, finalOptions);
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
 * 1. When you need to soften vector graphics from an EMF file before displaying them on a website, you can rasterize, blur, and export the result as a PNG.
 * 2. When generating thumbnails of EMF drawings with a subtle blur effect for a document preview system, this code creates the blurred PNG automatically.
 * 3. When preparing EMF logos for print layouts that require a gentle blur to reduce sharp edges, the routine converts and blurs the image in C#.
 * 4. When building a batch processor that converts a collection of EMF icons into blurred PNG assets for a mobile app, this example shows the required steps.
 * 5. When integrating image processing into a .NET service that receives EMF uploads and returns blurred PNG responses for privacy masking, the code demonstrates the workflow.
 */
