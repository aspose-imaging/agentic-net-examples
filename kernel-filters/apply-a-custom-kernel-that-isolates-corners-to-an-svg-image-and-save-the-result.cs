using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
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
            // Prepare rasterization options for PNG output
            var rasterOptions = new SvgRasterizationOptions
            {
                PageSize = vectorImage.Size
            };
            var pngSaveOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            // Rasterize SVG to a memory stream
            using (var ms = new MemoryStream())
            {
                vectorImage.Save(ms, pngSaveOptions);
                ms.Position = 0;

                // Load the rasterized image
                using (Image rasterImage = Image.Load(ms))
                {
                    var raster = (RasterImage)rasterImage;

                    // Define a custom 3x3 kernel that isolates corners (edge detection)
                    double[,] kernel = new double[,]
                    {
                        { -1, -1, -1 },
                        { -1,  8, -1 },
                        { -1, -1, -1 }
                    };

                    // Apply the convolution filter with the custom kernel
                    var filterOptions = new ConvolutionFilterOptions(kernel);
                    raster.Filter(raster.Bounds, filterOptions);

                    // Save the filtered raster image as PNG
                    raster.Save(outputPath, new PngOptions());
                }
            }
        }
    }
}