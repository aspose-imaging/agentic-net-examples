using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create convolution filter options using the Emboss 3x3 kernel
            ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the filtered image
            raster.Save(outputPath);
        }
    }
}