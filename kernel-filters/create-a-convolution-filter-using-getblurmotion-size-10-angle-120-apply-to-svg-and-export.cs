using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load SVG image
            using (SvgImage svgImage = (SvgImage)Image.Load(inputPath))
            {
                // Set up rasterization options for PNG
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions();
                rasterOptions.PageSize = svgImage.Size;

                PngOptions pngOptions = new PngOptions();
                pngOptions.VectorRasterizationOptions = rasterOptions;

                // Rasterize SVG to a memory stream
                using (MemoryStream ms = new MemoryStream())
                {
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load rasterized image
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Create convolution kernel using GetBlurMotion (size=10, angle=120)
                        double[,] kernel = ConvolutionFilter.GetBlurMotion(10, 120.0);
                        ConvolutionFilterOptions filterOptions = new ConvolutionFilterOptions(kernel);

                        // Apply filter to the entire image
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Save the filtered image as PNG
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