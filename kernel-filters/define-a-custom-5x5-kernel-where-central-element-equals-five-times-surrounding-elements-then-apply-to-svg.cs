// HOW-TO: Apply Custom 5x5 Convolution Kernel to SVG and Export PNG in C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        try
        {
            // Load SVG and rasterize to temporary PNG
            string tempPngPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");

            using (Image svgImg = Image.Load(inputPath))
            {
                SvgImage svgImage = svgImg as SvgImage;
                if (svgImage == null)
                {
                    Console.Error.WriteLine("Input file is not a valid SVG image.");
                    return;
                }

                PngOptions pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load rasterized image
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                RasterImage raster = rasterImg as RasterImage;
                if (raster == null)
                {
                    Console.Error.WriteLine("Failed to load raster image.");
                    return;
                }

                // Define custom 5x5 kernel (central element = 5 * surrounding)
                double[,] kernel = new double[5, 5];
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        kernel[i, j] = 1.0;
                    }
                }
                kernel[2, 2] = 5.0; // central element

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                raster.Save(outputPath);
            }

            // Clean up temporary file
            if (File.Exists("temp.png"))
            {
                File.Delete("temp.png");
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
 * 1. When you need to enhance or sharpen an SVG graphic by applying a custom convolution filter before converting it to a raster PNG file.
 * 2. When you want to programmatically rasterize an SVG to PNG and apply a weighted 5x5 kernel to emphasize central pixels for edge detection.
 * 3. When you must generate a PNG thumbnail from an SVG with a specific blur or sharpening effect defined by a custom matrix.
 * 4. When you are building a C# image‑processing pipeline that requires custom kernel convolution on vector images converted to raster format.
 * 5. When you need to automate batch processing of SVG files, applying a custom filter to improve visual contrast before saving them as PNGs.
 */
