using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

static class ConvolutionWrapper
{
    public static readonly double[,] EmbossKernel = new double[,]
    {
        { 0, -1, 0 },
        { -1, 5, -1 },
        { 0, -1, 0 }
    };
}

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.png";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            var options = new ConvolutionFilterOptions(ConvolutionWrapper.EmbossKernel);
            raster.Filter(raster.Bounds, options);

            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}