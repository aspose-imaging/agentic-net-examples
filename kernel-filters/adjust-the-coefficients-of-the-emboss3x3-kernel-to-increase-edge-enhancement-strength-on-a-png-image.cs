using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image as a RasterImage
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Retrieve the default Emboss3x3 kernel (2D array)
                double[,] originalKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;

                // Increase edge enhancement strength by scaling the kernel
                double strengthFactor = 1.5; // adjust as needed
                int rows = originalKernel.GetLength(0);
                int cols = originalKernel.GetLength(1);
                double[,] enhancedKernel = new double[rows, cols];
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        enhancedKernel[i, j] = originalKernel[i, j] * strengthFactor;
                    }
                }

                // Apply the custom convolution filter
                var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(enhancedKernel);
                raster.Filter(raster.Bounds, convOptions);

                // Save the processed image as PNG
                var pngOptions = new PngOptions
                {
                    Source = new FileCreateSource(outputPath, false)
                };
                raster.Save(outputPath, pngOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}