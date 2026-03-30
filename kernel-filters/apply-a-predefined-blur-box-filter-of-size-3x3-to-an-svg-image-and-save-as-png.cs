using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

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
        using (Image svgImage = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG → PNG conversion
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream (PNG format)
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0; // Reset stream position for reading

                // Load the rasterized PNG as a RasterImage
                using (Image rasterImg = Image.Load(memoryStream))
                {
                    var raster = (RasterImage)rasterImg;

                    // Apply a 3x3 blur box filter using convolution filter options
                    var blurFilter = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.GetBlurBox(3));
                    raster.Filter(raster.Bounds, blurFilter);

                    // Save the filtered image as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}