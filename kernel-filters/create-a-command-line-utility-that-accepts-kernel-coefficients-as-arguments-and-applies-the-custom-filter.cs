using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output\\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Parse kernel coefficients from command‑line arguments
            double[] flatKernel = args.Select(a => double.Parse(a)).ToArray();

            // Determine kernel size (must be a positive odd integer)
            int size = (int)Math.Sqrt(flatKernel.Length);
            if (size * size != flatKernel.Length || size % 2 == 0)
            {
                Console.Error.WriteLine("Kernel must be a square matrix with an odd dimension.");
                return;
            }

            // Convert flat kernel to 2D array
            double[,] kernel = new double[size, size];
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    kernel[i, j] = flatKernel[i * size + j];
                }
            }

            // Load the image and apply the custom convolution filter
            using (Image image = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)image;

                // Create convolution filter options (factor=1.0, bias=0)
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);

                // Apply filter to the entire image bounds
                raster.Filter(raster.Bounds, filterOptions);

                // Save the processed image as PNG
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}