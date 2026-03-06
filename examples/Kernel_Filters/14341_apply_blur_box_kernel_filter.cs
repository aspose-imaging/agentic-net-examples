using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create a box blur kernel of size 5
            double[,] kernel = ConvolutionFilter.GetBlurBox(5);
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Apply the blur box filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the result as PNG
            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}