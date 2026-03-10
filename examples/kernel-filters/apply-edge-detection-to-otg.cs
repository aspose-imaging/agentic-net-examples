using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input OTG file path
        string inputPath = "input.otg";
        // Output raster image path (PNG)
        string outputPath = "output.png";

        // Load the OTG image
        using (Image otgImage = Image.Load(inputPath))
        {
            // Rasterize OTG to PNG in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                PngOptions pngOptions = new PngOptions
                {
                    // Set rasterization options for OTG
                    VectorRasterizationOptions = new OtgRasterizationOptions
                    {
                        PageSize = otgImage.Size
                    }
                };
                otgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply a sharpen filter (used here as an edge detection approximation)
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed image
                    raster.Save(outputPath);
                }
            }
        }
    }
}