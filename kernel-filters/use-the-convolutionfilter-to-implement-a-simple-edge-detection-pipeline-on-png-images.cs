using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output\\output_edge.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image as a raster image
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Define a simple Laplacian edge detection kernel (3x3)
            double[,] kernel = new double[,]
            {
                { 0, -1,  0 },
                { -1, 4, -1 },
                { 0, -1,  0 }
            };

            // Create convolution filter options with the custom kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Apply the convolution filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as PNG
            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}