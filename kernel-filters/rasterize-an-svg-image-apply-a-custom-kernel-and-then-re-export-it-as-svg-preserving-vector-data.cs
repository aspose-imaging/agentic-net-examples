using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                // Rasterize SVG to a raster image in memory
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (var ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        var raster = (RasterImage)rasterImg;

                        // Apply a custom convolution kernel
                        double[,] kernel = new double[,]
                        {
                            { 0, -1, 0 },
                            { -1, 5, -1 },
                            { 0, -1, 0 }
                        };
                        var convOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, convOptions);

                        // Create a new SVG and draw the filtered raster onto it
                        var svgGraphics = new SvgGraphics2D(raster.Width, raster.Height, 96);
                        svgGraphics.DrawImage(raster, new Point(0, 0));

                        using (SvgImage finalSvg = svgGraphics.EndRecording())
                        {
                            var saveOptions = new SvgOptions();
                            finalSvg.Save(outputPath, saveOptions);
                        }
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