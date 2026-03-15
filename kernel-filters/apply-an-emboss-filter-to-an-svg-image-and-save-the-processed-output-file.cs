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
        // Output file path after emboss filter
        string outputPath = "output_emboss.png";

        // Load the SVG image and rasterize it to a PNG file
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Set up PNG save options with vector rasterization
            PngOptions pngOptions = new PngOptions();
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            pngOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the rasterized PNG to a temporary file
            svgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage to apply the emboss filter
        using (RasterImage raster = (RasterImage)Image.Load(tempPngPath))
        {
            // Apply the emboss convolution filter
            raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

            // Save the filtered image to the final output file
            raster.Save(outputPath);
        }

        // Clean up the temporary PNG file
        if (File.Exists(tempPngPath))
        {
            File.Delete(tempPngPath);
        }
    }
}