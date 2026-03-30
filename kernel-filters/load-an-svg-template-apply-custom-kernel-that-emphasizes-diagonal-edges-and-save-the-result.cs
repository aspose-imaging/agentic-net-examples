using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "template.svg";
        string outputPath = "result.png";

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
            // Prepare rasterization options for PNG output
            var rasterOptions = new Aspose.Imaging.ImageOptions.SvgRasterizationOptions
            {
                PageSize = svgImage.Size
            };
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (var ms = new MemoryStream())
            {
                svgImage.Save(ms, pngSaveOptions);
                ms.Position = 0;

                // Load the rasterized image as a RasterImage
                using (Image rasterImg = Image.Load(ms))
                {
                    var raster = (RasterImage)rasterImg;

                    // Define a custom 3x3 kernel emphasizing diagonal edges
                    double[,] kernel = new double[,]
                    {
                        { -1, 0, 1 },
                        {  0, 0, 0 },
                        {  1, 0,-1 }
                    };

                    // Create convolution filter options with the custom kernel
                    var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);

                    // Apply the filter to the entire image
                    raster.Filter(raster.Bounds, filterOptions);

                    // Save the filtered image as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}