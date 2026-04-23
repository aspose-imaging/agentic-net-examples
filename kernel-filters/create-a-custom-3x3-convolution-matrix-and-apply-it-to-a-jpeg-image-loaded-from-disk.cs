using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        string inputPath = "input.jpg";
        string outputPath = "output\\output.jpg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

            raster.Filter(raster.Bounds, convOptions);

            raster.Save(outputPath);
        }
    }
}