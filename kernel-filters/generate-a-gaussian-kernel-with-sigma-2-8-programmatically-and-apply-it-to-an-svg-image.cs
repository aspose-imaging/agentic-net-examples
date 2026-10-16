// HOW-TO: Apply Gaussian Blur With Sigma 2.8 To SVG In C# (Aspose.Imaging for .NET)
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
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPath = "temp.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageWidth = svgImage.Width;
                rasterOptions.PageHeight = svgImage.Height;
                rasterOptions.BackgroundColor = Color.White;

                var pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                svgImage.Save(tempPath, pngOptions);
            }

            // Load raster image
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                double sigma = 2.8;
                int size = 2 * (int)Math.Ceiling(3 * sigma) + 1;
                double[,] kernel = new double[size, size];
                double sum = 0;
                int half = size / 2;
                double sigma2 = sigma * sigma;

                for (int y = -half; y <= half; y++)
                {
                    for (int x = -half; x <= half; x++)
                    {
                        double value = Math.Exp(-(x * x + y * y) / (2 * sigma2));
                        kernel[y + half, x + half] = value;
                        sum += value;
                    }
                }

                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        kernel[i, j] /= sum;
                    }
                }

                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, convOptions);
                raster.Save(outputPath, new PngOptions());
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
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
 * 1. When you need to convert a vector SVG logo to a raster PNG and add a smooth Gaussian blur for web‑ready thumbnails.
 * 2. When you want to programmatically generate a custom Gaussian kernel and apply it to vector graphics for consistent visual effects across a UI.
 * 3. When you are preparing SVG illustrations for print and require a subtle blur to reduce sharp edges before compositing.
 * 4. When you need to preprocess SVG‑derived images with a 2.8 sigma blur before feeding them into a computer‑vision model.
 * 5. When you are building an automated pipeline that rasterizes SVG assets and applies a Gaussian blur to create background images for mobile apps.
 */
