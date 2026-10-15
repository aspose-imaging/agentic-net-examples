// HOW-TO: Apply Gaussian Blur to BMP and Save as PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/input.bmp";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
            {
                Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(0, 1.5);
                raster.Filter(raster.Bounds, blurOptions);

                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to soften the details of a BMP photograph before converting it to a PNG for a website, applying a Gaussian blur with sigma 1.5 using Aspose.Imaging in C#.
 * 2. When you are preparing legacy BMP assets for a mobile app and want to reduce visual noise by blurring them before saving as lossless PNG files.
 * 3. When an automated batch job must read BMP files, apply a mild Gaussian blur to meet a branding guideline, and output the results as PNG images using C#.
 * 4. When you want to create a preview thumbnail of a high‑resolution BMP where a slight blur improves readability, and you need to store the thumbnail as a PNG.
 * 5. When integrating image processing into a .NET service that receives BMP uploads, you apply a Gaussian blur filter to protect sensitive details and then save the sanitized image as PNG.
 */
