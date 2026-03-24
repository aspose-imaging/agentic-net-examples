using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.dib";
        string outputPath = "output.dib";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the DIB image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter (radius=5, sigma=4.0)
            var deconvOptions = new GaussWienerFilterOptions(5, 4.0);
            raster.Filter(raster.Bounds, deconvOptions);

            // Save the processed image
            raster.Save(outputPath);
        }
    }
}