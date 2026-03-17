using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input DNG file and output PNG file paths
        string inputPath = "input.dng";
        string outputPath = "output.png";

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Define an edge detection kernel (Laplacian)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the convolution filter with the edge detection kernel
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            // Save the processed image as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}