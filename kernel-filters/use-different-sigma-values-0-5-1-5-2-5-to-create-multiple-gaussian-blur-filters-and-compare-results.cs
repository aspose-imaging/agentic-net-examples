using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input image path
            string inputPath = @"c:\temp\sample.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Sigma values for the Gaussian blur filters
            double[] sigmaValues = { 0.5, 1.5, 2.5 };
            // Fixed kernel size (must be a positive odd integer)
            int kernelSize = 5;

            foreach (double sigma in sigmaValues)
            {
                // Load the image fresh for each iteration
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access the Filter method
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Gaussian blur with the current sigma
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new GaussianBlurFilterOptions(kernelSize, sigma));

                    // Construct output path that includes the sigma value
                    string outputPath = $@"c:\temp\sample.GaussianBlur_{sigma}.png";

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}