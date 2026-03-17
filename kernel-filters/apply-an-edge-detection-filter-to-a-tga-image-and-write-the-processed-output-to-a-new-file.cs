using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.tga";
        string outputPath = args.Length > 1 ? args[1] : "output.tga";

        // Load the TGA image as a raster image
        using (RasterImage rasterImage = (RasterImage)Image.Load(inputPath))
        {
            // Define a simple edge detection kernel (Laplacian)
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Create convolution filter options with the custom kernel
            var convolutionOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel);

            // Apply the edge detection filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

            // Save the processed image as TGA
            rasterImage.Save(outputPath, new TgaOptions());
        }
    }
}