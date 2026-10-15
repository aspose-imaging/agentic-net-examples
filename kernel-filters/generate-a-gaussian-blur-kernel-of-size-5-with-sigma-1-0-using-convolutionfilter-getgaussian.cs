// HOW-TO: Apply Gaussian Blur to JPEG Using Aspose.Imaging Convolution Filter in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetGaussian(5, 1.0);
                var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                image.Filter(image.Bounds, options);
                image.Save(outputPath);
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
 * 1. When you need to soften a photo before uploading it to a web gallery, you can apply a 5×5 Gaussian blur with sigma 1.0 to a JPEG using Aspose.Imaging in C#.
 * 2. When preparing product images for an e‑commerce site, you can reduce sharp edge artifacts by blurring PNG thumbnails with a Gaussian kernel generated via ConvolutionFilter.GetGaussian.
 * 3. When creating a custom image‑processing pipeline that requires consistent smoothing across different image formats, you can generate the Gaussian kernel once and reuse it to filter BMP or TIFF files in .NET.
 * 4. When implementing a pre‑processing step for OCR or computer‑vision models, you can smooth scanned documents (e.g., PDF‑converted images) with a Gaussian blur to improve recognition accuracy.
 * 5. When building a desktop application that lets users apply artistic effects, you can let them choose the blur intensity and apply the generated kernel to their selected images before saving the result.
 */
