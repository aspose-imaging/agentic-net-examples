using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_edge.jpg";

        // Load the image and cast to RasterImage
        using (Image image = Image.Load(inputPath))
        {
            Aspose.Imaging.RasterImage rasterImage = (Aspose.Imaging.RasterImage)image;

            // Define a simple edge detection kernel (3x3)
            double[,] kernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the convolution filter with the custom kernel to the whole image
            rasterImage.Filter(rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}