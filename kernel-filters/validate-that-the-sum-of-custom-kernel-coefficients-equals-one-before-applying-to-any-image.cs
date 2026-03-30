using System;
using System.IO;
using System.Linq;

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

        double[,] kernel = new double[,]
        {
            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
            { 1.0 / 9, 1.0 / 9, 1.0 / 9 },
            { 1.0 / 9, 1.0 / 9, 1.0 / 9 }
        };

        double sum = kernel.Cast<double>().Sum();
        if (Math.Abs(sum - 1.0) > 1e-6)
        {
            Console.Error.WriteLine("Kernel coefficients do not sum to 1.");
            return;
        }

        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            var raster = (Aspose.Imaging.RasterImage)image;
            raster.Filter(raster.Bounds, filterOptions);
            raster.Save(outputPath);
        }
    }
}