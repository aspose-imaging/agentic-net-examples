using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Define a custom 7x7 kernel
        double[,] kernel = new double[7, 7]
        {
            { 0, 0, -1, -1, -1, 0, 0 },
            { 0, -1, -3, -3, -3, -1, 0 },
            { -1, -3, 0, 7, 0, -3, -1 },
            { -1, -3, 7, 24, 7, -3, -1 },
            { -1, -3, 0, 7, 0, -3, -1 },
            { 0, -1, -3, -3, -3, -1, 0 },
            { 0, 0, -1, -1, -1, 0, 0 }
        };

        // Validate kernel dimensions (must be odd)
        if (kernel.GetLength(0) % 2 == 0 || kernel.GetLength(1) % 2 == 0)
        {
            Console.Error.WriteLine("Kernel dimensions must be odd.");
            return;
        }

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply the custom convolution filter
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the result as PNG
            PngOptions saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}