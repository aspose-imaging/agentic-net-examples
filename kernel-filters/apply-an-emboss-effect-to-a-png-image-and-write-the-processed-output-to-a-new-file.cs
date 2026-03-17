using System;
using System.IO;
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
        string inputPath = args.Length > 0 ? args[0] : "input.png";
        string outputPath = args.Length > 1 ? args[1] : "output_emboss.png";

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply emboss effect using the predefined 3x3 emboss kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image as PNG
            PngOptions saveOptions = new PngOptions();
            raster.Save(outputPath, saveOptions);
        }
    }
}