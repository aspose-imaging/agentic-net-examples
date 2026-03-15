using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Cdr;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input CDR file path and output raster image path.
        string inputPath = args.Length > 0 ? args[0] : "input.cdr";
        string outputPath = args.Length > 1 ? args[1] : "output.png";

        // Load the CDR vector image.
        using (Image cdrImage = Image.Load(inputPath))
        {
            CdrImage cdr = (CdrImage)cdrImage;

            // Rasterize the CDR image to a PNG in memory.
            using (MemoryStream rasterStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions();
                cdr.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image.
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply Sharpen filter to the entire image.
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed raster image.
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}