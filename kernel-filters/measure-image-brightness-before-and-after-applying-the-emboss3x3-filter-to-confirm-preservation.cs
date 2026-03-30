using System;
using System.IO;
using System.Linq;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output/output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            if (!raster.IsCached)
                raster.CacheData();

            int[] beforePixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
            double beforeBrightness = beforePixels.Average(p =>
            {
                int r = (p >> 16) & 0xFF;
                int g = (p >> 8) & 0xFF;
                int b = p & 0xFF;
                return (r + g + b) / 3.0;
            });

            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            int[] afterPixels = raster.GetDefaultArgb32Pixels(raster.Bounds);
            double afterBrightness = afterPixels.Average(p =>
            {
                int r = (p >> 16) & 0xFF;
                int g = (p >> 8) & 0xFF;
                int b = p & 0xFF;
                return (r + g + b) / 3.0;
            });

            Console.WriteLine($"Average brightness before filter: {beforeBrightness:F2}");
            Console.WriteLine($"Average brightness after filter: {afterBrightness:F2}");

            raster.Save(outputPath, new PngOptions());
        }
    }
}