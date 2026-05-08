using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "template.svg";
        string outputPath = "result.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Set up SVG rasterization options
                var svgRasterOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size,
                    BackgroundColor = Color.White
                };

                // Prepare PNG save options with the rasterization settings
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = svgRasterOptions
                };

                // Rasterize SVG to a memory stream
                using (var rasterStream = new MemoryStream())
                {
                    vectorImage.Save(rasterStream, pngSaveOptions);
                    rasterStream.Position = 0;

                    // Load the rasterized image
                    using (Image rasterImageContainer = Image.Load(rasterStream))
                    {
                        var rasterImage = (RasterImage)rasterImageContainer;

                        // Define a custom 3x3 kernel emphasizing diagonal edges
                        double[,] diagonalKernel = new double[,]
                        {
                            { -1, 0, 1 },
                            { 0, 0, 0 },
                            { 1, 0, -1 }
                        };

                        // Apply convolution filter with the custom kernel
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(diagonalKernel);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered raster image
                        rasterImage.Save(outputPath, new PngOptions());
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}