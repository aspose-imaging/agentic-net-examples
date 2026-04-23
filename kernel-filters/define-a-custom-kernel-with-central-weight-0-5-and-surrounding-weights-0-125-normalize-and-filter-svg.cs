using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string tempPath = "temp\\temp.png";
            string outputPath = "output\\filtered.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories for temporary and final output exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };
                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized PNG, apply custom convolution filter, and save result
            using (Image rasterImage = Image.Load(tempPath))
            {
                var raster = (RasterImage)rasterImage;

                // Define custom 3x3 kernel (central 0.333..., surrounding 0.08333...)
                double[,] kernel = new double[,]
                {
                    { 0.0833333333, 0.0833333333, 0.0833333333 },
                    { 0.0833333333, 0.3333333333, 0.0833333333 },
                    { 0.0833333333, 0.0833333333, 0.0833333333 }
                };

                var convOptions = new ConvolutionFilterOptions(kernel, 1.0, 0);
                raster.Filter(raster.Bounds, convOptions);
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}