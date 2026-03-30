using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Png;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Temp\sample.png";
        string outputPath = @"C:\Temp\sample_blurred_compressed.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        // Load the source image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to apply filters
            RasterImage rasterImage = (RasterImage)image;

            // Apply Gaussian blur (kernel size 5, sigma 4.0) to the whole image
            rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

            // Configure PNG save options with maximum compression
            PngOptions pngOptions = new PngOptions
            {
                CompressionLevel = 9,
                FilterType = PngFilterType.Adaptive,
                Progressive = true
            };

            // Save the blurred image using the configured options
            rasterImage.Save(outputPath, pngOptions);
        }

        // Evaluate compression efficiency
        long originalSize = new FileInfo(inputPath).Length;
        long compressedSize = new FileInfo(outputPath).Length;
        Console.WriteLine($"Original size: {originalSize} bytes");
        Console.WriteLine($"Compressed (blurred) size: {compressedSize} bytes");
        Console.WriteLine($"Size reduction: {originalSize - compressedSize} bytes");
    }
}