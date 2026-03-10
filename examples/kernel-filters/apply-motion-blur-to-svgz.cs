using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class ApplyMotionBlurToSvgz
{
    static void Main()
    {
        // Path to the compressed SVGZ file
        string inputFile = @"C:\Images\sample.svgz";

        // Path where the processed image will be saved (PNG format)
        string outputFile = @"C:\Images\sample_motionblur.png";

        // Load the SVGZ image. Aspose.Imaging automatically handles the compression.
        using (Image image = Image.Load(inputFile))
        {
            // The loaded image can be treated as a raster image for pixel‑level operations.
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion blur (using MotionWiener filter as the closest available option).
            // Parameters: length = 10, smooth = 1.0, angle = 0 degrees (horizontal blur).
            rasterImage.Filter(
                rasterImage.Bounds,
                new MotionWienerFilterOptions(10, 1.0, 0.0));

            // Save the result. PNG is a common raster format for SVGZ output.
            rasterImage.Save(outputFile, new PngOptions());
        }
    }
}