using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Gif;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurGifExample
{
    static void Main()
    {
        // Path to the source GIF image
        string sourcePath = @"C:\temp\sample.gif";

        // Path where the processed image will be saved
        string outputPath = @"C:\temp\sample.MotionBlur.gif";

        // Load the image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(sourcePath))
        {
            // Cast the loaded image to GifImage to access GIF-specific functionality
            GifImage gifImage = (GifImage)image;

            // Define motion blur parameters:
            //   size  - length of the motion blur kernel (e.g., 10 pixels)
            //   sigma - smoothing factor (e.g., 1.0)
            //   angle - direction of motion in degrees (e.g., 45.0)
            int size = 10;
            double sigma = 1.0;
            double angle = 45.0;

            // Apply the motion blur (using MotionWienerFilterOptions as the closest available filter)
            gifImage.Filter(
                gifImage.Bounds,                                   // Apply to the whole image
                new MotionWienerFilterOptions(size, sigma, angle) // Motion blur configuration
            );

            // Save the resulting image to the specified output path
            gifImage.Save(outputPath);
        }
    }
}