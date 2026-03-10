using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input AVIF image path
        string inputPath = "input.avif";
        // Output JPEG image path (AVIF saving not supported)
        string outputPath = "output.jpg";

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage raster = (RasterImage)image;

            // Apply an edge detection effect using Sharpen filter
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image as JPEG
            var jpegOptions = new JpegOptions();
            raster.Save(outputPath, jpegOptions);
        }
    }
}