using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurExample
{
    static void Main()
    {
        // Path to the folder containing the BMP image.
        string dataDir = @"C:\Images\";

        // Load the BMP image.
        using (Image image = Image.Load(dataDir + "input.bmp"))
        {
            // Cast to RasterImage to access filtering capabilities.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion blur (motion wiener) filter to the entire image.
            // Parameters: length = 10, smooth = 1.0, angle = 0 degrees.
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Save the processed image as a new BMP file.
            rasterImage.Save(dataDir + "output.bmp");
        }
    }
}