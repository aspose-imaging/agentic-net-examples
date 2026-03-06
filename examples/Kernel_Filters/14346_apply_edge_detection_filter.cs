using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string sharpenedPath = "output_sharpen.png";
        string embossedPath = "output_emboss.png";

        // Apply Sharpen filter (edge detection)
        using (Image image = Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            // SharpenFilterOptions(kernelSize, sigma)
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));
            raster.Save(sharpenedPath);
        }

        // Apply Emboss filter using a convolution kernel
        using (Image image = Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage raster = (Aspose.Imaging.RasterImage)image;
            // Retrieve the 3x3 emboss kernel
            double[,] embossKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3;
            // Create convolution filter options with the kernel
            var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(embossKernel);
            raster.Filter(raster.Bounds, convOptions);
            raster.Save(embossedPath);
        }
    }
}