using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"input\sample.png";
        string outputPath = @"output\sample.svg";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the raster image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering and resizing
                RasterImage rasterImage = (RasterImage)image;

                // Apply a median filter with a kernel size of 5
                rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

                // Resize to thumbnail dimensions (e.g., 150x150)
                rasterImage.Resize(150, 150);

                // Save the processed image as SVG
                rasterImage.Save(outputPath, new SvgOptions());
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}