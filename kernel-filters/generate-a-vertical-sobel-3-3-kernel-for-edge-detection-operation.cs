using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/input.png";
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputPath = "output/output.png";
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        double[,] sobelKernel = new double[,]
        {
            { -1, 0, 1 },
            { -2, 0, 2 },
            { -1, 0, 1 }
        };

        double factor = 1.0;
        int bias = 0;

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(sobelKernel, factor, bias);
            raster.Filter(raster.Bounds, options);
            raster.Save(outputPath);
        }
    }
}