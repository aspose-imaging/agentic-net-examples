using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.svg";
            string outputPath = "output.svg";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary files for raster processing
            string tempPng = "temp.png";
            string filteredPng = "filtered.png";

            // Load SVG and rasterize to PNG
            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPng, pngOptions);
            }

            // Load rasterized PNG, apply custom convolution kernel, and save filtered PNG
            using (RasterImage raster = (RasterImage)Image.Load(tempPng))
            {
                double[,] kernel = new double[,]
                {
                    { -1, -1, -1 },
                    { -1,  9, -1 },
                    { -1, -1, -1 }
                };

                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));
                raster.Save(filteredPng, new PngOptions());
            }

            // Create a new SVG and embed the filtered raster image
            using (Image image = Image.Load(inputPath))
            {
                SvgImage originalSvg = (SvgImage)image;
                int width = originalSvg.Width;
                int height = originalSvg.Height;
                int dpi = 96;

                var graphics = new SvgGraphics2D(width, height, dpi);

                using (RasterImage filteredRaster = (RasterImage)Image.Load(filteredPng))
                {
                    graphics.DrawImage(filteredRaster, new Point(0, 0));
                }

                using (SvgImage finalSvg = graphics.EndRecording())
                {
                    finalSvg.Save(outputPath, new SvgOptions());
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}