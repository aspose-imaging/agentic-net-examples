using System;
using System.Drawing;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class ApplyMotionWienerFilterToEmz
{
    static void Main()
    {
        // Paths for the source EMZ, an intermediate PNG, and the final output image
        string inputEmzPath = "input.emz";
        string intermediatePngPath = "intermediate.png";
        string outputPath = "output.png";

        // -----------------------------------------------------------------
        // Step 1: Load the EMZ (compressed EMF) file and rasterize it to PNG.
        // -----------------------------------------------------------------
        using (Image emzImage = Image.Load(inputEmzPath))
        {
            // Configure rasterization options to match the original vector size
            var rasterizationOptions = new EmfRasterizationOptions
            {
                PageSize = emzImage.Size
            };

            // Set PNG save options with the rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized image as a temporary PNG file
            emzImage.Save(intermediatePngPath, pngOptions);
        }

        // ---------------------------------------------------------------
        // Step 2: Load the rasterized PNG, apply MotionWiener filter, save.
        // ---------------------------------------------------------------
        using (Image rasterImage = Image.Load(intermediatePngPath))
        {
            // Cast to RasterImage to access the Filter method
            var raster = (RasterImage)rasterImage;

            // Apply a motion Wiener filter (length=10, sigma=1.0, angle=45 degrees)
            raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 45.0));

            // Save the filtered image to the desired output location
            raster.Save(outputPath);
        }

        Console.WriteLine("Motion Wiener filter applied and saved to: " + outputPath);
    }
}