using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

public class Program
{
    public static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Define a custom 3x3 sharpening kernel
            double[,] kernel = new double[,]
            {
                { 0, -1, 0 },
                { -1, 5, -1 },
                { 0, -1, 0 }
            };

            // Apply the convolution filter with the custom kernel to the whole image
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            // Save the filtered image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}