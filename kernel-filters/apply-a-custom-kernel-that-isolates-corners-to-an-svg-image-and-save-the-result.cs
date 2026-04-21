using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Svg.Graphics;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.svg";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            using (Image image = Image.Load(inputPath))
            {
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    image.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (Image rasterImg = Image.Load(ms))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        double[,] kernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };

                        ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);
                        raster.Filter(raster.Bounds, filterOptions);

                        int width = raster.Width;
                        int height = raster.Height;
                        int dpi = 96;

                        SvgGraphics2D graphics = new SvgGraphics2D(width, height, dpi);
                        graphics.DrawImage(raster, new Point(0, 0));

                        using (SvgImage resultSvg = graphics.EndRecording())
                        {
                            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                            resultSvg.Save(outputPath);
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