using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Dng;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths to the source DNG file and the destination PNG file
        string inputPath = @"c:\temp\sample.dng";
        string outputPath = @"c:\temp\sample.GaussianBlur.png";

        // Load the DNG image
        using (Image image = Image.Load(inputPath))
        {
            DngImage dngImage = (DngImage)image;

            // Apply Gaussian blur filter to the whole image (radius = 5, sigma = 4.0)
            dngImage.Filter(dngImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            dngImage.Save(outputPath, new PngOptions());
        }
    }
}