using System;
using System.IO;

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

        // Load the image and apply motion blur filter
        using (Aspose.Imaging.Image image = Aspose.Imaging.Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;

            // Define motion blur parameters
            int size = 15;          // kernel size (must be odd)
            double angle = 45.0;    // blur angle in degrees

            // Create convolution filter options with motion blur kernel
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(size, angle));

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}