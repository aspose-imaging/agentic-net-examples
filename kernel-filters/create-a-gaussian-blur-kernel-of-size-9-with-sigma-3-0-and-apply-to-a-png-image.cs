using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input\\sample.png";
        string outputPath = "output\\sample_blurred.png";

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
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur with size 9 and sigma 3.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(9, 3.0));

            // Save the result as PNG
            PngOptions options = new PngOptions();
            raster.Save(outputPath, options);
        }
    }
}