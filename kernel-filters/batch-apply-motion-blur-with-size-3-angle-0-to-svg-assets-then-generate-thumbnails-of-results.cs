// HOW-TO: Batch Apply Motion Blur to SVGs and Create Thumbnails in C# (Aspose.Imaging for .NET)
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
            string inputDirectory = "Input";
            string outputDirectory = "Output";

            Directory.CreateDirectory(outputDirectory);

            string[] svgFiles = Directory.GetFiles(inputDirectory, "*.svg");
            foreach (string svgPath in svgFiles)
            {
                if (!File.Exists(svgPath))
                {
                    Console.Error.WriteLine($"File not found: {svgPath}");
                    continue;
                }

                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(svgPath);
                string tempPngPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_temp.png");
                string blurredPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_blurred.png");
                string thumbPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_thumb.png");

                // Rasterize SVG to temporary PNG
                using (Image svgImage = Image.Load(svgPath))
                {
                    var pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = new SvgRasterizationOptions()
                    };
                    Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
                    svgImage.Save(tempPngPath, pngOptions);
                }

                // Load raster image, apply motion blur, save blurred image
                using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
                {
                    double[,] kernel = ConvolutionFilter.GetBlurMotion(3, 0);
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    Directory.CreateDirectory(Path.GetDirectoryName(blurredPath));
                    raster.Save(blurredPath);
                }

                // Load blurred image to create thumbnail
                using (RasterImage thumb = (RasterImage)Image.Load(blurredPath))
                {
                    int thumbWidth = 150;
                    int thumbHeight = (int)(thumb.Height * (thumbWidth / (double)thumb.Width));
                    thumb.Resize(thumbWidth, thumbHeight);
                    Directory.CreateDirectory(Path.GetDirectoryName(thumbPath));
                    thumb.Save(thumbPath);
                }

                // Clean up temporary file
                if (File.Exists(tempPngPath))
                {
                    File.Delete(tempPngPath);
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
 * 1. When you need to batch‑process a collection of SVG icons, add a subtle motion‑blur effect and generate small PNG thumbnails for faster loading in a web UI.
 * 2. When preparing marketing assets, you can automatically rasterize vector illustrations, apply a size‑3, 0‑degree motion blur, and output preview images for client review.
 * 3. When building a digital asset management system, this code creates blurred preview versions and thumbnail snapshots of SVG files to help users browse large libraries quickly.
 * 4. When developing a game UI, you can convert SVG sprites to PNG, apply motion blur for a dynamic look, and produce thumbnail versions for in‑engine asset catalogs.
 * 5. When automating a CI pipeline for design files, the script ensures every SVG is rasterized, blurred, and saved as a thumbnail so designers can see the visual impact without opening the original vector file.
 */
