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
        string outputPath = "output_emboss.png";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Obtain the 3x3 emboss kernel
            double[,] embossKernel = ConvolutionFilter.Emboss3x3;

            // Apply the emboss filter to the entire image
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(embossKernel));

            // Save the result as PNG
            raster.Save(outputPath, new PngOptions());
        }
    }
}