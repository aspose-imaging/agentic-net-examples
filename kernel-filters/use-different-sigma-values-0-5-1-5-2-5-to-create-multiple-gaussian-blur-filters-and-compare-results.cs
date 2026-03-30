using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input image path
        string inputPath = @"c:\temp\sample.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Define sigma values to test
        double[] sigmaValues = { 0.5, 1.5, 2.5 };
        // Kernel size (must be odd and positive)
        int kernelSize = 5;

        // Process each sigma value
        foreach (double sigma in sigmaValues)
        {
            // Construct output file path
            string outputPath = $@"c:\temp\sample.GaussianBlur_{sigma}.png";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access Filter method
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with specified size and sigma
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(kernelSize, sigma)
                );

                // Save the processed image
                rasterImage.Save(outputPath);
            }

            Console.WriteLine($"Saved blurred image with sigma {sigma} to {outputPath}");
        }
    }
}