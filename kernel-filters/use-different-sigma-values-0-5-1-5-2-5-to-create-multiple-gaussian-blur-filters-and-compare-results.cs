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
            string inputPath = @"C:\temp\sample.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Define sigma values to test
            double[] sigmaValues = { 0.5, 1.5, 2.5 };
            // Use a fixed odd kernel size (must be positive and odd)
            int kernelSize = 5;

            // Process each sigma value
            foreach (double sigma in sigmaValues)
            {
                // Construct output file path that includes sigma value in the name
                string outputPath = Path.Combine(
                    @"C:\temp\output",
                    $"sample.GaussianBlur_{sigma}.png");

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Load the image, apply Gaussian blur, and save the result
                using (Image image = Image.Load(inputPath))
                {
                    // Cast to RasterImage to access filtering capabilities
                    RasterImage rasterImage = (RasterImage)image;

                    // Apply Gaussian blur filter with specified size and sigma
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new GaussianBlurFilterOptions(kernelSize, sigma));

                    // Save the processed image
                    rasterImage.Save(outputPath);
                }

                Console.WriteLine($"Saved blurred image with sigma {sigma} to {outputPath}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}