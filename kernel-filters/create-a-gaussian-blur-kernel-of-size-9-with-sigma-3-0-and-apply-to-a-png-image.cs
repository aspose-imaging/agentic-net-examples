using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output file paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_gaussian_blur.png";

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

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 9 and sigma 3.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(9, 3.0));

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
 * 1. When a developer needs to soften the details of a PNG screenshot before embedding it in a user guide, they can use this code to apply a Gaussian blur with a 9‑pixel kernel and sigma 3.0.
 * 2. When an e‑commerce site wants to create a blurred background for product thumbnails stored as PNG files, this snippet quickly generates the effect using Aspose.Imaging’s GaussianBlurFilterOptions.
 * 3. When a mobile app prepares PNG assets for a privacy‑preserving blur effect on faces or license plates, the code demonstrates how to load, filter, and save the image in C#.
 * 4. When a batch‑processing tool must reduce noise in scanned PNG documents before OCR, the example shows how to apply a 9‑size Gaussian blur to improve readability.
 * 5. When a game developer wants to pre‑process PNG textures with a soft glow for atmospheric scenes, this program illustrates the straightforward C# approach using Aspose.Imaging’s raster filter API.
 */