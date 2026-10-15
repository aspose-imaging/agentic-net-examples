// HOW-TO: Apply Motion Blur to SVG and Save as High Quality JPEG in C# (Aspose.Imaging for .NET)
// ── Machine-verified example ──────────────────────────────────────────────
// Compiler-verified: built with `dotnet build` — 0 errors.
// Run-tested: executed with `dotnet run` on net9.0 — exit code 0, no unhandled exceptions.
// Exception handling: try/catch present in this example.
// Package: Aspose.Imaging 26.10.0 | Verified: 2026-10-13
// Generated and validated by an agentic workflow, not hand-written.
// ─────────────────────────────────────────────────────────────────────────────
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Jpeg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output/output.jpg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster;

                if (image is VectorImage vector)
                {
                    using (var ms = new MemoryStream())
                    {
                        var pngOptions = new PngOptions();
                        vector.Save(ms, pngOptions);
                        ms.Position = 0;
                        raster = (RasterImage)Image.Load(ms);
                    }
                }
                else
                {
                    raster = (RasterImage)image;
                }

                using (raster)
                {
                    double[,] motionKernel = new double[,]
                    {
                        { 0.25, 0,   0,   0,   0    },
                        { 0,    0.2, 0,   0,   0    },
                        { 0,    0,   0.1, 0,   0    },
                        { 0,    0,   0,   0.2, 0    },
                        { 0,    0,   0,    0,  0.25 },
                    };

                    var filterOptions = new ConvolutionFilterOptions(motionKernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    var jpegOptions = new JpegOptions
                    {
                        Quality = 100
                    };

                    raster.Save(outputPath, jpegOptions);
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
 * 1. When you need to add a realistic motion‑blur effect to a logo stored as an SVG before publishing it on a website as a high‑quality JPEG.
 * 2. When an e‑commerce platform wants to generate blurred product thumbnails from vector artwork while keeping JPEG compression at maximum quality.
 * 3. When a desktop publishing tool must convert user‑provided SVG illustrations into raster images with a motion‑blur filter for print‑ready JPEG output.
 * 4. When a marketing automation script processes SVG banners, applies a directional blur, and saves them as 100‑quality JPEGs for email campaigns.
 * 5. When a game asset pipeline requires turning vector icons into blurred JPEG textures without losing detail, using Aspose.Imaging in C#.
 */
