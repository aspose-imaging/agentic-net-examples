using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;

            // Resize to 640x480 using default nearest neighbour resample
            raster.Resize(640, 480);

            // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Prepare SVG save options with default rasterization settings
            SvgOptions svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = new SvgRasterizationOptions()
            };

            // Save the processed image as SVG
            raster.Save(outputPath, svgOptions);
        }
    }
}