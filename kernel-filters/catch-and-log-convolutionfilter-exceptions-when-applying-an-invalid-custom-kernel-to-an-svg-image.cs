using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string outputPath = "output.png";
            string tempPngPath = "temp.png";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath));

            // Load SVG and rasterize to a temporary PNG
            using (Image svgImage = Image.Load(inputPath))
            {
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = new SvgRasterizationOptions
                    {
                        PageSize = svgImage.Size
                    }
                };
                svgImage.Save(tempPngPath, pngOptions);
            }

            // Load the rasterized PNG
            using (Image rasterImageContainer = Image.Load(tempPngPath))
            {
                var rasterImage = (RasterImage)rasterImageContainer;

                // Create an invalid custom kernel (non‑square matrix)
                double[,] invalidKernel = new double[2, 3];
                var convOptions = new ConvolutionFilterOptions(invalidKernel);

                // Apply convolution filter and catch any exceptions
                try
                {
                    rasterImage.Filter(rasterImage.Bounds, convOptions);
                }
                catch (Exception ex)
                {
                    Console.Error.WriteLine($"Filter error: {ex.Message}");
                }

                // Save the (potentially unchanged) image to the final output
                var saveOptions = new PngOptions();
                rasterImage.Save(outputPath, saveOptions);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}