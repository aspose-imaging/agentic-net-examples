using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class SharpenSvgExample
{
    static void Main()
    {
        // Input SVG file path
        string inputSvgPath = "input.svg";
        // Output rasterized PNG file path after sharpening
        string outputPngPath = "output.png";

        // Load the SVG image (vector image)
        using (Image svgImage = Image.Load(inputSvgPath))
        {
            // Rasterize the SVG to a PNG image in memory
            using (MemoryStream rasterStream = new MemoryStream())
            {
                // Set up PNG options with vector rasterization settings
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        // Use the original SVG size for rasterization
                        PageSize = svgImage.Size
                    }
                };

                // Save (rasterize) the SVG into the memory stream as PNG
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0; // Reset stream position for reading

                // Load the rasterized image from the memory stream
                using (Image rasterImage = Image.Load(rasterStream))
                {
                    // Cast to RasterImage to access filtering capabilities
                    RasterImage raster = (RasterImage)rasterImage;

                    // Apply a sharpen filter to the entire image bounds
                    // Kernel size = 5, sigma = 4.0 (example values)
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the sharpened raster image to the desired output file
                    raster.Save(outputPngPath, new PngOptions());
                }
            }
        }
    }
}