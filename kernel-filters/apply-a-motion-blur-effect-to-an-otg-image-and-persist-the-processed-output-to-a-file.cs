using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.Sources;

class Program
{
    static void Main(string[] args)
    {
        // Input OTG file path
        string inputPath = "input.otg";
        // Output raster image path
        string outputPath = "output.png";

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Prepare PNG options with rasterization settings for OTG
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = new OtgRasterizationOptions
            {
                PageSize = otgImage.Size
            };

            // Rasterize OTG to a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                otgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as RasterImage
                using (RasterImage raster = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply motion wiener filter (motion blur effect)
                    raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Prepare output PNG options bound to a file source
                    Source outSource = new FileCreateSource(outputPath, false);
                    PngOptions outOptions = new PngOptions { Source = outSource };

                    // Save the processed image
                    raster.Save(outputPath, outOptions);
                }
            }
        }
    }
}