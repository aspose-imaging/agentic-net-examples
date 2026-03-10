using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Wmf;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Paths for the source WMZ image, an intermediate raster image, and the final output.
        string sourceWmz = @"C:\Images\sample.wmz";
        string intermediatePng = @"C:\Images\intermediate.png";
        string resultPng = @"C:\Images\sample.MotionWiener.png";

        // Load the compressed WMZ (WMF) image.
        using (Image image = Image.Load(sourceWmz))
        {
            // Cast to WmfImage to access vector rasterization options.
            WmfImage wmfImage = (WmfImage)image;

            // Define rasterization options to render the vector image to a raster format.
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size // Preserve original dimensions.
            };

            // Save the rendered raster image as PNG (intermediate step).
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };
            wmfImage.Save(intermediatePng, pngOptions);
        }

        // Load the intermediate raster image (PNG) to apply the motion Wiener filter.
        using (Image rasterImage = Image.Load(intermediatePng))
        {
            // Cast to RasterImage to use the Filter method.
            var raster = (RasterImage)rasterImage;

            // Apply a motion Wiener filter (length=10, smooth=1.0, angle=90 degrees) to the whole image.
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the filtered image.
            raster.Save(resultPng);
        }
    }
}