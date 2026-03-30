using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "template.png";
        string outputPath = "output/result.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG template as a raster image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define a custom 3x3 kernel (example sharpening kernel)
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Normalize kernel so that its sum equals 1
            double sum = 0;
            foreach (double v in kernel)
                sum += v;
            if (sum == 0) sum = 1; // avoid division by zero

            int rows = kernel.GetLength(0);
            int cols = kernel.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    kernel[i, j] /= sum;
                }
            }

            // Create convolution filter options with normalized kernel
            var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

            // Apply the convolution filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image as PNG
            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}