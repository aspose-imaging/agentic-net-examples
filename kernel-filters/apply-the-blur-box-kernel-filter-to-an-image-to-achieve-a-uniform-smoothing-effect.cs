using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output.jpg";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a uniform blur using a box kernel of size 5
            var blurKernel = ConvolutionFilter.GetBlurBox(5);
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(blurKernel));

            // Save the filtered image
            raster.Save(outputPath);
        }
    }
}