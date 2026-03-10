using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_edge.png";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Define an edge detection kernel (Laplacian)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the convolution filter with the edge detection kernel
            rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(kernel));

            // Save the processed image as PNG
            PngOptions saveOptions = new PngOptions();
            image.Save(outputPath, saveOptions);
        }
    }
}