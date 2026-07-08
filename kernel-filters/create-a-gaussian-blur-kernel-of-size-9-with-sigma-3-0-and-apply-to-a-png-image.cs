using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = "input.png";
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
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 9 and sigma 3.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(9, 3.0)
                );

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Report any runtime errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to soften the details of a PNG photograph for a web gallery, they can use this code to apply a 9‑pixel Gaussian blur with sigma 3.0.
 * 2. When preparing product images for an e‑commerce site and wants to hide background noise while preserving overall shape, the code demonstrates how to blur the entire image using Aspose.Imaging in C#.
 * 3. When creating a pre‑processing step for a computer‑vision pipeline that requires a uniformly blurred input, this example shows how to load a PNG, apply a Gaussian kernel, and save the result.
 * 4. When automating a batch job that converts high‑resolution PNG screenshots into a smoother version for PDF reports, the code provides a simple way to apply Gaussian blur programmatically.
 * 5. When building a desktop application that lets users apply a soft focus effect to their PNG avatars, this snippet illustrates the necessary C# operations with Aspose.Imaging’s GaussianBlurFilterOptions.
 */