using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source WebP image
        string dir = @"c:\temp\";

        // Load the WebP image from file
        using (Image image = Image.Load(dir + "sample.webp"))
        {
            // Cast to WebPImage to access the Filter method
            WebPImage webpImage = (WebPImage)image;

            // Apply a Gaussian blur filter to the entire image
            // Radius = 5, Sigma = 4.0 (modify as needed)
            webpImage.Filter(webpImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the filtered image back to WebP format
            webpImage.Save(dir + "sample.GaussianBlur.webp", new WebPOptions());
        }
    }
}