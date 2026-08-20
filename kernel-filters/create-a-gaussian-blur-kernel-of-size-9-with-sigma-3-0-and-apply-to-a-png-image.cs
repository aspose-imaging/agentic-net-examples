// HOW-TO: Apply Gaussian Blur Kernel Size 9 Sigma 3 To PNG In C# (Aspose.Imaging for .NET)
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
            string inputPath = @"C:\Images\sample.png";
            string outputPath = @"C:\Images\sample.GaussianBlur.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering functionality
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 9 and sigma 3.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(9, 3.0));

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
 * 1. Use this code to soften the edges of a PNG product photo before publishing it on an e‑commerce site.
 * 2. Use this code to reduce high‑frequency noise in a scanned PNG diagram by applying a 9‑pixel Gaussian blur with sigma 3.0.
 * 3. Use this code to add a uniform blur to PNG game assets during the build process, ensuring consistent visual style.
 * 4. Use this code to preprocess PNG screenshots with a Gaussian blur, helping OCR engines ignore fine details and improve text extraction.
 * 5. Use this code to create a blurred PNG background from a portrait image for UI overlay or thumbnail generation.
 */
