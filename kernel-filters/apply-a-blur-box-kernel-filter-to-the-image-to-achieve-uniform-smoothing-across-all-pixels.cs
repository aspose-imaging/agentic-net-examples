using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Expect input and output file paths as arguments
        if (args.Length < 2)
        {
            Console.WriteLine("Usage: <program> <inputImagePath> <outputImagePath>");
            return;
        }

        string inputPath = args[0];
        string outputPath = args[1];

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Define blur box kernel size (odd positive integer)
            int kernelSize = 5;

            // Obtain the blur box kernel matrix
            double[,] kernel = ConvolutionFilter.GetBlurBox(kernelSize);

            // Create filter options with the kernel
            var filterOptions = new ConvolutionFilterOptions(kernel);

            // Apply the blur box filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}