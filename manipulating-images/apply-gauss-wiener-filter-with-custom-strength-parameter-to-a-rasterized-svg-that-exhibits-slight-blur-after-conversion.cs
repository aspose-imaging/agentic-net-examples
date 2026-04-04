using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.svg";
        string outputPath = "output.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the SVG image
        using (Image image = Image.Load(inputPath))
        {
            // Rasterize the SVG by converting it to a RasterImage
            // (Aspose.Imaging automatically rasterizes when casting to RasterImage)
            RasterImage rasterImage = (RasterImage)image;

            // Create Gauss-Wiener filter options with custom strength parameters
            // Example: kernel size = 7, sigma = 3.5 (adjust as needed)
            var gaussWienerOptions = new GaussWienerFilterOptions(7, 3.5);

            // Apply the filter to the entire image
            rasterImage.Filter(rasterImage.Bounds, gaussWienerOptions);

            // Save the filtered raster image
            rasterImage.Save(outputPath);
        }
    }
}