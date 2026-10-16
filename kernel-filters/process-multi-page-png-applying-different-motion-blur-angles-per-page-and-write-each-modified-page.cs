// HOW-TO: Apply Varying Motion Blur to Each Page of a Multi‑Page PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
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
            string inputPath = "input.png";
            string outputDirectory = "output_pages";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Image image = Image.Load(inputPath))
            {
                if (image is IMultipageImage multipageImage)
                {
                    for (int i = 0; i < multipageImage.PageCount; i++)
                    {
                        Image page = multipageImage.Pages[i];
                        if (page is RasterImage raster)
                        {
                            double angle = i * 30.0; // Different angle per page
                            double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(5, angle);
                            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                            raster.Filter(raster.Bounds, filterOptions);

                            string outputPath = Path.Combine(outputDirectory, $"page_{i}.png");
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                            var options = new PngOptions
                            {
                                Source = new FileCreateSource(outputPath, false)
                            };
                            raster.Save(outputPath, options);
                        }
                    }
                }
                else
                {
                    Console.Error.WriteLine("The loaded image is not a multi-page image.");
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
 * 1. When you need to add a different directional motion blur to every frame of a multi‑page PNG to create a dynamic visual effect.
 * 2. When preprocessing scanned document pages stored in a single PNG and want to simulate motion blur on each page to test OCR accuracy.
 * 3. When generating layered game assets where each PNG page represents a depth layer and requires a unique blur angle for realistic depth‑of‑field.
 * 4. When preparing a slide deck where each slide is a page in a multi‑page PNG and you want each slide saved as a separate PNG with its own motion‑blur style.
 * 5. When building an automated image‑processing pipeline that extracts each page of a multi‑page PNG, applies a custom blur filter, and saves the results as individual PNG files.
 */
