using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using System.Drawing;

class MotionBlurExample
{
    static void Main()
    {
        // Input PNG image path
        string inputPath = "input.png";

        // Output PNG image path
        string outputPath = "output.png";

        // Load the PNG image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion blur effect to the entire image.
            // MotionWienerFilterOptions is used here with:
            //   length = 10 (kernel size),
            //   sigma  = 1.0 (smoothness),
            //   angle  = 90.0 degrees.
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}