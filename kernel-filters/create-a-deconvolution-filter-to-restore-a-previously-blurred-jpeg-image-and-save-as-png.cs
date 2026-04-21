using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\blurred.jpg";
        string outputPath = @"C:\Images\restored.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the JPEG image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter (radius 5, sigma 4.0)
            var filterOptions = new GaussWienerFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the restored image as PNG with default options
            var pngOptions = new PngOptions();
            rasterImage.Save(outputPath, pngOptions);
        }
    }
}