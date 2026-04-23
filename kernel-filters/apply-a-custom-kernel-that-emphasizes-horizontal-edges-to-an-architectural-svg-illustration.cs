using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\temp\\architectural.svg";
        string outputPath = "C:\\temp\\architectural_filtered.png";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Set up rasterization options for PNG output
                VectorRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };

                // Rasterize SVG to a memory stream as PNG
                using (MemoryStream ms = new MemoryStream())
                {
                    PngOptions pngOptions = new PngOptions
                    {
                        VectorRasterizationOptions = rasterOptions
                    };
                    svgImage.Save(ms, pngOptions);
                    ms.Position = 0;

                    // Load the rasterized PNG as a RasterImage
                    using (Image rasterImageContainer = Image.Load(ms))
                    {
                        RasterImage rasterImage = (RasterImage)rasterImageContainer;

                        // Define a custom kernel for horizontal edge detection (Sobel operator)
                        double[,] kernel = new double[,]
                        {
                            { -1, -2, -1 },
                            {  0,  0,  0 },
                            {  1,  2,  1 }
                        };

                        // Apply the convolution filter with the custom kernel
                        var convOptions = new ConvolutionFilterOptions(kernel);
                        rasterImage.Filter(rasterImage.Bounds, convOptions);

                        // Save the filtered image as PNG
                        rasterImage.Save(outputPath, pngOptions);
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