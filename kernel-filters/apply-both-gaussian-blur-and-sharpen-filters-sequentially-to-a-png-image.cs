using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"c:\temp\input.png";
            string outputPath = @"c:\temp\output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur filter (radius 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Apply Sharpen filter (kernel size 5, sigma 4.0) to the whole image
                rasterImage.Filter(rasterImage.Bounds, new SharpenFilterOptions(5, 4.0));

                // Save the processed image to the output path
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
 * 1. When a developer needs to reduce noise in a high‑resolution PNG screenshot before enhancing edge details for a web gallery, they can apply a Gaussian blur followed by a sharpen filter using Aspose.Imaging for .NET.
 * 2. When preparing product photos in PNG format for an e‑commerce site, a C# application can smooth out background artifacts with a Gaussian blur and then sharpen the product edges to improve visual clarity.
 * 3. When building an automated batch‑processing tool that cleans up scanned PNG documents, applying a Gaussian blur to soften speckles and a subsequent sharpen filter restores text sharpness.
 * 4. When creating a custom thumbnail generator in C#, developers can use Aspose.Imaging to blur a PNG image to remove aliasing and then sharpen it to maintain crispness at smaller sizes.
 * 5. When integrating image preprocessing into a machine‑learning pipeline that expects PNG inputs, a developer can first apply a Gaussian blur to normalize noise and then sharpen the image to highlight features before model inference.
 */