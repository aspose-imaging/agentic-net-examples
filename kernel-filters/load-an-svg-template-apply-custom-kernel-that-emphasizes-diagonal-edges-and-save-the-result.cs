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
        try
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

            // Temporary rasterized PNG path
            string tempPath = "temp.png";
            Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

            // Load SVG and rasterize to temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
                var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
                svgImage.Save(tempPath, pngOptions);
            }

            // Load the rasterized image, apply custom diagonal edge kernel, and save result
            using (Image rasterImage = Image.Load(tempPath))
            {
                var raster = (RasterImage)rasterImage;

                // Custom 3x3 kernel emphasizing diagonal edges
                double[,] kernel = new double[,]
                {
                    { -1, 0, 1 },
                    {  0, 0, 0 },
                    {  1, 0,-1 }
                };

                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel);
                raster.Filter(raster.Bounds, filterOptions);
                raster.Save(outputPath, new PngOptions());
            }

            // Clean up temporary file
            if (File.Exists(tempPath))
            {
                File.Delete(tempPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}