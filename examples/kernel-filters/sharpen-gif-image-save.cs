using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class SharpenGifExample
{
    static void Main()
    {
        // Path to the folder containing the source GIF
        string dataDir = @"c:\temp\";

        // Load the GIF image
        using (Image image = Image.Load(dataDir + "input.gif"))
        {
            // Cast to GifImage to access GIF‑specific methods
            GifImage gifImage = (GifImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            gifImage.Filter(gifImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image. Here we save as PNG to preserve the result.
            gifImage.Save(dataDir + "output_sharpened.png", new PngOptions());
        }
    }
}