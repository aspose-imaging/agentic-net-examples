using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.ImageFilters.Convolution;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Images\input.png";
            string outputPath = @"C:\Images\output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply the 5x5 sharpen filter.
                // SharpenFilterOptions with kernel size 5 and sigma 1.0 approximates the Sharpen5x5 kernel.
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 1.0));

                // Save the processed image, preserving original brightness (filter does not alter overall brightness)
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a desktop application needs to automatically enhance scanned PNG documents by sharpening edges without changing overall brightness, this code can be used.
 * 2. When a batch‑processing tool must improve the visual clarity of product photos stored as PNG files before uploading them to an e‑commerce site, the Sharpen5x5 filter can be applied with this snippet.
 * 3. When a C# service processes user‑uploaded images and wants to apply a 5×5 convolution sharpen filter while preserving the original luminance for consistent UI appearance, the example shows how to do it.
 * 4. When a reporting system generates PNG charts and requires a quick post‑processing step to make fine details more pronounced without altering the chart’s color balance, this code provides the solution.
 * 5. When a Windows utility needs to clean up low‑resolution screenshots by sharpening them and saving the result to the same directory structure, the provided code demonstrates the necessary file‑handling and Aspose.Imaging calls.
 */