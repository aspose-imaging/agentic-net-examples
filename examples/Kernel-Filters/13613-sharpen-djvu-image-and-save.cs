using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for input DJVU file and output PNG file
        string inputPath = @"c:\temp\sample.djvu";
        string outputPath = @"c:\temp\sample.Sharpened.png";

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access DJVU‑specific methods
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a sharpen filter to the whole image.
            // Parameters: kernel size = 5, sigma = 4.0
            djvuImage.Filter(djvuImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}