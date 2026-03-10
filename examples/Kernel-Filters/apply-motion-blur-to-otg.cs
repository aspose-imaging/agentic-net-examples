using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurExample
{
    static void Main()
    {
        // Input OTG image path (replace with actual file path)
        string inputPath = @"C:\Images\sample.otg";

        // Output image path
        string outputPath = @"C:\Images\sample.MotionBlur.png";

        // Load the OTG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage rasterImage = (RasterImage)image;

            // Define motion blur parameters:
            // length (kernel size), smooth (sigma), angle (degrees)
            int length = 10;          // kernel size
            double smooth = 1.0;      // smoothing factor
            double angle = 45.0;      // motion direction

            // Apply the motion blur (using MotionWienerFilterOptions as the closest available option)
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(length, smooth, angle));

            // Save the processed image as PNG
            rasterImage.Save(outputPath);
        }
    }
}