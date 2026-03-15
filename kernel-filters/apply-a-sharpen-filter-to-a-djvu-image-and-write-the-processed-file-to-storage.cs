using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input DJVU file and output processed image path
        string inputPath = @"c:\temp\sample.djvu";
        string outputPath = @"c:\temp\sample.Sharpened.png";

        // Load the DJVU image using Aspose.Imaging's load rule
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access DJVU-specific functionality
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a sharpen filter to the entire image.
            // Example parameters: radius = 5, sigma = 4.0
            djvuImage.Filter(djvuImage.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the processed image using Aspose.Imaging's save rule
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}