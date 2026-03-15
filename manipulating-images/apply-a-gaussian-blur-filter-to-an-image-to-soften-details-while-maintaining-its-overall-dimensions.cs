using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class GaussianBlurExample
{
    static void Main()
    {
        // Path to the folder containing the source image.
        string dataDir = @"c:\temp\";

        // Load the image from file. The Image.Load method is the required lifecycle entry point.
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Cast to RasterImage to gain access to the Filter method.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gaussian blur filter to the entire image.
            // Radius = 5, Sigma = 4.0 – these values control the blur strength.
            rasterImage.Filter(
                rasterImage.Bounds,
                new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image. The Save method follows the prescribed lifecycle rule.
            rasterImage.Save(dataDir + "sample.GaussianBlur.png");
        }
    }
}