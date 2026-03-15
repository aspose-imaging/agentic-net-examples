using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Gif;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.gif";
        string outputPath = "output_edge_detected.gif";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to GifImage
            GifImage gifImage = (GifImage)image;

            // Define an edge detection kernel
            double[,] edgeKernel = new double[,]
            {
                { -1, -1, -1 },
                { -1,  8, -1 },
                { -1, -1, -1 }
            };

            // Apply the convolution filter with the edge detection kernel to the entire image
            gifImage.Filter(gifImage.Bounds, new ConvolutionFilterOptions(edgeKernel));

            // Save the processed image back as GIF
            gifImage.Save(outputPath, new GifOptions());
        }
    }
}