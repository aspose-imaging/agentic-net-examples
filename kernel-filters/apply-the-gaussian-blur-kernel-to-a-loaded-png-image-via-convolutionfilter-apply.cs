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
            string inputPath = @"C:\temp\sample.png";
            string outputPath = @"C:\temp\sample.GaussianBlur.png";

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
                // Cast to RasterImage to access filtering methods
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with kernel size 5 and sigma 4.0 to the whole image
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
 * 1. When a developer needs to soften the edges of a PNG logo before embedding it in a web page to reduce visual harshness, they can use Aspose.Imaging's GaussianBlurFilterOptions with a 5‑pixel kernel and sigma 4.0.
 * 2. When preparing product photos in a C# application for a catalog and wants to create a subtle background blur effect to highlight the foreground, the code can apply a Gaussian blur to the entire PNG image.
 * 3. When building an automated image‑processing pipeline that removes noise from scanned PNG documents by smoothing pixel variations, developers can invoke the rasterImage.Filter method with GaussianBlurFilterOptions.
 * 4. When generating thumbnail previews of PNG screenshots where a gentle blur helps mask pixelation after downscaling, the Gaussian blur filter provides a quick C# solution using Aspose.Imaging.
 * 5. When implementing a privacy feature that obscures sensitive details in a PNG image before sharing, applying a Gaussian blur with a defined kernel size and sigma ensures consistent smoothing across the image.
 */