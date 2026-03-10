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
        string outputPath = "output_blurbox.png";

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define the size of the box blur kernel (must be a positive odd integer)
            int kernelSize = 5;

            // Obtain the box blur kernel matrix
            double[,] kernel = ConvolutionFilter.GetBlurBox(kernelSize);

            // Create filter options using the kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Apply the box blur filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the filtered image as PNG
            var pngOptions = new PngOptions();
            raster.Save(outputPath, pngOptions);
        }
    }
}