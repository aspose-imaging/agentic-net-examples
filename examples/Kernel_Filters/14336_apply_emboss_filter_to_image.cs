using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class EmbossFilterExample
{
    static void Main()
    {
        // Input and output file paths
        string inputPath = "input.jpg";
        string outputPath = "output_emboss.png";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply the 3x3 Emboss kernel to the entire image
            rasterImage.Filter(
                rasterImage.Bounds,
                new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}