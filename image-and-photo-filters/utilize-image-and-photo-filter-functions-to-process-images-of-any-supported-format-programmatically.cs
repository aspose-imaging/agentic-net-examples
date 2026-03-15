using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> [outputImagePath]");
            return;
        }

        string inputPath = args[0];
        string outputPath = args.Length > 1 ? args[1] : System.IO.Path.ChangeExtension(inputPath, ".processed.png");

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            if (!raster.IsCached)
                raster.CacheData();

            raster.AdjustBrightness(30);
            raster.AdjustContrast(0.2f);
            raster.AdjustGamma(1.1f);

            var blurOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.0);
            raster.Filter(raster.Bounds, blurOptions);

            using (var pngOptions = new PngOptions())
            {
                image.Save(outputPath, pngOptions);
            }
        }

        Console.WriteLine($"Processed image saved to: {outputPath}");
    }
}