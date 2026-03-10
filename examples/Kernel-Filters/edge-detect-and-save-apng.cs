using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output.apng";

        // Load the source image as a raster image
        using (RasterImage raster = (RasterImage)Image.Load(inputPath))
        {
            // Define a simple Laplacian edge detection kernel
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the convolution filter using the edge detection kernel
            raster.Filter(
                raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(edgeKernel));

            // Save the processed image as an Animated PNG (APNG)
            raster.Save(outputPath, new ApngOptions());
        }
    }
}