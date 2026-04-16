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
        string outputPath = "output/output.svg";

        // Validate input file existence
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
            // Cast to RasterImage for pixel operations
            RasterImage raster = (RasterImage)image;

            // Resize using bicubic interpolation (CubicConvolution)
            raster.Resize(800, 600, ResizeType.CubicConvolution);

            // Apply sharpening filter
            raster.Filter(raster.Bounds, new SharpenFilterOptions(5, 4.0));

            // Save the result as SVG
            SvgOptions svgOptions = new SvgOptions();
            image.Save(outputPath, svgOptions);
        }
    }
}