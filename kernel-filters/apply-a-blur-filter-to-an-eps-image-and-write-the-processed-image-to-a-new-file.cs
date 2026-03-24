using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Eps;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageFilters.FilterOptions;

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
        using (EpsImage epsImage = (EpsImage)Image.Load(inputPath))
        {
            var rasterOptions = new EpsRasterizationOptions
            {
                PageWidth = epsImage.Width,
                PageHeight = epsImage.Height
            };

            var pngOptions = new PngOptions
            {
                VectorRasterizationOptions = rasterOptions
            };

            epsImage.Save(tempPath, pngOptions);
        }

        // Load the rasterized image, apply Gaussian blur, and save the result
        using (Image image = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Save the processed image
            raster.Save(outputPath, new PngOptions());
        }
    }
}