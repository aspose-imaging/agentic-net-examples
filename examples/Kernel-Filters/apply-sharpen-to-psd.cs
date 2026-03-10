using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class SharpenPsdExample
{
    static void Main()
    {
        // Define the folder containing the PSD file.
        string dataDir = @"c:\temp\";

        // Load the PSD image.
        using (Image image = Image.Load(dataDir + "sample.psd"))
        {
            // Cast to RasterImage to access filtering functionality.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the entire image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed).
            rasterImage.Filter(
                rasterImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the sharpened image back to PSD format.
            rasterImage.Save(dataDir + "sample.Sharpened.psd");
        }
    }
}