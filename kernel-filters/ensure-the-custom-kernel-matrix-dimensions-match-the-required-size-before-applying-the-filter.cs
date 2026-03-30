using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
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

        // Load the image as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Define a custom 3x3 kernel (sharpen example)
            double[,] customKernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Validate kernel dimensions (must be square and odd-sized)
            int rows = customKernel.GetLength(0);
            int cols = customKernel.GetLength(1);
            if (rows != cols || rows % 2 == 0)
            {
                Console.Error.WriteLine("Kernel must be square with an odd size.");
                return;
            }

            // Create convolution filter options
            var options = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(customKernel);

            // Apply the filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, options);

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}