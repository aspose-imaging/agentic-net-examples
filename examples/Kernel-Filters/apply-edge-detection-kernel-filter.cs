using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_edge.png";

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage rasterImage = (RasterImage)image;

            // Define a custom edge detection kernel (3x3)
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the custom kernel
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);

            // Apply the filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}