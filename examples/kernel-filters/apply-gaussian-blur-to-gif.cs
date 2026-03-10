using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths to the source GIF and the output file
        string inputPath = @"c:\temp\sample.gif";
        string outputPath = @"c:\temp\sample.GaussianBlur.gif";

        // Load the GIF image
        using (Image image = Image.Load(inputPath))
        {
            GifImage gifImage = (GifImage)image;

            // Apply Gaussian blur filter to the whole image (kernel size 5, sigma 4.0)
            gifImage.Filter(gifImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the result as a GIF
            gifImage.Save(outputPath, new GifOptions());
        }
    }
}