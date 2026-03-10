using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class ApplyMotionWienerFilterToWmf
{
    static void Main()
    {
        // Define input and output paths
        string dir = @"C:\temp\";
        string wmfPath = System.IO.Path.Combine(dir, "sample.wmf");
        string intermediatePng = System.IO.Path.Combine(dir, "sample_intermediate.png");
        string resultPng = System.IO.Path.Combine(dir, "sample.MotionWienerFilter.png");

        // Load the WMF image and rasterize it to PNG (vector -> raster conversion)
        using (Image wmfImage = Image.Load(wmfPath))
        {
            // Save as PNG using default rasterization options
            wmfImage.Save(intermediatePng, new PngOptions());
        }

        // Load the rasterized PNG image
        using (Image rasterImage = Image.Load(intermediatePng))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)rasterImage;

            // Apply a motion Wiener filter (used here as a motion blur effect)
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the filtered image
            raster.Save(resultPng);
        }
    }
}