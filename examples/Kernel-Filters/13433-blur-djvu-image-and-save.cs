using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Path to the folder containing the DJVU file
        string dir = @"c:\temp\";

        // Load the DJVU image
        using (Image image = Image.Load(dir + "sample.djvu"))
        {
            // Cast the generic Image to DjvuImage to access DJVU‑specific methods
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a Gaussian blur filter to the whole image.
            // Radius = 5, Sigma = 4.0 (adjust as needed)
            djvuImage.Filter(
                djvuImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            djvuImage.Save(dir + "sample.Blur.png", new PngOptions());
        }
    }
}