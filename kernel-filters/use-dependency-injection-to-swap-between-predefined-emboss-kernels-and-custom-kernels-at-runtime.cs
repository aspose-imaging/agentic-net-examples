using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

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

            // Choose kernel source: true for predefined emboss, false for custom kernel
            bool usePredefinedKernel = true;

            // Kernel provider delegate
            Func<double[,]> kernelProvider;

            if (usePredefinedKernel)
            {
                // Predefined emboss kernel (3x3)
                kernelProvider = () => ConvolutionFilter.Emboss3x3;
            }
            else
            {
                // Custom kernel example
                kernelProvider = () =>
                {
                    double[,] customKernel = new double[,]
                    {
                        { -2, -1, 0 },
                        { -1,  1, 1 },
                        {  0,  1, 2 }
                    };
                    return customKernel;
                };
            }

            // Load image, apply filter, and save
            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                double[,] kernel = kernelProvider();
                var filterOptions = new ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}