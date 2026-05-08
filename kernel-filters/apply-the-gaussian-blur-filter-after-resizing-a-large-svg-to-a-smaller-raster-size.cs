using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\large.svg";
            string resizedPath = @"C:\Images\resized.png";
            string outputPath = @"C:\Images\blurred.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(resizedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the SVG image
            using (Image svgImage = Image.Load(inputPath))
            {
                // Define target raster size (example: 800x600)
                int targetWidth = 800;
                int targetHeight = 600;

                // Resize the SVG while preserving aspect ratio
                svgImage.Resize(targetWidth, targetHeight, ResizeType.NearestNeighbourResample);

                // Save the resized SVG as a PNG (raster image)
                var pngOptions = new PngOptions();
                svgImage.Save(resizedPath, pngOptions);
            }

            // Load the rasterized PNG
            using (Image rasterImg = Image.Load(resizedPath))
            {
                // Cast to RasterImage to apply filters
                var raster = (RasterImage)rasterImg;

                // Apply Gaussian blur filter (size 5, sigma 4.0) to the whole image
                raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the final blurred image
                raster.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}