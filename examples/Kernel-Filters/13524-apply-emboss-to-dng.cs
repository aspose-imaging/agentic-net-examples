using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output paths
        string dir = "c:\\temp\\";
        string inputPath = Path.Combine(dir, "input.dng");
        string outputPath = Path.Combine(dir, "output.png");

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply emboss filter using a predefined convolution kernel
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

            // Save the filtered image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}