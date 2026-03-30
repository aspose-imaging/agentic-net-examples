using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (SvgImage svgImage = new SvgImage(inputPath))
        {
            // Set up rasterization options for SVG to PNG conversion
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions();
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize SVG into a memory stream (PNG format)
            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0; // Reset stream position for reading

                // Load the rasterized PNG as a RasterImage to apply filters
                using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                {
                    // Apply Sharpen filter (3x3 kernel)
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(3, 0.0));

                    // Save the sharpened image as PNG
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}