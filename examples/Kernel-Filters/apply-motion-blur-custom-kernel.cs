using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_motion_blur.png";

        // Load the image and cast to RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Create a custom motion blur kernel (size = 15, angle = 45 degrees)
            double[,] kernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurMotion(15, 45.0);

            // Apply the motion blur filter using the custom kernel
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            // Save the result as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}