using System;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class RasterToSvgConverter
{
    static void Main()
    {
        // Path to the source raster image (e.g., PNG, BMP, JPEG)
        string inputPath = @"C:\Images\sample.png";

        // Desired path for the resulting SVG file
        string outputPath = @"C:\Images\sample.svg";

        // Load the raster image using Aspose.Imaging's unified loader
        using (Image rasterImage = Image.Load(inputPath))
        {
            // Set up rasterization options – the SVG page size will match the raster image dimensions
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = rasterImage.Size
            };

            // Configure SVG save options and attach the rasterization settings
            SvgOptions svgSaveOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
                // TextAsShapes defaults to false; raster data will be embedded as an <image> element
            };

            // Save the raster image as an SVG file
            rasterImage.Save(outputPath, svgSaveOptions);
        }
    }
}