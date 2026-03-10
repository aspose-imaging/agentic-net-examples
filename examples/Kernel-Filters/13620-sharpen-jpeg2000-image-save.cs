using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Jpeg2000; // Namespace for JPEG2000 image types (if needed)

class SharpenJpeg2000Example
{
    static void Main()
    {
        // Path to the folder containing the source image
        string dataDir = @"c:\temp\";

        // Load the JPEG2000 image
        using (Image image = Image.Load(dataDir + "sample.jp2"))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a sharpen filter to the whole image.
            // Kernel size = 5, sigma = 4.0 (adjust as needed)
            rasterImage.Filter(
                rasterImage.Bounds,
                new SharpenFilterOptions(5, 4.0));

            // Save the processed image back as JPEG2000
            rasterImage.Save(dataDir + "sample.Sharpened.jp2");
        }
    }
}