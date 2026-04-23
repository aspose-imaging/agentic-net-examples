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
        string outputPath = "output.bmp";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image vectorImage = Image.Load(inputPath))
        {
            // Set up rasterization options for SVG
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };

            // Use PNG options to rasterize the SVG into a memory stream
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            using (var memoryStream = new MemoryStream())
            {
                // Rasterize SVG to PNG in memory
                vectorImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load the rasterized image as a RasterImage for filtering
                using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                {
                    // Apply sharpen filter
                    rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                    // Apply emboss filter using a predefined convolution kernel
                    rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                    // Save the processed image as BMP
                    var bmpOptions = new BmpOptions();
                    rasterImage.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}