// HOW-TO: Apply Gaussian Blur to BMP Image in C# with Aspose.Imaging (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.bmp";
        string outputPath = "output\\output.bmp";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, blurOptions);

                BmpOptions bmpOptions = new BmpOptions();
                image.Save(outputPath, bmpOptions);
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
 * 1. When you need to soften the background of a BMP mockup for a UI design, you can use this code to apply a Gaussian blur quickly.
 * 2. When generating low‑resolution preview thumbnails of BMP assets, applying a blur can reduce visual noise before scaling.
 * 3. When preparing BMP images for print layouts that require a subtle background effect, the Gaussian blur filter creates a smooth backdrop.
 * 4. When automating batch processing of BMP files to create blurred placeholders for lazy‑loading web pages, this snippet handles each image efficiently.
 * 5. When integrating image editing into a C# desktop application, you can use the code to let users apply a Gaussian blur to their BMP photos for creative effects.
 */
