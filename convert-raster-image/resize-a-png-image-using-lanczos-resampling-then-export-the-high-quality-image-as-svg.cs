// HOW-TO: Resize PNG with Lanczos Resampling and Export as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "Input/input.png";
        string outputPath = "Output/resized.svg";

        try
        {
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

                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.LanczosResample);

                using (SvgOptions options = new SvgOptions())
                {
                    options.VectorRasterizationOptions = new SvgRasterizationOptions();
                    options.VectorRasterizationOptions.PageWidth = image.Width;
                    options.VectorRasterizationOptions.PageHeight = image.Height;

                    image.Save(outputPath, options);
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
 * 1. When you need to double the resolution of a PNG logo while preserving sharp edges and then embed it as a scalable SVG in a web page.
 * 2. When converting raster PNG assets to vector‑friendly SVG files for responsive UI designs without losing detail.
 * 3. When generating high‑quality printable graphics by upscaling PNG images with Lanczos resampling before saving them as SVG for lossless scaling.
 * 4. When automating a build pipeline that processes PNG icons, enlarges them, and outputs SVG files for use in multiple screen densities.
 * 5. When creating a C# tool that prepares PNG illustrations for vector editors by resizing them with high‑quality resampling and exporting to SVG format.
 */
