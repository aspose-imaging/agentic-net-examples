using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output_emboss.png";

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
            // Prepare rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = ((SvgImage)svgImage).Size
            };

            // Set up PNG save options with the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to PNG in memory
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized PNG as a RasterImage
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Apply emboss filter using convolution kernel
                    rasterImage.Filter(rasterImage.Bounds,
                        new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed image to the output path
                    rasterImage.Save(outputPath);
                }
            }
        }
    }
}