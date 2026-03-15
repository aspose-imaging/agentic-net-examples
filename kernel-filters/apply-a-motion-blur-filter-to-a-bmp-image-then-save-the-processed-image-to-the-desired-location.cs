using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurExample
{
    static void Main()
    {
        // Path to the source BMP image
        string inputPath = @"C:\Images\source.bmp";

        // Path where the processed image will be saved
        string outputPath = @"C:\Images\source_motionblur.bmp";

        // Load the BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to gain access to the Filter method
            RasterImage raster = (RasterImage)image;

            // Create a MotionWienerFilterOptions instance.
            // Length = 10, Smooth = 1.0, Angle = 0 degrees (horizontal motion blur)
            var motionBlurOptions = new MotionWienerFilterOptions(10, 1.0, 0.0);

            // Apply the filter to the entire image bounds
            raster.Filter(raster.Bounds, motionBlurOptions);

            // Save the processed image to the desired location
            raster.Save(outputPath);
        }
    }
}