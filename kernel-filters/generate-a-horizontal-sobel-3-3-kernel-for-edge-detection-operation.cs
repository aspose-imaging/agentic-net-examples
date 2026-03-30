using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Horizontal Sobel 3x3 kernel
            double[] sobelHorizontal = new double[]
            {
                -1, 0, 1,
                -2, 0, 2,
                -1, 0, 1
            };

            // Create convolution filter options (factor = 1.0, bias = 0)
            var filterOptions = new ConvolutionFilterOptions(sobelHorizontal, 1.0, 0);

            // Apply the convolution filter
            image.Filter(filterOptions);

            // Save the processed image
            image.Save(outputPath);
        }
    }
}