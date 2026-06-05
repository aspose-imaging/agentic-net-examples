using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\temp\input.bmp";
        string outputPath = @"C:\temp\output_blur.bmp";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image
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
 * 1. When a developer needs to soften the background of a BMP design mockup for a UI prototype, they can use this C# code with Aspose.Imaging to apply a Gaussian blur filter.
 * 2. When a developer wants to preprocess BMP assets for a web banner by reducing visual noise through a Gaussian blur before compression, this example demonstrates the required steps.
 * 3. When a developer is building an automated workflow that generates blurred placeholders from high‑resolution BMP images for lazy loading, the code shows how to load, filter, and save the result.
 * 4. When a developer must create a consistent soft‑focus effect across multiple BMP screenshots for documentation or presentations, the snippet provides a repeatable C# solution.
 * 5. When a developer is integrating image processing into a desktop application that requires background softening of BMP files before overlaying graphics, this example illustrates the necessary Aspose.Imaging operations.
 */