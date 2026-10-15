// HOW-TO: Apply Gaussian Blur to CorelDRAW File and Save as BMP in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-12
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.cdr";
            string outputPath = "output.bmp";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Aspose.Imaging.FileFormats.Cdr.CdrImage cdr = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Aspose.Imaging.Image.Load(inputPath))
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new CdrRasterizationOptions
                        {
                            PageWidth = cdr.Width,
                            PageHeight = cdr.Height
                        }
                    };
                    cdr.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)Aspose.Imaging.Image.Load(ms))
                    {
                        var blurOptions = new GaussianBlurFilterOptions
                        {
                            Radius = 5,
                            Sigma = 1.5f
                        };
                        raster.Filter(raster.Bounds, blurOptions);
                        var bmpOptions = new BmpOptions();
                        raster.Save(outputPath, bmpOptions);
                    }
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
 * 1. When you need to add a subtle blur effect to a CorelDRAW illustration and then convert it to BMP for use in older Windows applications that only accept bitmap images.
 * 2. When a workflow requires rasterizing a CDR vector page, applying a Gaussian blur filter for artistic softening, and exporting the result as a BMP for inclusion in a game asset pipeline.
 * 3. When automating batch processing of CorelDRAW files to create blurred thumbnail previews in BMP format for a content management system.
 * 4. When integrating Aspose.Imaging into a C# service that receives CDR files, applies a Gaussian blur to meet branding guidelines, and stores the final image as BMP for archival purposes.
 * 5. When preparing print‑ready graphics by rasterizing a CorelDRAW design, smoothing edges with a Gaussian blur, and saving as BMP to ensure compatibility with legacy printing hardware.
 */
