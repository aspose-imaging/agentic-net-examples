using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "C:\\Images\\input.png";
        string outputPath = "C:\\Images\\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define a custom 5x5 convolution kernel
        double[,] kernel = new double[5, 5]
        {
            { 0, 0, 1, 0, 0 },
            { 0, 1, 2, 1, 0 },
            { 1, 2, 4, 2, 1 },
            { 0, 1, 2, 1, 0 },
            { 0, 0, 1, 0, 0 }
        };

        // Load the image, apply the custom filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
            raster.Save(outputPath);
        }
    }
}