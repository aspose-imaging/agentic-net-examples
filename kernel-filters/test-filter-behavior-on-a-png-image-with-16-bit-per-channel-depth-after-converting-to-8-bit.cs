// HOW-TO: Apply Gaussian Blur to 8‑Bit PNG Converted from 16‑Bit in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "Input\\test16bit.png";
            string tempPath = "Output\\temp8bit.png";
            string outputPath = "Output\\filtered.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Convert 16-bit PNG to 8-bit PNG
            using (Image original = Image.Load(inputPath))
            {
                using (var pngOptions = new PngOptions
                {
                    BitDepth = 8,
                    Source = new FileCreateSource(tempPath, false)
                })
                {
                    original.Save(tempPath, pngOptions);
                }
            }

            // Apply Gaussian blur filter to the 8-bit image
            using (RasterImage raster = (RasterImage)Image.Load(tempPath))
            {
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 1.0));

                using (var outOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                })
                {
                    raster.Save(outputPath, outOptions);
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
 * 1. When you need to verify that image filters work correctly on 8‑bit PNGs that were originally 16‑bit, such as for quality‑control pipelines.
 * 2. When converting high‑depth medical or scientific PNG images to standard 8‑bit for web display and then applying a blur effect.
 * 3. When preprocessing large 16‑bit PNG assets for a game engine that only supports 8‑bit textures and requires smoothing.
 * 4. When creating thumbnails of high‑dynamic‑range PNGs and need to reduce bit depth before applying a Gaussian blur to reduce noise.
 * 5. When automating batch processing to downsample color depth and apply a blur filter for privacy‑preserving image sharing.
 */
