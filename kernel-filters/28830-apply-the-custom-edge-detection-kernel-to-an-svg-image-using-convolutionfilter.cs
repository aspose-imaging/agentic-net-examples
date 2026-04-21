using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image vectorImage = Image.Load(inputPath))
            {
                // Rasterize SVG to a PNG in memory
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = vectorImage.Size
                };
                var pngSaveOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                using (var memoryStream = new MemoryStream())
                {
                    vectorImage.Save(memoryStream, pngSaveOptions);
                    memoryStream.Position = 0;

                    // Load the rasterized image as RasterImage
                    using (RasterImage rasterImage = (RasterImage)Image.Load(memoryStream))
                    {
                        // Define a custom edge detection kernel (Laplacian)
                        double[,] kernel = new double[,]
                        {
                            { -1, -1, -1 },
                            { -1,  8, -1 },
                            { -1, -1, -1 }
                        };

                        // Apply convolution filter with the custom kernel
                        var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.ConvolutionFilterOptions(kernel, 1.0, 0);
                        rasterImage.Filter(rasterImage.Bounds, filterOptions);

                        // Save the filtered raster image to the output path
                        var outputOptions = new PngOptions();
                        rasterImage.Save(outputPath, outputOptions);
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