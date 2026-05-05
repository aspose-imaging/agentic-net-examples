using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.svg";
            string tempPngPath = "temp\\temp.png";
            string outputPath = "output\\output.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG and apply an invalid convolution filter
            using (Image rasterImg = Image.Load(tempPngPath))
            {
                var raster = (RasterImage)rasterImg;

                // Create an invalid (non‑square) kernel
                double[,] invalidKernel = new double[2, 3];
                invalidKernel[0, 0] = 0; invalidKernel[0, 1] = 1; invalidKernel[0, 2] = 0;
                invalidKernel[1, 0] = 1; invalidKernel[1, 1] = -4; invalidKernel[1, 2] = 1;

                try
                {
                    raster.Filter(raster.Bounds, new ConvolutionFilterOptions(invalidKernel));
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Convolution filter error: {ex.Message}");
                }

                // Save the (possibly unchanged) image
                raster.Save(outputPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}