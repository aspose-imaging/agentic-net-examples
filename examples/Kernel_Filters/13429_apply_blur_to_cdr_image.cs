using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Cdr;

class Program
{
    static void Main(string[] args)
    {
        // Paths for input CDR file and output blurred image
        string inputPath = "input.cdr";
        string outputPath = "output.png";

        // Load the CDR vector image
        using (var cdrImage = (Aspose.Imaging.FileFormats.Cdr.CdrImage)Image.Load(inputPath))
        {
            // Rasterize the vector image to PNG in a memory stream
            using (var memoryStream = new MemoryStream())
            {
                cdrImage.Save(memoryStream, new PngOptions());
                memoryStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image
                using (var rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply Gaussian blur filter to the entire image
                    rasterImage.Filter(
                        rasterImage.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                    // Save the blurred raster image to the output file
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}