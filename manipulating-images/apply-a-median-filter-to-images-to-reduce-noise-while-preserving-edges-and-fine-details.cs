using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.MedianFilter.png";

        // Verify that the input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure the output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the image, apply a median filter, and save the result
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Apply a median filter with a rectangle size of 5 to the entire image
            rasterImage.Filter(rasterImage.Bounds, new MedianFilterOptions(5));

            // Save the filtered image
            rasterImage.Save(outputPath);
        }
    }
}