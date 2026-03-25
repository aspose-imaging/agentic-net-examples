using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

        // Load BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for raster operations
            RasterImage raster = (RasterImage)image;

            // Resize to 500x500 using default nearest neighbour resample
            raster.Resize(500, 500);

            // Apply median filter with kernel size 5
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Prepare SVG save options with rasterization settings
            SvgOptions svgOptions = new SvgOptions();
            SvgRasterizationOptions rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = raster.Size
            };
            svgOptions.VectorRasterizationOptions = rasterizationOptions;

            // Save the processed image as SVG
            raster.Save(outputPath, svgOptions);
        }
    }
}