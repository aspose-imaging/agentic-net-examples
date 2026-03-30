using System;
using System.IO;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.bmp";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load SVG image
        using (Aspose.Imaging.Image svgImage = Aspose.Imaging.Image.Load(inputPath))
        {
            // Set up rasterization options for vector image
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = svgImage.Size,
                BackgroundColor = Aspose.Imaging.Color.White
            };

            // Rasterize SVG to a memory stream (PNG format)
            using (var memoryStream = new MemoryStream())
            {
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(memoryStream, pngOptions);
                memoryStream.Position = 0;

                // Load rasterized image
                using (Aspose.Imaging.Image rasterImageContainer = Aspose.Imaging.Image.Load(memoryStream))
                {
                    var rasterImage = (Aspose.Imaging.RasterImage)rasterImageContainer;

                    // Apply sharpen filter
                    rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

                    // Apply emboss filter using predefined kernel
                    rasterImage.Filter(rasterImage.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                        Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3));

                    // Save the processed image as BMP
                    var bmpOptions = new BmpOptions();
                    rasterImage.Save(outputPath, bmpOptions);
                }
            }
        }
    }
}