using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        string dir = @"c:\temp\";

        // Load a raster image and apply a median filter (kernel size = 5)
        using (Image image = Image.Load(dir + "sample.png"))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));
            raster.Save(dir + "sample.MedianFilter.png");
        }

        // Load the same image and apply a bilateral smoothing filter (kernel size = 5)
        using (Image image = Image.Load(dir + "sample.png"))
        {
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new BilateralSmoothingFilterOptions(5));
            raster.Save(dir + "sample.BilateralSmoothingFilter.png");
        }

        // Load the image again and resize it using ImageResizeSettings with a specific filter type
        using (Image image = Image.Load(dir + "sample.png"))
        {
            RasterImage raster = (RasterImage)image;

            // Create resize settings and set the filter type to BigRectangular
            ImageResizeSettings resizeSettings = new ImageResizeSettings
            {
                FilterType = ImageFilterType.BigRectangular
            };

            // Resize the image to 200x200 pixels using the defined settings
            raster.Resize(200, 200, resizeSettings);
            raster.Save(dir + "sample.ResizedBigRectangular.png");
        }
    }
}