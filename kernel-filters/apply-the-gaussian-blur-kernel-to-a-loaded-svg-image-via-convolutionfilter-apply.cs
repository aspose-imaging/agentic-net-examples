using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
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
            // Prepare rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Set up PNG save options with the rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (var memoryStream = new MemoryStream())
            {
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image
                using (Image rasterImageContainer = Image.Load(memoryStream))
                {
                    var rasterImage = (RasterImage)rasterImageContainer;

                    // Obtain Gaussian kernel (size 5, sigma 4.0)
                    double[,] gaussianKernel = ConvolutionFilter.GetGaussian(5, 4.0);

                    // Create convolution filter options with the kernel
                    var convolutionOptions = new ConvolutionFilterOptions(gaussianKernel);

                    // Apply the Gaussian blur to the entire image
                    rasterImage.Filter(rasterImage.Bounds, convolutionOptions);

                    // Save the blurred raster image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}