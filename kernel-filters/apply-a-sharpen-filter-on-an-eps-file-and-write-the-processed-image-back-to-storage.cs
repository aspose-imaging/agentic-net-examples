using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.eps";
        string outputPath = "output.png";
        string tempPath = "temp.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");

        // Load EPS image and rasterize to a temporary PNG
        using (Image epsImage = Image.Load(inputPath))
        {
            // Cast to EpsImage (full namespace to avoid extra using)
            var eps = (Aspose.Imaging.FileFormats.Eps.EpsImage)epsImage;

            // Set up rasterization options (preserve aspect ratio)
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = 0,
                PageHeight = 0
            };

            // Save rasterized PNG to temporary file
            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };
            eps.Save(tempPath, pngOptions);
        }

        // Load the rasterized PNG as a RasterImage
        using (Image rasterImg = Image.Load(tempPath))
        {
            var raster = (RasterImage)rasterImg;

            // Apply sharpen filter (kernel size 5, sigma 4.0)
            raster.Filter(raster.Bounds,
                new Aspose.Imaging.ImageFilters.FilterOptions.SharpenFilterOptions(5, 4.0));

            // Save the processed image to the final output path
            var outOptions = new PngOptions();
            raster.Save(outputPath, outOptions);
        }
    }
}