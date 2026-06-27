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

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create Gaussian blur filter options with size 5 (odd) and sigma 1.2
                var gaussianOptions = new GaussianBlurFilterOptions(5, 1.2);

                // Apply the filter to the entire image bounds
                rasterImage.Filter(rasterImage.Bounds, gaussianOptions);

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
 * 1. When a developer needs to reduce noise in a PNG screenshot before performing OCR, they can programmatically generate a Gaussian kernel with sigma 1.2 and apply it using Aspose.Imaging in C#.
 * 2. When preparing product photos for an e‑commerce website, a developer can use this code to apply a subtle Gaussian blur (sigma 1.2) to PNG images to create a consistent soft‑focus effect.
 * 3. When building an automated image‑processing pipeline that normalizes visual quality of user‑uploaded PNG avatars, a developer can invoke the GaussianBlurFilterOptions with sigma 1.2 to smooth edges without losing detail.
 * 4. When creating a desktop application that previews filtered images, a developer can load a PNG, apply a 5×5 Gaussian kernel with sigma 1.2 via Aspose.Imaging, and save the result for quick visual feedback.
 * 5. When integrating image preprocessing into a machine‑learning workflow, a developer can use this C# snippet to blur PNG training data with a sigma of 1.2, helping to reduce high‑frequency noise before feature extraction.
 */