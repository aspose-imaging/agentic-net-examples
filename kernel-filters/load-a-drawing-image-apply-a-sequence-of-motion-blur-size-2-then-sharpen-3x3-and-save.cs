// HOW-TO: Apply Motion Blur Then Sharpen PNG Image In C# With Aspose.Imaging (Aspose.Imaging for .NET)
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
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurMotion(2, 0)));
                image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Sharpen3x3));

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
 * 1. When you need to soften a PNG graphic with a subtle motion blur before enhancing its edges for a web banner.
 * 2. When preparing scanned line‑art for printing and you want to reduce jagged lines by blurring then sharpening the image.
 * 3. When creating a visual effect for a game asset where a slight motion blur followed by a crisp sharpen gives a dynamic look.
 * 4. When processing a batch of PNG screenshots to smooth noise and then sharpen details automatically in a C# application.
 * 5. When integrating Aspose.Imaging into a C# service that must adjust PNG images by applying motion blur and a 3×3 sharpen filter before storage.
 */
