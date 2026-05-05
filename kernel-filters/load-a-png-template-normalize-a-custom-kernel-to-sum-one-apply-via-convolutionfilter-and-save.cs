using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/template.png";
            string outputPath = "output/result.png";

            // Validate input file existence
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

                // Define a custom 3x3 kernel (e.g., Gaussian blur kernel)
                double[,] kernel = new double[,]
                {
                    { 1, 2, 1 },
                    { 2, 4, 2 },
                    { 1, 2, 1 }
                };

                // Normalize kernel so that its sum equals 1
                double sum = 0;
                for (int y = 0; y < kernel.GetLength(0); y++)
                {
                    for (int x = 0; x < kernel.GetLength(1); x++)
                    {
                        sum += kernel[y, x];
                    }
                }
                for (int y = 0; y < kernel.GetLength(0); y++)
                {
                    for (int x = 0; x < kernel.GetLength(1); x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                // Create convolution filter options (factor = 1.0, bias = 0)
                var filterOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply the convolution filter to the entire image
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}