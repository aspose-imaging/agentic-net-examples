using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        // Ensure any runtime exception is reported cleanly
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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(5, 4.0));

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
 * 1. When a developer needs to soften the edges of a PNG logo before embedding it in a web page to reduce visual harshness, they can use this code to apply a Gaussian blur with a 5‑pixel kernel and sigma 4.0.
 * 2. When preparing product photos for an e‑commerce catalog and wanting to hide background details while keeping the main subject clear, the code can blur the entire PNG image using Aspose.Imaging’s GaussianBlurFilterOptions.
 * 3. When creating a thumbnail generator that applies a subtle blur to reduce noise in high‑resolution PNG screenshots, a developer can call rasterImage.Filter with the Gaussian blur kernel as shown.
 * 4. When implementing a batch‑processing tool that automatically smooths scanned PNG documents to improve OCR accuracy, this snippet demonstrates how to load, blur, and save each file in C#.
 * 5. When building a desktop application that lets users apply a quick blur effect to PNG avatars for privacy reasons, the code provides a straightforward way to apply the Gaussian blur filter and write the result to disk.
 */