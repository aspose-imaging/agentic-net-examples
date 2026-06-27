using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageFilters.FilterOptions;
using Aspose.Imaging.FileFormats.Bmp;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "c:\\temp\\sample.bmp";
            string outputPath = "c:\\temp\\sample.gaussian.bmp";

            // Verify input file exists
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
                // Cast to RasterImage to access filtering
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur (radius 5, sigma 4.0) to the whole image
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
 * 1. When a UI designer needs to soften the background of a BMP asset in a desktop application mockup, a developer can use this C# Aspose.Imaging code to apply a Gaussian blur before exporting the image.
 * 2. When generating printable marketing materials that require a subtle blur effect on a BMP photograph to draw attention to foreground text, the code provides a quick way to process the image in .NET.
 * 3. When building an automated pipeline that prepares BMP textures for game UI prototypes, developers can use the Gaussian blur filter to create a smooth backdrop without manual Photoshop steps.
 * 4. When creating a web‑based design review tool that loads BMP screenshots and needs to blur sensitive information in the background, the Aspose.Imaging filter can be invoked from C# to mask details.
 * 5. When converting legacy BMP icons into modern mockups and wanting to apply a consistent radius‑5 Gaussian blur for visual consistency, this snippet demonstrates the exact C# operations needed.
 */