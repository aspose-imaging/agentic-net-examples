using System;
using System.Diagnostics;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"c:\temp\sample.png";
        string outputPath = @"c:\temp\sample.SharpenFilter.png";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Load the image
        using (Image image = Image.Load(inputPath))
        {
            // Cast to RasterImage to access filtering functionality
            RasterImage rasterImage = (RasterImage)image;

            // Create sharpen filter options (kernel size 5, sigma 4.0)
            var sharpenOptions = new SharpenFilterOptions(5, 4.0);

            // Log kernel type
            Console.WriteLine($"Applying Sharpen filter with kernel type: {sharpenOptions.Kernel.GetType().Name}");

            // Measure processing time
            Stopwatch sw = Stopwatch.StartNew();

            // Apply the filter to the whole image
            rasterImage.Filter(rasterImage.Bounds, sharpenOptions);

            sw.Stop();
            Console.WriteLine($"Filter applied in {sw.ElapsedMilliseconds} ms");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Save the processed image
            rasterImage.Save(outputPath);
            Console.WriteLine($"Image saved to {outputPath}");
        }
    }
}