using System;
using System.Drawing; // For Rectangle
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Avif; // AvifImage class
using Aspose.Imaging.ImageFilters.FilterOptions; // MotionWienerFilterOptions

class MotionBlurAvifExample
{
    static void Main()
    {
        // Paths to the source AVIF image and the destination file
        string inputPath = "input.avif";
        string outputPath = "output.avif";

        // Load the AVIF image using Aspose.Imaging's Image.Load method
        using (Image image = Image.Load(inputPath))
        {
            // Cast the generic Image to AvifImage to access raster operations
            AvifImage avifImage = (AvifImage)image;

            // Apply a motion‑blur (motion Wiener) filter to the whole image.
            // Parameters: length (kernel size), sigma (smoothing), angle (degrees)
            avifImage.Filter(
                avifImage.Bounds,
                new MotionWienerFilterOptions(length: 10, sigma: 1.0, angle: 90.0));

            // Save the processed image to a new AVIF file
            avifImage.Save(outputPath);
        }
    }
}