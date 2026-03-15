using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.ImageOptions;

class EmbossExample
{
    static void Main()
    {
        // Path to the source image
        string inputPath = "input.jpg";

        // Path where the embossed image will be saved
        string outputPath = "output_emboss.png";

        // Load the image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply the 3x3 emboss kernel to the entire image
            rasterImage.Filter(
                rasterImage.Bounds,
                new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the processed image using Aspose.Imaging's save rule
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}