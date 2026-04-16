using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Validate input file existence
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
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;

            // Crop a 400x400 region from the top-left corner
            raster.Crop(new Rectangle(0, 0, 400, 400));

            // Apply Gaussian blur with radius 5 and sigma 1.5
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 1.5));

            // Save the processed image as SVG
            raster.Save(outputPath, new SvgOptions());
        }
    }
}