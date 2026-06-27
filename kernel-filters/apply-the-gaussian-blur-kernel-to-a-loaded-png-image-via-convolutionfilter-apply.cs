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

                // Apply Gaussian blur with kernel size 5 and sigma 4.0
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
 * 1. When a C# application needs to soften the edges of a PNG logo before embedding it in a web page, a developer can use Aspose.Imaging’s GaussianBlurFilterOptions to apply a 5‑pixel kernel blur.
 * 2. When preprocessing scanned PNG receipts for OCR, a developer can reduce high‑frequency noise by applying a Gaussian blur with sigma 4.0 using the RasterImage.Filter method.
 * 3. When generating thumbnail previews of product photos, a developer may blur the background of the original PNG to create a depth‑of‑field effect with Aspose.Imaging’s convolution filter.
 * 4. When preparing PNG assets for a mobile game, a developer can apply a Gaussian blur to create a soft glow around sprites, improving visual consistency across devices.
 * 5. When building a C# image‑analysis pipeline that later performs edge detection, a developer can first smooth the PNG input with a Gaussian blur kernel to minimize false edges.
 */