using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\blurred.png";
        string outputPath = @"C:\Images\restored.png";

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
            // Cast to RasterImage to access filtering capabilities
            RasterImage rasterImage = (RasterImage)image;

            // Apply a Gauss-Wiener deconvolution filter (Gaussian deconvolution)
            // Parameters: radius = 5, sigma = 4.0 (adjust as needed for the blur)
            var filterOptions = new GaussWienerFilterOptions(5, 4.0);
            rasterImage.Filter(rasterImage.Bounds, filterOptions);

            // Save the processed image
            rasterImage.Save(outputPath);
        }
    }
}