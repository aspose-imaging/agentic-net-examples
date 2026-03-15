using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class MotionBlurCmxExample
{
    static void Main()
    {
        // Paths for input CMX file and output image
        string inputPath = "input.cmx";
        string outputPath = "output.png";

        // Load the CMX image
        using (Image cmxImage = Image.Load(inputPath))
        {
            // Cast to CmxImage to access CMX‑specific members
            var cmx = (Aspose.Imaging.FileFormats.Cmx.CmxImage)cmxImage;

            // Convert CMX to a raster format (PNG) using an in‑memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                cmx.Save(rasterStream, new PngOptions());
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply a motion‑wiener filter (used here as a motion blur effect)
                    // Parameters: length = 10, smooth = 1.0, angle = 90 degrees
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image to the desired output file
                    raster.Save(outputPath);
                }
            }
        }
    }
}