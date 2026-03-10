using System;
using Aspose.Imaging;

class Program
{
    static void Main(string[] args)
    {
        // Paths to the input AVIF image and the output file
        string inputPath = "input.avif";
        string outputPath = "output.avif";

        // Load the AVIF image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion Wiener filter (used here as a motion blur effect)
            // Parameters: length = 10, smooth = 1.0, angle = 45 degrees
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 45.0));

            // Save the processed image (same AVIF format)
            rasterImage.Save(outputPath);
        }
    }
}