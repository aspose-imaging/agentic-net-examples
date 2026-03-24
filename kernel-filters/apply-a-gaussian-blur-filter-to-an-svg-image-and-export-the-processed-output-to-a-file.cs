using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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

        // Load SVG image from file stream
        using (Stream svgStream = File.OpenRead(inputPath))
        using (SvgImage svgImage = new SvgImage(svgStream))
        {
            // Set up rasterization options for SVG -> raster conversion
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Configure PNG save options with rasterization
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Rasterize SVG into a memory stream
            using (var rasterStream = new MemoryStream())
            {
                svgImage.Save(rasterStream, pngOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(rasterStream))
                {
                    // Apply Gaussian blur filter to the entire image
                    var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                    rasterImage.Filter(rasterImage.Bounds, blurOptions);

                    // Save the processed image to the output path
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}