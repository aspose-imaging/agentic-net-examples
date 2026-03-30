using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "blurred.jpg";
        string outputPath = "restored.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the blurred JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage for filtering
            RasterImage raster = (RasterImage)image;

            // Create Gauss-Wiener deconvolution filter (radius=5, sigma=4.0)
            var deconvOptions = new Aspose.Imaging.ImageFilters.FilterOptions.GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, deconvOptions);

            // Prepare PNG save options
            var pngOptions = new PngOptions();

            // Save the restored image as PNG
            raster.Save(outputPath, pngOptions);
        }
    }
}