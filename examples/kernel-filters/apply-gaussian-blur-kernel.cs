using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Directory containing the source image
        string dataDir = @"c:\temp\";

        // Load the image from file
        using (Image image = Image.Load(dataDir + "sample.png"))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            rasterImage.Save(dataDir + "sample.GaussianBlur.png");
        }
    }
}