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
            string inputPath = "template.svg";
            string outputPath = "output.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Rasterize SVG to PNG in memory
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                PngOptions pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngSaveOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage raster = (RasterImage)Image.Load(ms))
                    {
                        // Apply predefined Sharpen3x3 filter
                        raster.Filter(raster.Bounds,
                            new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                                Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Sharpen3x3));

                        // Save sharpened image as PNG
                        PngOptions outOptions = new PngOptions();
                        raster.Save(outputPath, outOptions);
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