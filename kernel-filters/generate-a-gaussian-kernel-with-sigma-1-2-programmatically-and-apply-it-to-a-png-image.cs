// HOW-TO: Apply Gaussian Blur With Sigma 1.2 To PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Images\input.png";
        string outputPath = @"C:\Images\output_gaussian.png";

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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Create Gaussian blur filter options with kernel size 5 (odd) and sigma 1.2
                var gaussianOptions = new GaussianBlurFilterOptions(5, 1.2);

                // Apply the Gaussian blur to the whole image
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
 * 1. When you need to reduce image noise in a PNG before OCR by applying a Gaussian blur with a sigma of 1.2 using Aspose.Imaging in C#.
 * 2. When you want to create a soft‑focus effect for web‑ready PNG assets by programmatically applying a 5×5 Gaussian kernel in a .NET application.
 * 3. When preprocessing PNG screenshots for machine‑learning models, you can smooth edges with a Gaussian blur to improve model accuracy.
 * 4. When generating thumbnails that require subtle smoothing to avoid aliasing, you can use Aspose.Imaging’s GaussianBlurFilterOptions in C#.
 * 5. When automating a batch job that standardizes PNG images with consistent blur strength for a design system, you can apply the same sigma‑1.2 kernel to each file.
 */
