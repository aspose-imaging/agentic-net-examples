using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image
        using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // PNG save options with vector rasterization
            PngOptions pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to PNG in memory
            using (MemoryStream ms = new MemoryStream())
            {
                svgImage.Save(ms, pngOptions);
                ms.Position = 0;

                // Load rasterized PNG as RasterImage
                using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                {
                    // Apply 3x3 blur box filter
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.GetBlurBox(3)));

                    // Save the filtered image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}