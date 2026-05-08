using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = Path.Combine("templates", "input.png");
            string outputPath = Path.Combine("output", "blurred.png");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (PngImage pngImage = new PngImage(inputPath))
            {
                // Cast to RasterImage to apply filters
                RasterImage rasterImage = (RasterImage)pngImage;

                // Create a 5x5 box blur kernel (all values = 1/25)
                double[,] kernel = new double[5, 5];
                for (int y = 0; y < 5; y++)
                {
                    for (int x = 0; x < 5; x++)
                    {
                        kernel[y, x] = 1.0 / 25.0;
                    }
                }

                // Apply the convolution filter to the whole image
                var blurOptions = new ConvolutionFilterOptions(kernel);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the processed image
                pngImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}