using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Bmp;
using Aspose.Imaging.FileFormats.Svg;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load BMP as RasterImage, resize, apply Gaussian blur, and save as SVG
        using (RasterImage image = (RasterImage)Image.Load(inputPath))
        {
            // Cache data for better performance
            if (!image.IsCached) image.CacheData();

            // Resize to 1024x1024 using nearest neighbour resampling
            image.Resize(1024, 1024, ResizeType.NearestNeighbourResample);

            // Apply Gaussian blur with radius 5 and sigma 4.0
            image.Filter(image.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare SVG save options with rasterization settings
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    PageSize = image.Size
                }
            };

            // Save the processed image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}