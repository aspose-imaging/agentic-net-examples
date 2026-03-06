using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

// Load the SVG image
string inputSvgPath = @"C:\Images\input.svg";
string intermediatePngPath = @"C:\Images\intermediate.png";
string outputPngPath = @"C:\Images\output_blur.png";

using (Image svgImage = Image.Load(inputSvgPath)) // load SVG
{
    // Set rasterization options to match the SVG size
    var rasterOptions = new SvgRasterizationOptions
    {
        PageSize = svgImage.Size
    };

    // Configure PNG save options with the rasterization settings
    var pngOptions = new PngOptions
    {
        VectorRasterizationOptions = rasterOptions
    };

    // Rasterize SVG to a temporary PNG file
    svgImage.Save(intermediatePngPath, pngOptions);
}

// Load the rasterized PNG, apply Gaussian blur, and save the final result
using (Image rasterImage = Image.Load(intermediatePngPath))
{
    var raster = (RasterImage)rasterImage;

    // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

    // Save the blurred image
    raster.Save(outputPngPath, new PngOptions());
}

// Optional: clean up the intermediate file
if (File.Exists(intermediatePngPath))
{
    File.Delete(intermediatePngPath);
}