using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input DIB image and output PNG image
        string inputPath = "input.dib";
        string outputPath = "output.png";

        // Load the DIB image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage rasterImage = (RasterImage)image;

            // Apply a motion blur (motion wiener) filter:
            // length = 10, smooth = 1.0, angle = 90 degrees
            rasterImage.Filter(
                rasterImage.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the result as PNG
            rasterImage.Save(outputPath, new PngOptions());
        }
    }
}