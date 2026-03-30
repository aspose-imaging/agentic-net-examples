using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.svg";
        string outputPath = @"C:\Images\output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Temporary file for the rotated rasterized image
        string tempPath = Path.Combine(Path.GetTempPath(), "temp_rotated.png");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath));

        // Load SVG, rotate, and rasterize to temporary PNG
        using (Image svgImage = Image.Load(inputPath))
        {
            // Rotate by 45 degrees
            svgImage.Rotate(45f);

            // Rasterize to PNG using vector rasterization options
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions { PageSize = svgImage.Size }
            };
            svgImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized image, apply Gaussian blur, and save final output
        using (Image rasterImage = Image.Load(tempPath))
        {
            var raster = (RasterImage)rasterImage;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the blurred image as PNG
            raster.Save(outputPath, new PngOptions());
        }

        // Optionally delete the temporary file
        try
        {
            File.Delete(tempPath);
        }
        catch
        {
            // Ignore any errors during cleanup
        }
    }
}