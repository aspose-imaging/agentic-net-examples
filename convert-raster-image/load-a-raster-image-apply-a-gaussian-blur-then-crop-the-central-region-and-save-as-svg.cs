// HOW-TO: Apply Gaussian Blur, Crop Center, and Save PNG as SVG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-08
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                if (!image.IsCached)
                    image.CacheData();

                var blurOptions = new GaussianBlurFilterOptions(5, 1.0);
                image.Filter(image.Bounds, blurOptions);

                int cropWidth = image.Width / 2;
                int cropHeight = image.Height / 2;
                int x = (image.Width - cropWidth) / 2;
                int y = (image.Height - cropHeight) / 2;
                var cropRect = new Rectangle(x, y, cropWidth, cropHeight);
                image.Crop(cropRect);

                var svgOptions = new SvgOptions();
                image.Save(outputPath, svgOptions);
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
 * 1. When you need to soften a raster image with a Gaussian blur before converting it to a scalable vector format for web graphics.
 * 2. When you want to extract the central portion of a high‑resolution PNG and output it as an SVG for responsive UI components.
 * 3. When you are building an automated pipeline that caches image data, applies a blur filter, crops, and saves the result as SVG for printing or laser cutting.
 * 4. When you must ensure the output SVG retains only the most important area of a photograph after applying a blur effect for privacy or artistic purposes.
 * 5. When you are developing a C# utility that prepares raster assets by blurring and cropping them before embedding the SVG into a PDF or HTML report.
 */
