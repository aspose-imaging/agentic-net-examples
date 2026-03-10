using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input and output file paths
        string inputPath = args.Length > 0 ? args[0] : "input.webp";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the WebP image
        using (WebPImage webPImage = new WebPImage(inputPath))
        {
            // Apply Emboss filter using predefined kernel
            webPImage.Filter(webPImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the result as PNG
            webPImage.Save(outputPath, new PngOptions());
        }
    }
}