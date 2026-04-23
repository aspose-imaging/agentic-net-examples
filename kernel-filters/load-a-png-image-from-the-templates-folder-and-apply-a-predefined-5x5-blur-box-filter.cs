using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "templates/input.png";
        string outputPath = "output/filtered.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] blurKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(5);
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(blurKernel);

            raster.Filter(raster.Bounds, filterOptions);

            raster.Save(outputPath);
        }
    }
}