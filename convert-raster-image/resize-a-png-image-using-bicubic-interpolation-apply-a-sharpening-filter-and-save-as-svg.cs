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

        // Load the PNG image
        using (Image image = Image.Load(inputPath))
        {
            // Desired dimensions for resizing (example: half size)
            int newWidth = image.Width / 2;
            int newHeight = image.Height / 2;

            // Resize using bicubic interpolation (CubicConvolution)
            image.Resize(newWidth, newHeight, ResizeType.CubicConvolution);

            // Apply sharpening filter to the raster image
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Prepare SVG save options with rasterization settings
            var svgOptions = new SvgOptions();
            var vectorRasterization = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = vectorRasterization;

            // Save the processed image as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}