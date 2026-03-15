using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class EdgeDetectionExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = @"C:\temp\input.png";
        // Path to save the processed image
        string outputPath = @"C:\temp\output_edge.png";

        // Load the image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Define a 3x3 edge detection (Laplacian) kernel
            // Kernel layout (row‑major order):
            // -1  -1  -1
            // -1   8  -1
            // -1  -1  -1
            double[] edgeKernel = new double[]
            {
                -1, -1, -1,
                -1,  8, -1,
                -1, -1, -1
            };

            // Factor is typically 1.0 for edge detection; bias can be 0
            double factor = 1.0;
            int bias = 0;

            // Create convolution filter options with the custom kernel
            var convolutionOptions = new ConvolutionFilterOptions(edgeKernel, factor, bias);

            // Apply the filter to the whole image bounds
            rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

            // Save the result (preserving original format or converting to PNG)
            rasterImage.Save(outputPath, new Aspose.Imaging.ImageOptions.PngOptions());
        }
    }
}