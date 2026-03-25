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
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.jpg";
        string outputPath = @"C:\Images\output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the raster image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access raster-specific methods
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with size 5 to the whole image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Resize the image to 1200x1200 pixels
            raster.Resize(1200, 1200);

            // Prepare SVG save options with rasterization settings
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions
                {
                    // Set page size to match the resized raster dimensions
                    PageSize = raster.Size
                }
            };

            // Save the processed image as SVG
            raster.Save(outputPath, svgOptions);
        }
    }
}