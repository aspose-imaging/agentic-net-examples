using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

namespace ImageProcessingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Paths for input JPEG and output image
            string inputPath = "input.jpg";
            string outputPath = "output_sharpened.jpg";

            // Load the JPEG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply a sharpen filter (edge detection) to the whole image
                raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image
                raster.Save(outputPath);
            }
        }
    }
}