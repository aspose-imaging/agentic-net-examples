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
        string outputPath = "output.GaussianBlur.png";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Load the image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 9 and sigma 3.0 to the whole image
                rasterImage.Filter(
                    rasterImage.Bounds,
                    new GaussianBlurFilterOptions(9, 3.0)
                );

                // Ensure the output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

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
 * 1. When a developer needs to soften the details of a high‑resolution PNG screenshot before embedding it in a web page to reduce visual noise.
 * 2. When an image‑processing pipeline must apply a consistent Gaussian blur (kernel 9, sigma 3.0) to PNG assets for a machine‑learning model that expects smoother input.
 * 3. When a desktop application written in C# wants to create a stylized background by blurring a user‑selected PNG file using Aspose.Imaging’s raster filter API.
 * 4. When a batch‑conversion tool has to preprocess PNG icons with a Gaussian blur to achieve a uniform glow effect across all icons.
 * 5. When a developer is implementing a preview feature that quickly blurs a PNG thumbnail to indicate a disabled state in a UI, using the GaussianBlurFilterOptions class.
 */