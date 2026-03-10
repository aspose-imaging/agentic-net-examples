using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <exe> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply a 3x3 emboss filter to the entire image
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}