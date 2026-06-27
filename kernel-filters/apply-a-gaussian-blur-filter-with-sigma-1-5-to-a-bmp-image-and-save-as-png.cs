using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                var rasterImage = (RasterImage)image;

                // Create Gaussian blur filter with size 5 and sigma 1.5
                var blurOptions = new GaussianBlurFilterOptions(5, 1.5);

                // Apply the filter to the entire image
                rasterImage.Filter(rasterImage.Bounds, blurOptions);

                // Save the result as PNG
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
 * 1. When a developer needs to soften the edges of a scanned BMP document before converting it to a PNG for web display, they can apply a Gaussian blur with sigma 1.5 using Aspose.Imaging in C#.
 * 2. When preparing legacy BMP assets for a mobile app, a developer may blur the image to reduce visual noise and then save it as a PNG to benefit from lossless compression.
 * 3. When creating a thumbnail gallery where BMP images must be uniformly softened to improve aesthetic consistency, the code can apply a Gaussian blur filter and output PNG files.
 * 4. When implementing a batch processing tool that sanitizes sensitive details in BMP screenshots by blurring them before archiving as PNG, this C# snippet provides the required functionality.
 * 5. When integrating image preprocessing in a .NET workflow that requires converting BMP files to PNG while applying a subtle Gaussian blur to meet UI design guidelines, the example demonstrates the exact steps.
 */