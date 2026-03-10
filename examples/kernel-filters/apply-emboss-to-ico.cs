using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = "input.ico";
        string outputPath = "output.ico";

        // Load the ICO image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply Emboss filter using predefined kernel
            rasterImage.Filter(rasterImage.Bounds,
                new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the result as ICO
            IcoOptions saveOptions = new IcoOptions();
            rasterImage.Save(outputPath, saveOptions);
        }
    }
}