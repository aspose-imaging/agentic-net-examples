using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\sample.png";
        string outputPath = "output\\embossed.png";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            long originalSize = new FileInfo(inputPath).Length;

            using (RasterImage raster = (RasterImage)Image.Load(inputPath))
            {
                // Apply emboss filter using a predefined kernel
                raster.Filter(raster.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                // Save the filtered image with PNG options
                PngOptions options = new PngOptions
                {
                    // Use adaptive filtering for better compression
                    FilterType = PngFilterType.Adaptive
                };

                raster.Save(outputPath, options);
            }

            long newSize = new FileInfo(outputPath).Length;

            Console.WriteLine($"Original size: {originalSize} bytes");
            Console.WriteLine($"After emboss filter size: {newSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}