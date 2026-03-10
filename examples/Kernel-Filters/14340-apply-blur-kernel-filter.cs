using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output images
        string inputPath = "input.png";
        string outputGaussian = "output_gaussian.png";
        string outputBoxBlur = "output_boxblur.png";

        // Apply Gaussian blur filter
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            raster.Save(outputGaussian, new PngOptions());
        }

        // Apply box blur using a convolution kernel
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;
            double[,] kernel = ConvolutionFilter.GetBlurBox(5);
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
            raster.Save(outputBoxBlur, new PngOptions());
        }
    }
}