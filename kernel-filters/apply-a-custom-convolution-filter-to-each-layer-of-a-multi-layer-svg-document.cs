// HOW-TO: Apply Custom Convolution Filter to SVG Layers and Save as PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string tempPngPath = "temp.png";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions();
                svgImage.Save(tempPngPath, pngOptions);
            }

            using (Image img = Image.Load(tempPngPath))
            {
                RasterImage raster = (RasterImage)img;

                double[,] kernel = new double[,]
                {
                    { 0, -1, 0 },
                    { -1, 5, -1 },
                    { 0, -1, 0 }
                };
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                raster.Filter(raster.Bounds, convOptions);
                raster.Save(outputPath);
            }

            if (File.Exists(tempPngPath))
            {
                File.Delete(tempPngPath);
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
 * 1. When you need to sharpen each layer of a multi‑layer SVG before converting it to a high‑quality PNG for web publishing.
 * 2. When you want to programmatically apply a custom kernel (e.g., edge‑enhancement) to SVG graphics in a C# batch‑processing pipeline.
 * 3. When you must rasterize vector artwork, apply image processing filters, and generate PNG thumbnails for a content‑management system.
 * 4. When you are building an automated workflow that converts SVG icons to sharpened PNG assets for mobile app resources.
 * 5. When you require a temporary raster conversion step to use Aspose.Imaging’s convolution filter on vector files without manual editing.
 */
