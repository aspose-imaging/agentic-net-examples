using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.svg";
        string outputPath = "output/output.bmp";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize SVG to a PNG in memory
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions();
                    SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                    {
                        PageSize = vectorImage.Size
                    };
                    pngOptions.VectorRasterizationOptions = rasterOptions;

                    vectorImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized image as RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(ms))
                    {
                        // Apply sharpen filter
                        rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                        // Apply emboss filter using convolution kernel
                        rasterImage.Filter(rasterImage.Bounds, new ConvolutionFilterOptions(ConvolutionFilter.Emboss3x3));

                        // Save the result as BMP
                        BmpOptions bmpOptions = new BmpOptions();
                        rasterImage.Save(outputPath, bmpOptions);
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