using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Svg;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\input.svg";
        string intermediatePath = @"c:\temp\rotated.png";
        string outputPath = @"c:\temp\final.png";

        // Input file existence check
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        try
        {
            // Load SVG, rotate 45 degrees, and save as PNG (intermediate raster image)
            using (SvgImage svgImage = new SvgImage(inputPath))
            {
                svgImage.Rotate(45f);

                // Ensure output directory exists for intermediate file
                Directory.CreateDirectory(Path.GetDirectoryName(intermediatePath));

                // Rasterization options for PNG output
                var rasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size
                };
                var pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterizationOptions
                };

                svgImage.Save(intermediatePath, pngOptions);
            }

            // Load the intermediate PNG as a raster image
            using (Image image = Image.Load(intermediatePath))
            {
                var rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter to the entire image
                var blurOptions = new GaussianBlurFilterOptions(5, 4.0);
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Ensure output directory exists for final file
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Save the final blurred image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}