using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.svg";
            string originalRasterPath = "output_original.png";
            string blurredRasterPath = "output_blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(originalRasterPath));
            Directory.CreateDirectory(Path.GetDirectoryName(blurredRasterPath));

            // Load the SVG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to SvgImage
                SvgImage svgImage = (SvgImage)image;

                // Set up rasterization options for PNG output
                SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
                {
                    PageSize = svgImage.Size,
                    BackgroundColor = Color.White
                };

                PngOptions pngOptions = new PngOptions
                {
                    VectorRasterizationOptions = rasterOptions
                };

                // Save the original rasterized PNG
                svgImage.Save(originalRasterPath, pngOptions);
            }

            // Load the rasterized PNG to apply Gaussian blur
            using (Image rasterImageContainer = Image.Load(originalRasterPath))
            {
                RasterImage rasterImage = (RasterImage)rasterImageContainer;

                // Apply Gaussian blur with radius 5 and sigma 4.0
                rasterImage.Filter(rasterImage.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

                // Save the blurred image
                rasterImage.Save(blurredRasterPath, new PngOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}