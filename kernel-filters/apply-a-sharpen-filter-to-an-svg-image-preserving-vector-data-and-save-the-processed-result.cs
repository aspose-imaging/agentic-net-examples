using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image svgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for PNG output
            var rasterizationOptions = new SvgRasterizationOptions();
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize SVG to a memory stream
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(memoryStream))
                {
                    // Cast to RasterImage to apply filters
                    var raster = (RasterImage)rasterImage;

                    // Apply a sharpen filter to the entire image
                    raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Save the processed raster image
                    raster.Save(outputPath);
                }
            }
        }
    }
}