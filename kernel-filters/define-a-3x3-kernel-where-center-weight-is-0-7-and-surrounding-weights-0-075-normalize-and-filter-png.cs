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
        string inputPath = "input.png";
        string outputPath = "output\\filtered.png";

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

            // Define a 3x3 kernel with center weight 0.7 and surrounding weights 0.075
            double[,] kernel = new double[3, 3];
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    kernel[y, x] = 0.075;
                }
            }
            kernel[1, 1] = 0.7; // center

            // Normalize the kernel so that the sum of all weights equals 1
            double sum = 0;
            foreach (double v in kernel) sum += v;
            for (int y = 0; y < 3; y++)
            {
                for (int x = 0; x < 3; x++)
                {
                    kernel[y, x] /= sum;
                }
            }

            // Apply the custom convolution filter to the entire image
            var filterOptions = new ConvolutionFilterOptions(kernel);
            raster.Filter(raster.Bounds, filterOptions);

            // Save the filtered image as PNG
            var saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}