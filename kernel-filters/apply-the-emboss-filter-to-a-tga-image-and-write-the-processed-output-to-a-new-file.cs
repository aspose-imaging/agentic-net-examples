using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output TGA file paths
        string inputPath = "input.tga";
        string outputPath = "output.tga";

        // Load the TGA image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Apply the emboss filter using the predefined 3x3 kernel
            image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image as TGA with default options
            image.Save(outputPath, new TgaOptions());
        }
    }
}