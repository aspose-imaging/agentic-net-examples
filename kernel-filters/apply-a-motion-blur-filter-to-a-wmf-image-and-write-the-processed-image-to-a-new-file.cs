using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Wmf;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output raster image path (PNG)
        string outputPath = "output.png";

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Set up rasterization options for WMF to PNG conversion
            var rasterizationOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // PNG save options with vector rasterization
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Render WMF to a raster image in memory
            using (var memoryStream = new MemoryStream())
            {
                wmfImage.Save(memoryStream, pngSaveOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply motion blur (motion wiener) filter to the entire image
                    raster.Filter(raster.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the processed image as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}