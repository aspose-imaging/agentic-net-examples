using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
            { -1, -1, -1 },
            { -1,  9, -1 },
            { -1, -1, -1 }
        };

        double sum = 0;
        foreach (double value in kernel)
        {
            sum += value;
        }

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            if (sum > 1)
            {
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
            }
            else
            {
                Console.WriteLine("Kernel sum does not exceed 1; filter not applied.");
            }

            PngOptions options = new PngOptions();
            raster.Save(outputPath, options);
        }
    }
}