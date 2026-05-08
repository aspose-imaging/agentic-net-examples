using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.png";
            string outputPath = "output/output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a raster image
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Generate a Gaussian kernel programmatically (size 5, sigma 1.2)
                int size = 5; // must be odd
                double sigma = 1.2;
                double[,] kernel = new double[size, size];
                double sum = 0.0;
                int half = size / 2;
                double twoSigmaSq = 2 * sigma * sigma;

                for (int y = -half; y <= half; y++)
                {
                    for (int x = -half; x <= half; x++)
                    {
                        double exponent = -(x * x + y * y) / twoSigmaSq;
                        double value = Math.Exp(exponent);
                        kernel[y + half, x + half] = value;
                        sum += value;
                    }
                }

                // Normalize the kernel so that the sum of all elements equals 1
                for (int y = 0; y < size; y++)
                {
                    for (int x = 0; x < size; x++)
                    {
                        kernel[y, x] /= sum;
                    }
                }

                // Apply the custom Gaussian kernel using ConvolutionFilterOptions
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);

                // Save the filtered image as PNG
                var saveOptions = new PngOptions();
                raster.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}