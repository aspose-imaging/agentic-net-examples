using System;
using System.IO;
using System.Linq;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\sample.embossed.png";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Image image = Image.Load(inputPath))
            {
                RasterImage rasterImage = (RasterImage)image;

                // Ensure data is cached
                if (!rasterImage.IsCached)
                {
                    rasterImage.CacheData();
                }

                // Measure brightness before filter
                int[] pixelsBefore = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                double brightnessBefore = pixelsBefore.Average(p =>
                {
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return (r + g + b) / 3.0;
                });

                // Apply Emboss3x3 filter
                var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(
                    Aspose.Imaging.ImageFilters.Convolution.ConvolutionFilter.Emboss3x3);
                rasterImage.Filter(rasterImage.Bounds, filterOptions);

                // Measure brightness after filter
                int[] pixelsAfter = rasterImage.GetDefaultArgb32Pixels(rasterImage.Bounds);
                double brightnessAfter = pixelsAfter.Average(p =>
                {
                    int r = (p >> 16) & 0xFF;
                    int g = (p >> 8) & 0xFF;
                    int b = p & 0xFF;
                    return (r + g + b) / 3.0;
                });

                // Save the filtered image
                rasterImage.Save(outputPath, new PngOptions());

                Console.WriteLine($"Brightness before: {brightnessBefore:F2}");
                Console.WriteLine($"Brightness after: {brightnessAfter:F2}");
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}