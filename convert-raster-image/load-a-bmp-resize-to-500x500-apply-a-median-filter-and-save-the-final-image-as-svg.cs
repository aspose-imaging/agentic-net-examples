using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.bmp";
        string outputPath = "Output/output.svg";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load BMP image
        using (Image image = Image.Load(inputPath))
        {
            // Resize to 500x500
            image.Resize(500, 500);

            // Apply median filter (kernel size 5)
            RasterImage raster = (RasterImage)image;
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.MedianFilterOptions(5));

            // Prepare SVG save options with rasterization settings
            SvgOptions svgOptions = new SvgOptions();
            SvgRasterizationOptions rasterOptions = new SvgRasterizationOptions
            {
                PageSize = image.Size
            };
            svgOptions.VectorRasterizationOptions = rasterOptions;

            // Save as SVG
            image.Save(outputPath, svgOptions);
        }
    }
}