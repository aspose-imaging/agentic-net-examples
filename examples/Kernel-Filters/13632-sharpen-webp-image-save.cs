using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class SharpenWebpExample
{
    static void Main()
    {
        // Path to the folder containing the source WEBP image.
        string dir = @"c:\temp\";

        // Load the WEBP image from file.
        using (WebPImage webpImage = new WebPImage(dir + "input.webp"))
        {
            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (as used in the documentation example).
            webpImage.Filter(webpImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG.
            webpImage.Save(dir + "output.png", new PngOptions());
        }
    }
}