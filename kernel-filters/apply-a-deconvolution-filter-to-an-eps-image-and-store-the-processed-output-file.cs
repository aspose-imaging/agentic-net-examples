using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input, temporary, and output paths
        string inputPath = "input.eps";
        string tempPath = "temp.png";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure directories for temporary and output files exist
        Directory.CreateDirectory(Path.GetDirectoryName(tempPath) ?? ".");
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

        // Load EPS image and export it to a temporary PNG (rasterization)
        using (Image epsImage = Image.Load(inputPath))
        {
            epsImage.Save(tempPath, new PngOptions());
        }

        // Load the rasterized PNG, apply a deconvolution filter, and save the result
        using (Image img = Image.Load(tempPath))
        {
            RasterImage raster = (RasterImage)img;

            // Gauss-Wiener deconvolution filter with radius 5 and sigma 4.0
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the processed image
            raster.Save(outputPath, new PngOptions());
        }
    }
}