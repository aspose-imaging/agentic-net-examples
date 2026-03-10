using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cmx;

class Program
{
    static void Main(string[] args)
    {
        // Input CMX file path
        string inputPath = "input.cmx";
        // Output raster image path (PNG format)
        string outputPath = "output.png";

        // Load the CMX vector image
        using (CmxImage cmxImage = (CmxImage)Image.Load(inputPath))
        {
            // Render the CMX image to a raster format using a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Save CMX as PNG into the memory stream
                cmxImage.Save(rasterStream, new PngOptions());
                rasterStream.Position = 0;

                // Load the rendered raster image
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply Gaussian blur filter to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred raster image
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}