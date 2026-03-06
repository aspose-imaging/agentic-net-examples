using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input WMF file path
        string inputPath = "input.wmf";
        // Output raster image path (PNG format)
        string outputPath = "output.png";

        // Load the WMF image (vector)
        using (Image wmfImage = Image.Load(inputPath))
        {
            // Prepare vector rasterization options for WMF
            var rasterOptions = new WmfRasterizationOptions
            {
                PageSize = wmfImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // PNG options with vector rasterization settings
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize WMF to a memory stream as PNG
            using (var memoryStream = new MemoryStream())
            {
                wmfImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Emboss filter using ConvolutionFilterOptions with Emboss3x3 kernel
                    raster.Filter(raster.Bounds,
                        new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                            Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                    // Save the filtered image
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}