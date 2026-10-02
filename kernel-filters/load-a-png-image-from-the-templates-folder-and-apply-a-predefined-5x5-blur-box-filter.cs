// HOW-TO: Apply 5x5 Box Blur to PNG Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "templates/input.png";
            string outputPath = "output/blurred.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            double[,] blurKernel = new double[,]
            {
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 },
                { 0.04, 0.04, 0.04, 0.04, 0.04 }
            };

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(blurKernel));
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to soften a product photo before uploading it to a web store, you can blur a PNG with a 5x5 box filter in C# using Aspose.Imaging.
 * 2. When generating thumbnail previews that require a subtle background blur to highlight foreground elements, this code applies a uniform blur to the PNG source.
 * 3. When preparing images for privacy compliance by obscuring details such as faces or license plates, the 5x5 convolution filter quickly blurs the PNG file.
 * 4. When creating a custom image processing pipeline that includes a Gaussian‑like blur step, you can replace it with a simple 5x5 box blur using Aspose.Imaging’s ConvolutionFilterOptions.
 * 5. When automating batch processing of PNG assets to achieve a consistent soft‑focus effect across a catalog, the sample demonstrates loading, filtering, and saving each image programmatically.
 */
