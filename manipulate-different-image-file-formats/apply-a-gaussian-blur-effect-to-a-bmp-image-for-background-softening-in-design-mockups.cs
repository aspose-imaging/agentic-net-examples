// HOW-TO: Apply Gaussian Blur to BMP Image Using Aspose.Imaging in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.bmp";
        string outputPath = "output_gaussian.bmp";

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

            // Load the BMP image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0)
                );

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to soften the background of a BMP mockup for a UI design, you can use this code to apply a Gaussian blur quickly.
 * 2. When preparing assets for a presentation and want to blur a BMP logo without losing file format compatibility, the snippet provides an easy C# solution.
 * 3. When automating a batch process that adds a subtle blur to BMP screenshots before uploading to a web portal, this code demonstrates the required filter call.
 * 4. When integrating image editing into a .NET application that must keep the original BMP dimensions while applying a Gaussian effect, the example shows how to do it safely.
 * 5. When testing visual effects in a prototype and need to compare original and blurred BMP versions programmatically, this code lets you generate the blurred output on the fly.
 */
