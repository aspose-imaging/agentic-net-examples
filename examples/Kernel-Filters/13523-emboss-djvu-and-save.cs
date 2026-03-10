using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Djvu;

class Program
{
    static void Main(string[] args)
    {
        // Input DJVU file path
        string inputPath = "sample.djvu";
        // Output PNG file path
        string outputPath = "sample.emboss.png";

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access DJVU-specific methods
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply Emboss filter using the predefined Emboss3x3 kernel
            djvuImage.Filter(djvuImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the filtered image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}