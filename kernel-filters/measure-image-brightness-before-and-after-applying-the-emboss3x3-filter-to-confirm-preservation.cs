// HOW-TO: Measure Image Brightness Before and After Emboss Filter in C# (Aspose.Imaging for .NET)
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

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\embossed.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;
                if (!raster.IsCached)
                {
                    raster.CacheData();
                }

                Rectangle bounds = raster.Bounds;
                double sumBefore = 0;
                int totalPixels = bounds.Width * bounds.Height;

                for (int y = bounds.Y; y < bounds.Y + bounds.Height; y++)
                {
                    for (int x = bounds.X; x < bounds.X + bounds.Width; x++)
                    {
                        Color c = raster.GetPixel(x, y);
                        sumBefore += (c.R + c.G + c.B) / 3.0;
                    }
                }

                double brightnessBefore = sumBefore / totalPixels;

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                double sumAfter = 0;
                for (int y = bounds.Y; y < bounds.Y + bounds.Height; y++)
                {
                    for (int x = bounds.X; x < bounds.X + bounds.Width; x++)
                    {
                        Color c = raster.GetPixel(x, y);
                        sumAfter += (c.R + c.G + c.B) / 3.0;
                    }
                }

                double brightnessAfter = sumAfter / totalPixels;

                Console.WriteLine($"Brightness before: {brightnessBefore:F2}");
                Console.WriteLine($"Brightness after: {brightnessAfter:F2}");

                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to verify that applying an emboss convolution filter does not unintentionally darken or brighten a JPEG photo in a .NET application.
 * 2. When you want to log the average luminance of an image before and after processing to ensure consistent visual quality across PNG exports.
 * 3. When building an automated image‑processing pipeline that must compare pre‑ and post‑filter brightness to trigger alerts for out‑of‑range results.
 * 4. When creating a desktop tool that lets users preview the effect of the Emboss3x3 filter and see quantitative brightness changes in real time.
 * 5. When performing regression testing of Aspose.Imaging’s convolution filters to confirm that future library updates preserve overall image brightness.
 */
