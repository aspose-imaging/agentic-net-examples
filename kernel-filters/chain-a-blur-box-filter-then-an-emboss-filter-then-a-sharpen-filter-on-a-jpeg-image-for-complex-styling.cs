// HOW-TO: Apply Blur Box, Emboss, and Sharpen Filters to JPEG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\styled.jpg";

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
                double[,] blurKernel = ConvolutionFilter.GetBlurBox(5);
                image.Filter(image.Bounds, new ConvolutionFilterOptions(blurKernel));

                double[,] embossKernel = ConvolutionFilter.Emboss3x3;
                image.Filter(image.Bounds, new ConvolutionFilterOptions(embossKernel));

                image.Filter(image.Bounds, new SharpenFilterOptions());

                var jpegOptions = new JpegOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                image.Save(outputPath, jpegOptions);
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
 * 1. When you need to soften a photo, add a textured emboss effect, and then enhance edges before saving as a JPEG for web galleries.
 * 2. When creating stylized product thumbnails that require a subtle blur, a 3‑D emboss look, and sharpened details to attract customers.
 * 3. When preprocessing scanned documents to reduce noise, give a raised‑text appearance, and improve readability in a compressed JPEG.
 * 4. When generating artistic filters for a mobile app that combines smoothing, embossing, and sharpening in a single processing step.
 * 5. When automating batch image processing to apply multiple convolution filters sequentially for consistent visual branding across marketing assets.
 */
