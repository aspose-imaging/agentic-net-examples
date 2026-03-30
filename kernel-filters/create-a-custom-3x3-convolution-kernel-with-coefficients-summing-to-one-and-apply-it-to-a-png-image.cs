using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Custom 3x3 convolution kernel (coefficients sum to 1)
            double[,] kernel = new double[,]
            {
                { 0.111, 0.111, 0.111 },
                { 0.111, 0.111, 0.111 },
                { 0.111, 0.111, 0.111 }
            };

            // Create filter options with the custom kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Apply the convolution filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Prepare PNG save options
            PngOptions saveOptions = new PngOptions
            {
                Source = new FileCreateSource(outputPath, false)
            };

            // Save the processed image
            raster.Save(outputPath, saveOptions);
        }
    }
}