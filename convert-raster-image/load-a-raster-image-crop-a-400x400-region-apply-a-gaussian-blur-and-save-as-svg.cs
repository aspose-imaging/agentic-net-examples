using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
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

        // Load, process, and save the image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Cache data for better performance
            if (!raster.IsCached)
                raster.CacheData();

            // Crop a 400x400 region from the top-left corner
            Rectangle cropRect = new Rectangle(0, 0, 400, 400);
            raster.Crop(cropRect);

            // Apply Gaussian blur (radius 5, sigma 4.0)
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Prepare SVG save options
            SvgOptions svgOptions = new SvgOptions();
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = raster.Size
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save the processed image as SVG
            raster.Save(outputPath, svgOptions);
        }
    }
}