using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class ApplyFiltersDemo
{
    static void Main()
    {
        string dir = "c:\\temp\\";

        // Apply a median filter (kernel size 5) to a raster PNG image and save as PNG
        using (Image image = Image.Load(dir + "sample.png"))
        {
            RasterImage rasterImage = (RasterImage)image;
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));
            rasterImage.Save(dir + "sample.MedianFilter.png");
        }

        // Apply a bilateral smoothing filter (kernel size 5) to a GIF image and save as PNG
        using (Image image = Image.Load(dir + "sample.gif"))
        {
            Aspose.Imaging.FileFormats.Gif.GifImage gifImage = (Aspose.Imaging.FileFormats.Gif.GifImage)image;
            gifImage.Filter(gifImage.Bounds, new BilateralSmoothingFilterOptions(5));
            gifImage.Save(dir + "sample.BilateralSmoothingFilter.png", new PngOptions());
        }

        // Apply a Gaussian blur filter (radius 5, sigma 4.0) to a JPEG image and save as JPEG
        using (Image image = Image.Load(dir + "sample.jpg"))
        {
            RasterImage rasterImage = (RasterImage)image;
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));
            rasterImage.Save(dir + "sample.GaussianBlurFilter.jpg");
        }

        // Apply a sharpen filter (kernel size 5, sigma 4.0) to a WebP image and save as PNG
        using (Image image = Image.Load(dir + "sample.webp"))
        {
            Aspose.Imaging.FileFormats.Webp.WebPImage webpImage = (Aspose.Imaging.FileFormats.Webp.WebPImage)image;
            webpImage.Filter(webpImage.Bounds, new SharpenFilterOptions(5, 4.0));
            webpImage.Save(dir + "sample.SharpenFilter.png", new PngOptions());
        }

        // Apply a motion Wiener filter (length 10, smooth 1.0, angle 90) to a TIFF image and save as PNG
        using (Image image = Image.Load(dir + "sample.tif"))
        {
            Aspose.Imaging.FileFormats.Tiff.TiffImage tiffImage = (Aspose.Imaging.FileFormats.Tiff.TiffImage)image;
            tiffImage.Filter(tiffImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));
            tiffImage.Save(dir + "sample.MotionWienerFilter.png", new PngOptions());
        }
    }
}