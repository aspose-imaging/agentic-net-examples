// HOW-TO: Resize PNG with Bicubic Interpolation, Sharpen, and Save as SVG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Resize using bicubic interpolation (CatmullRom)
                int newWidth = image.Width * 2;
                int newHeight = image.Height * 2;
                image.Resize(newWidth, newHeight, ResizeType.CatmullRom);

                // Apply sharpening filter
                RasterImage raster = (RasterImage)image;
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save as SVG
                image.Save(outputPath, new SvgOptions());
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
 * 1. When you need to double the resolution of a PNG logo, enhance its edges, and embed it as a scalable SVG in a web application.
 * 2. When converting high‑detail PNG screenshots to SVG for responsive UI designs while preserving sharpness through bicubic scaling and sharpening.
 * 3. When preparing print‑ready graphics by enlarging PNG artwork, applying a sharpening filter, and exporting to SVG for vector‑based layout tools.
 * 4. When optimizing PNG icons for retina displays, scaling them with Catmull‑Rom interpolation, sharpening, and saving as SVG to reduce file size.
 * 5. When automating a batch process that upscales PNG textures, improves clarity, and stores the results in SVG format for use in game development pipelines.
 */
