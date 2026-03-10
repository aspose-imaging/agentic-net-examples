using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Input SVG file path
        string inputSvgPath = "input.svg";
        // Output raster image path (PNG)
        string outputPngPath = "output.png";

        // Load the SVG image
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Prepare rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
            rasterOptions.PageSize = svgImage.Size;

            // Set up PNG save options with the rasterization settings
            PngOptions pngOptions = new PngOptions();
            pngOptions.VectorRasterizationOptions = rasterOptions;

            // Rasterize SVG to a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Apply motion blur (motion wiener) filter
                    // Parameters: length, smooth value, angle
                    rasterImage.Filter(rasterImage.Bounds, new MotionWienerFilterOptions(10, 1.0, 90.0));

                    // Save the filtered raster image as PNG
                    rasterImage.Save(outputPngPath, new PngOptions());
                }
            }
        }
    }
}