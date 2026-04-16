using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\sample.png";
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
            // Cast to RasterImage to access filtering and resizing
            RasterImage raster = (RasterImage)image;

            // Apply a median filter with a kernel size of 5 to the whole image
            raster.Filter(raster.Bounds, new MedianFilterOptions(5));

            // Resize to thumbnail size (e.g., 150x150)
            raster.Resize(150, 150);

            // Prepare SVG save options with rasterization settings
            var rasterizationOptions = new SvgRasterizationOptions
            {
                PageSize = raster.Size // Preserve the resized dimensions
            };
            var svgOptions = new SvgOptions
            {
                VectorRasterizationOptions = rasterizationOptions
            };

            // Save the processed image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}