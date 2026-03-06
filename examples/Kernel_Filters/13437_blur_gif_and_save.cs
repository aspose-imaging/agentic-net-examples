using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class BlurGifExample
{
    static void Main()
    {
        // Directory containing the source GIF
        string dir = @"c:\temp\";

        // Load the GIF image
        using (Image image = Image.Load(dir + "sample.gif"))
        {
            // Cast to GifImage to access GIF-specific methods
            GifImage gifImage = (GifImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            gifImage.Filter(
                gifImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred result (as PNG to preserve quality)
            gifImage.Save(dir + "sample.Blurred.png", new PngOptions());
        }
    }
}