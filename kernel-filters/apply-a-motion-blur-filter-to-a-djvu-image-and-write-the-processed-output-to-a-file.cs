using System;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Djvu;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Input DJVU file path
        string inputPath = @"C:\temp\sample.djvu";
        // Output PNG file path
        string outputPath = @"C:\temp\sample.MotionBlur.png";

        // Load the DJVU image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to DjvuImage to access DJVU‑specific functionality
            DjvuImage djvuImage = (DjvuImage)image;

            // Apply a motion blur (motion wiener) filter to the whole image.
            // Parameters: length (kernel size), smooth (blur intensity), angle (direction in degrees)
            int length = 10;          // size of the motion kernel
            double smooth = 1.0;      // smoothing factor
            double angle = 0.0;       // horizontal motion; change to 90 for vertical, etc.

            djvuImage.Filter(
                djvuImage.Bounds,
                new MotionWienerFilterOptions(length, smooth, angle));

            // Save the processed image as PNG
            djvuImage.Save(outputPath, new PngOptions());
        }
    }
}