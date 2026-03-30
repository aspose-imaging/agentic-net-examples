using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string filteredPath = "filtered.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(filteredPath) ?? ".");

        // Load the original PNG image, apply a Gaussian blur filter, and save the filtered image
        using (Image image = Image.Load(inputPath))
        {
            RasterImage raster = (RasterImage)image;

            // Apply Gaussian blur filter with radius 5 and sigma 4.0
            raster.Filter(raster.Bounds, new Aspose.Imaging.ImageFilters.FilterOptions.GaussianBlurFilterOptions(5, 4.0));

            // Set PNG save options (maximum compression)
            PngOptions options = new PngOptions
            {
                CompressionLevel = 9
            };

            // Save the filtered image
            image.Save(filteredPath, options);
        }

        // Calculate file sizes and compression ratio
        long originalSize = new FileInfo(inputPath).Length;
        long filteredSize = new FileInfo(filteredPath).Length;
        double compressionRatio = (double)originalSize / filteredSize;

        Console.WriteLine($"Original size: {originalSize} bytes");
        Console.WriteLine($"Filtered size: {filteredSize} bytes");
        Console.WriteLine($"Compression ratio (original/filtered): {compressionRatio:F2}");
    }
}