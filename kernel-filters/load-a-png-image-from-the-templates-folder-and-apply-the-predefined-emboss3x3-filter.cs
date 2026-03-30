using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "templates/input.png";
        string outputPath = "output/embossed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Get the 3x3 emboss kernel
            double[,] embossKernel = ConvolutionFilter.Emboss3x3;

            // Create convolution filter options with the emboss kernel
            var filterOptions = new ConvolutionFilterOptions(embossKernel);

            // Apply the emboss filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}