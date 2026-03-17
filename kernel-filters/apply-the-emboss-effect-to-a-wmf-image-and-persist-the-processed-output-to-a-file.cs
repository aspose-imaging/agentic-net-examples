using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output WMF file path
        string outputPath = "output.wmf";

        // Load the WMF image
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Prepare rasterization options for converting WMF to raster format
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Color.White
            };

            // Rasterize the WMF image to a PNG stored in memory
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                wmfImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply the emboss effect using a predefined convolution kernel
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed raster image back to WMF format
                    var wmfSaveOptions = new WmfOptions { VectorRasterizationOptions = rasterOptions };
                    rasterImage.Save(outputPath, wmfSaveOptions);
                }
            }
        }
    }
}