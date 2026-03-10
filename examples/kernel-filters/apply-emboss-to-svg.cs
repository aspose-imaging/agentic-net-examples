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
        // Input SVG file path
        string inputSvgPath = "input.svg";

        // Temporary rasterized PNG path
        string tempPngPath = "temp.png";

        // Output PNG path after applying emboss filter
        string outputPngPath = "output.png";

        // Rasterize SVG to PNG
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            svgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply emboss filter, and save result
        using (Image rasterImage = Image.Load(tempPngPath))
        {
            var raster = (RasterImage)rasterImage;

            // Apply emboss filter using predefined kernel
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the filtered image as PNG
            raster.Save(outputPngPath, new PngOptions());
        }

        // Clean up temporary file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}