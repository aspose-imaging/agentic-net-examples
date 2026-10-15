// HOW-TO: Apply Sharpen 5x5 Filter to PNG Image in C# with Aspose.Imaging (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-14
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "template.png";
            string outputPath = "Output\\sharpened.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (PngImage image = (PngImage)Aspose.Imaging.Image.Load(inputPath))
            {
                image.Filter(
                    image.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen5x5));

                PngOptions options = new PngOptions();
                image.Save(outputPath, options);
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
 * 1. When you need to enhance the sharpness of a PNG template before embedding it in a web page or PDF report.
 * 2. When you want to programmatically apply a 5x5 sharpening convolution to product photos stored as PNG files in a C# batch‑processing job.
 * 3. When you are building an image‑editing service that must improve edge definition of user‑uploaded PNG graphics without using external native libraries.
 * 4. When you need to process a PNG logo, sharpen its details, and save the result while automatically releasing memory resources in a .NET application.
 * 5. When you are creating automated marketing assets and require a quick way to apply a high‑frequency filter to PNG images using Aspose.Imaging in C#.
 */
