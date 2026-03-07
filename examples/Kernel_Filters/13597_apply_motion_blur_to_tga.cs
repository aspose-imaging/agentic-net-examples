using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Tga;
using Aspose.Imaging.ImageFilters.FilterOptions;

class MotionBlurTga
{
    static void Main()
    {
        // Path to the source TGA image
        string inputPath = @"C:\Images\source.tga";
        // Path where the processed image will be saved
        string outputPath = @"C:\Images\source_motionblur.tga";

        // Load the TGA image using Aspose.Imaging
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to TgaImage to access TGA‑specific members
            TgaImage tgaImage = (TgaImage)image;

            // Define motion blur parameters:
            //   size  - length of the blur kernel (e.g., 15 pixels)
            //   sigma - blur intensity (e.g., 1.0)
            //   angle - direction of motion in degrees (e.g., 45°)
            int size = 15;
            double sigma = 1.0;
            double angle = 45.0;

            // Apply a motion blur filter to the whole image.
            // Aspose.Imaging does not expose a dedicated MotionBlurFilterOptions class,
            // but the MotionWienerFilterOptions can be used to simulate motion blur
            // by specifying the kernel size, sigma, and angle.
            tgaImage.Filter(
                tgaImage.Bounds,
                new MotionWienerFilterOptions(size, sigma, angle));

            // Save the processed image back to TGA format
            tgaImage.Save(outputPath);
        }
    }
}