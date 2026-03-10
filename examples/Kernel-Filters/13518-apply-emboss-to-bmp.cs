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
        string inputPath = args.Length > 0 ? args[0] : "input.bmp";
        string outputPath = args.Length > 1 ? args[1] : "output_emboss.bmp";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply Emboss filter using convolution kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the result as BMP
            raster.Save(outputPath, new BmpOptions());
        }
    }
}