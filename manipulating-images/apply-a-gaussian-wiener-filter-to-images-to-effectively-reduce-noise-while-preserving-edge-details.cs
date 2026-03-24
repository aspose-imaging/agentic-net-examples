using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output.GaussWienerFilter.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access the Filter method
            RasterImage raster = (RasterImage)image;

            // Create Gauss-Wiener filter options (size = 5, sigma = 4.0)
            var filterOptions = new GaussWienerFilterOptions(5, 4.0);

            // Apply the filter to the entire image
            raster.Filter(raster.Bounds, filterOptions);

            // Save the filtered image
            raster.Save(outputPath);
        }
    }
}