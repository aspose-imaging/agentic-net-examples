using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Define input and output file paths
        string inputPath = "input.png";
        string outputPath = "output_motion_blur.png";

        // Load the image as a RasterImage
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Motion blur parameters:
            // length – size of the motion kernel
            // smooth – smoothing factor (1.0 is typical)
            // angle – direction of motion in degrees
            int length = 15;
            double smooth = 1.0;
            double angle = 45.0;

            // Apply the motion blur filter to the whole image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(length, smooth, angle));

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}