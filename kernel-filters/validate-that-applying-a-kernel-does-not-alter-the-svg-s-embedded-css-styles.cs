using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\temp\input.svg";
            string outputPath = @"C:\temp\output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string originalContent = File.ReadAllText(inputPath);

            using (Image image = Image.Load(inputPath))
            {
                SvgImage svgImage = (SvgImage)image;

                // Rasterize SVG to PNG in memory
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply a simple blur kernel
                        double[,] kernel = ConvolutionFilter.GetBlurBox(3);
                        raster.Filter(raster.Bounds, new ConvolutionFilterOptions(kernel));

                        // Save the filtered image
                        raster.Save(outputPath, new PngOptions());
                    }
                }

                // Verify that the SVG file's CSS has not changed
                string afterContent = File.ReadAllText(inputPath);
                if (originalContent != afterContent)
                {
                    Console.Error.WriteLine("CSS styles were altered.");
                }
                else
                {
                    Console.WriteLine("CSS styles remain unchanged.");
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}