using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Paths for the original SVG, an intermediate raster image, and the final blurred output
        string svgPath = @"C:\temp\input.svg";
        string intermediatePng = @"C:\temp\intermediate.png";
        string blurredPng = @"C:\temp\output_blurred.png";

        // Load the SVG image
        using (Image svgImage = Image.Load(svgPath))
        {
            // Set up rasterization options to convert SVG to raster format (PNG)
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size // use original SVG size
            };

            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the rasterized version to a temporary PNG file
            svgImage.Save(intermediatePng, pngSaveOptions);
        }

        // Load the rasterized PNG image
        using (Image rasterImage = Image.Load(intermediatePng))
        {
            // Cast to RasterImage to access the Filter method
            var raster = (RasterImage)rasterImage;

            // Apply Gaussian blur filter (radius = 5, sigma = 4.0) to the whole image
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the blurred image
            raster.Save(blurredPng, new PngOptions());
        }
    }
}