using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.OpenDocument;

class Program
{
    static void Main(string[] args)
    {
        // Input ODG file path
        string inputPath = "input.odg";
        // Output raster image path
        string outputPath = "output.png";

        // Load the ODG vector image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for converting vector to raster
            var rasterizationOptions = new OdgRasterizationOptions
            {
                BackgroundColor = Color.White,
                PageSize = vectorImage.Size
            };

            // Rasterize the vector image into a memory stream as PNG
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (RasterImage raster = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply motion blur (motion wiener) filter to the entire image
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image to file
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}