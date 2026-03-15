using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input TGA image path
        string inputPath = "input.tga";
        // Output TGA image path
        string outputPath = "output.tga";

        // Load the TGA image as a raster image
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Apply motion blur (motion wiener) filter to the entire image
            // Parameters: length = 10, smooth = 1.0, angle = 90.0 degrees
            image.Filter(image.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

            // Save the processed image as TGA
            image.Save(outputPath, new TgaOptions());
        }
    }
}