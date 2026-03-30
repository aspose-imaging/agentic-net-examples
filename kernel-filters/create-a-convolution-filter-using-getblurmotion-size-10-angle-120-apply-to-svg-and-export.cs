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
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output\\filtered.png";

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
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };

            // Prepare PNG save options with the rasterization settings
            PngOptions pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (MemoryStream rasterStream = new MemoryStream())
            {
                svgImage.Save(rasterStream, pngSaveOptions);
                rasterStream.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImageContainer = Image.Load(rasterStream))
                {
                    RasterImage rasterImage = (RasterImage)rasterImageContainer;

                    // Create convolution kernel using GetBlurMotion (size 10, angle 120)
                    double[,] kernel = ConvolutionFilter.GetBlurMotion(10, 120.0);

                    // Apply the convolution filter
                    ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);
                    rasterImage.Filter(rasterImage.Bounds, filterOptions);

                    // Save the filtered raster image as PNG
                    rasterImage.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}