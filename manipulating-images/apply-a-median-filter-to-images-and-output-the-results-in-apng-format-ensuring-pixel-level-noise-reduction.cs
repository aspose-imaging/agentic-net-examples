using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class MedianFilterApngExample
{
    static void Main()
    {
        // Input image path (any supported raster format)
        string inputPath = @"C:\Images\sample.png";

        // Output APNG path – using .apng extension with PNG options
        string outputPath = @"C:\Images\sample_filtered.apng";

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Apply a median filter with a kernel size of 5 to the whole image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the filtered image as APNG (APNG is a PNG extension; using PngOptions works)
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}