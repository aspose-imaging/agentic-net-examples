// HOW-TO: How To Dither A TIFF, Apply Gaussian Blur And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = Path.Combine("Input", "input.tif");
            string outputPath = Path.Combine("Output", "output.png");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Dither the image
                raster.Dither(Aspose.Imaging.DitheringMethod.FloydSteinbergDithering, 8);

                // Apply Gaussian blur
                var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions();
                raster.Filter(raster.Bounds, blurOptions);

                // Save as PNG
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
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
 * 1. When you need to convert a high‑resolution TIFF scan into a web‑friendly PNG while preserving visual detail through Floyd‑Steinberg dithering and a soft Gaussian blur.
 * 2. When you want to prepare printed artwork for digital preview by reducing color depth, adding a blur effect, and exporting it as a PNG using Aspose.Imaging in a .NET application.
 * 3. When an automated image‑processing pipeline must batch‑process TIFF files, apply dithering to simulate limited palettes, smooth edges with Gaussian blur, and store the results as PNGs for downstream consumption.
 * 4. When you are building a C# utility that enhances legacy medical images (TIFF) with dithering for better contrast and a blur filter to reduce noise before saving them as PNG for web display.
 * 5. When you need to integrate image‑filtering steps—dithering and Gaussian blur—into a C# service that receives TIFF uploads and returns optimized PNG thumbnails.
 */
