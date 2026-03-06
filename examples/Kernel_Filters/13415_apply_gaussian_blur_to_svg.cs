using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Paths for input SVG, intermediate rasterized PNG, and final blurred PNG
        string inputSvgPath = @"C:\Images\input.svg";
        string intermediatePngPath = @"C:\Images\intermediate.png";
        string outputPngPath = @"C:\Images\output_blurred.png";

        // Step 1: Load the SVG image
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Configure rasterization options to convert SVG to raster format
            var rasterizationOptions = new SvgRasterizationOptions
            {
                // Use the original SVG size for rasterization
                PageSize = svgImage.Size
            };

            // Save the SVG as a raster PNG (this performs the rasterization)
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };
            svgImage.Save(intermediatePngPath, pngSaveOptions);
        }

        // Step 2: Load the rasterized PNG as a RasterImage
        using (Image rasterImage = Image.Load(intermediatePngPath))
        {
            var raster = (RasterImage)rasterImage;

            // Apply Gaussian blur filter to the entire image
            // Parameters: kernel size = 5, sigma = 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image
            raster.Save(outputPngPath, new PngOptions());
        }
    }
}