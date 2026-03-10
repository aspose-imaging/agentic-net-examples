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
        string inputPath = "input.tga";
        string outputPath = "output_embossed.tga";

        // Load the TGA image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Apply the Emboss filter using the predefined kernel
            image.Filter(image.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image as TGA
            image.Save(outputPath, new TgaOptions());
        }
    }
}