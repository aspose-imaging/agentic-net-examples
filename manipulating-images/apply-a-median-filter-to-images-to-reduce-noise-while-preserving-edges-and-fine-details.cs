using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.FileFormats.Tiff;
using Aspose.Imaging.FileFormats.Gif;

class MedianFilterExample
{
    static void Main()
    {
        // Directory containing the source images
        string dir = @"c:\temp\";

        // ---------- PNG / JPEG / BMP (generic raster image) ----------
        using (Image image = Image.Load(dir + "sample.png"))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with a kernel size of 5 to the whole image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Save the filtered image (output format can be any supported type)
            raster.Save(dir + "sample.MedianFilter.png");
        }

        // ---------- TIFF ----------
        using (Image image = Image.Load(dir + "sample.tif"))
        {
            TiffImage tiff = (TiffImage)image;

            // Apply median filter to the entire TIFF image
            tiff.Filter(tiff.Bounds, new MedianFilterOptions(5));

            // Save as PNG to visualize the result
            tiff.Save(dir + "sample.Tiff.MedianFilter.png", new PngOptions());
        }

        // ---------- GIF ----------
        using (Image image = Image.Load(dir + "sample.gif"))
        {
            GifImage gif = (GifImage)image;

            // Apply median filter to the whole GIF image
            gif.Filter(gif.Bounds, new MedianFilterOptions(5));

            // Save as PNG (preserves the filtered frame)
            gif.Save(dir + "sample.Gif.MedianFilter.png", new PngOptions());
        }

        // ---------- DJVU ----------
        using (Image image = Image.Load(dir + "sample.djvu"))
        {
            DjvuImage djvu = (DjvuImage)image;

            // Apply median filter to the entire DJVU image
            djvu.Filter(djvu.Bounds, new MedianFilterOptions(5));

            // Save as PNG to view the filtered result
            djvu.Save(dir + "sample.Djvu.MedianFilter.png", new PngOptions());
        }
    }
}