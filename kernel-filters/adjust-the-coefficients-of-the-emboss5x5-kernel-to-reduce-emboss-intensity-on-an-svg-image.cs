// HOW-TO: Reduce Emboss Filter Intensity on SVG When Converting to PNG in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image svgImage = Image.Load(inputPath))
            {
                SvgImage svg = (SvgImage)svgImage;

                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svg.Size,
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream rasterStream = new MemoryStream())
                {
                    svgImage.Save(rasterStream, pngOptions);
                    rasterStream.Position = 0;

                    using (Image rasterImg = Image.Load(rasterStream))
                    {
                        RasterImage raster = (RasterImage)rasterImg;

                        double[,] originalKernel = Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss5x5;
                        int rows = originalKernel.GetLength(0);
                        int cols = originalKernel.GetLength(1);
                        double[,] adjustedKernel = new double[rows, cols];

                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                adjustedKernel[i, j] = originalKernel[i, j] * 0.5;
                            }
                        }

                        var convOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(adjustedKernel);
                        raster.Filter(raster.Bounds, convOptions);
                        raster.Save(outputPath, new PngOptions());
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

/*
 * Real-World Use Cases:
 * 1. When you need to generate a lighter embossed effect for SVG graphics before exporting them as PNG files in a .NET application.
 * 2. When you want to programmatically adjust convolution kernel values to fine‑tune image filters for web‑ready SVG thumbnails.
 * 3. When you are building an automated pipeline that rasterizes SVG logos and applies a subtle emboss to match a brand’s visual style.
 * 4. When you need to reduce the harshness of an emboss filter to improve readability of text embedded in SVG diagrams after conversion.
 * 5. When you are creating a C# utility that processes multiple SVG assets and requires custom kernel scaling to control the emboss strength uniformly.
 */
