using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"c:\temp\";
        string inputPath = Path.Combine(dir, "sample.djvu");
        string outputPath = Path.Combine(dir, "sample.GaussianBlur.png");

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access DJVU‑specific methods
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply Gaussian blur filter to the whole image (radius 5, sigma 4.0)
            djvuImage.Filter(djvuImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}