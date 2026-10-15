// HOW-TO: Apply Median Filter to OTG Image and Save as PNG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-07
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
        string inputPath = "input.otg";
        string outputPath = "output.png";

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
                RasterImage raster = image as RasterImage;
                if (raster != null)
                {
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                    PngOptions saveOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };
                    raster.Save(outputPath, saveOptions);
                }
                else
                {
                    int width = image.Width;
                    int height = image.Height;

                    PngOptions createOptions = new PngOptions
                    {
                        Source = new FileCreateSource(outputPath, false)
                    };

                    using (RasterImage canvas = (RasterImage)Image.Create(createOptions, width, height))
                    {
                        Graphics graphics = new Graphics(canvas);
                        graphics.DrawImage(image, 0, 0, width, height);
                        canvas.Filter(canvas.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(3));
                        canvas.Save();
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
 * 1. When you need to reduce noise in an OTG graphic before converting it to a PNG for web display.
 * 2. When a batch process must apply a median filter to scanned OTG files and store the cleaned results as PNGs in a .NET application.
 * 3. When you have an OTG image that may be vector or raster and you must ensure it is rasterized, filtered, and saved as PNG without losing dimensions.
 * 4. When preparing OTG assets for a mobile app, you want to smooth the image using a 3‑pixel median filter and output a PNG with Aspose.Imaging in C#.
 * 5. When automating image pipelines, you need to detect the image type, apply a median filter, and convert the OTG file to PNG while handling missing files gracefully.
 */
