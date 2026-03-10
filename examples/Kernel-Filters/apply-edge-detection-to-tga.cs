using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
            // Define a simple edge detection kernel (Laplacian)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the custom kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Apply the edge detection filter to the entire image
            image.Filter(image.Bounds, filterOptions);

            // Save the processed image as TGA
            image.Save(outputPath, new TgaOptions());
        }
    }
}