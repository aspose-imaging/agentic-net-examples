using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input and output WebP files
        string inputPath = "input.webp";
        string outputPath = "output_sharpened.webp";

        // Load the WebP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to WebPImage to access WebP-specific methods
            WebPImage webpImage = (WebPImage)image;

            // Apply a sharpen filter to the entire image
            // Kernel size = 5, Sigma = 4.0
            webpImage.Filter(
                webpImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as a new WebP file
            webpImage.Save(outputPath, new WebPOptions());
        }
    }
}