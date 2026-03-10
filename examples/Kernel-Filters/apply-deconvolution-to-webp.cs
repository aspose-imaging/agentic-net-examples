using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Webp;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WebP file and output PNG file paths
        string inputFile = Path.Combine("c:", "temp", "sample.webp");
        string outputFile = Path.Combine("c:", "temp", "sample.deconvolution.png");

        // Load the WebP image
        using (Image image = Image.Load(inputFile))
        {
            WebPImage webpImage = (WebPImage)image;

            // Apply a Gauss-Wiener deconvolution filter to the entire image
            webpImage.Filter(webpImage.Bounds, new GaussWienerFilterOptions(5, 4.0));

            // Save the filtered image as PNG
            webpImage.Save(outputFile, new PngOptions());
        }
    }
}