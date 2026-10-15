// HOW-TO: Measure Execution Time of Emboss vs Gaussian Blur on PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string embossOutputPath = "emboss.png";
            string blurOutputPath = "blur.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(embossOutputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(blurOutputPath) ?? ".");

            // Emboss filter benchmark
            using (RasterImage embossImage = (RasterImage)Image.Load(inputPath))
            {
                var embossOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                var swEmboss = System.Diagnostics.Stopwatch.StartNew();
                embossImage.Filter(embossImage.Bounds, embossOptions);
                swEmboss.Stop();

                var pngOptionsEmboss = new PngOptions
                {
                    Source = new FileCreateSource(embossOutputPath, false)
                };
                embossImage.Save(embossOutputPath, pngOptionsEmboss);
                Console.WriteLine($"Emboss filter time: {swEmboss.ElapsedMilliseconds} ms");
            }

            // Gaussian blur filter benchmark
            using (RasterImage blurImage = (RasterImage)Image.Load(inputPath))
            {
                var gaussianOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
                var swBlur = System.Diagnostics.Stopwatch.StartNew();
                blurImage.Filter(blurImage.Bounds, gaussianOptions);
                swBlur.Stop();

                var pngOptionsBlur = new PngOptions
                {
                    Source = new FileCreateSource(blurOutputPath, false)
                };
                blurImage.Save(blurOutputPath, pngOptionsBlur);
                Console.WriteLine($"Gaussian blur filter time: {swBlur.ElapsedMilliseconds} ms");
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
 * 1. When optimizing an image processing pipeline you need to compare how fast the Emboss3x3 filter runs against a Gaussian blur on PNG files using Aspose.Imaging in C#.
 * 2. When deciding which visual effect to apply in a real‑time photo editor you can benchmark the processing time of embossing versus blurring to ensure the UI remains responsive.
 * 3. When evaluating server‑side batch image transformations you may measure the execution cost of each filter to estimate CPU usage and scale resources accordingly.
 * 4. When creating automated tests for image‑filter performance you can use this code to record milliseconds taken for emboss and Gaussian blur on identical inputs.
 * 5. When documenting performance differences between convolution filters you can generate concrete timing data for PNG images to include in technical reports or blog posts.
 */
