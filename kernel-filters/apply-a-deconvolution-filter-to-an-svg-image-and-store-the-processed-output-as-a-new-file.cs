using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string tempPngPath = "temp.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories for temporary and final output exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPngPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load SVG and rasterize to a temporary PNG
        using (Image svgImage = Image.Load(inputPath))
        {
            var rasterOptions = new SvgRasterizationOptions { PageSize = svgImage.Size };
            var pngOptions = new PngOptions { VectorRasterizationOptions = rasterOptions };
            svgImage.Save(tempPngPath, pngOptions);
        }

        // Load the rasterized PNG, apply deconvolution filter, and save the result
        using (Image img = Image.Load(tempPngPath))
        {
            RasterImage raster = (RasterImage)img;

            // Apply a Gaussian deconvolution filter (GaussWienerFilterOptions)
            var filterOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, filterOptions);

            raster.Save(outputPath);
        }
    }
}