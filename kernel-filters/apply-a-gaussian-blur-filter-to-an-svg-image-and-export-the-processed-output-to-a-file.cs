using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Input SVG file path
        string inputSvgPath = @"C:\Images\input.svg";
        // Output PNG file path (rasterized and blurred)
        string outputPngPath = @"C:\Images\output.png";

        // Load the SVG image
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Prepare rasterization options for SVG -> PNG conversion
            var svgRasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size // use original SVG size
            };

            // PNG save options with the rasterization settings
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = svgRasterOptions
            };

            // Rasterize SVG to a memory stream (PNG format)
            using (MemoryStream rasterStream = new MemoryStream())
            {
                svgImage.Save(rasterStream, pngSaveOptions);
                rasterStream.Position = 0; // reset stream position for reading

                // Load the rasterized PNG as a RasterImage
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    var raster = (RasterImage)rasterImage;

                    // Apply Gaussian blur filter to the entire image
                    raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                    // Save the processed image to the desired output file
                    raster.Save(outputPngPath, new PngOptions());
                }
            }
        }
    }
}