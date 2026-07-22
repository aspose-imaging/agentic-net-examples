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
            string inputPath = "c:\\temp\\input.bmp";
            string outputPath = "c:\\temp\\output_gaussian.bmp";

            // Verify that the input file exists
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
                // Cast to RasterImage to access filtering capabilities
                RasterImage rasterImage = (RasterImage)image;

                // Apply Gaussian blur with radius 5 and sigma 4.0 to the whole image
                rasterImage.Filter(rasterImage.Bounds, new GaussianBlurFilterOptions(5, 4.0));

                // Save the processed image
                rasterImage.Save(outputPath);
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a UI designer needs to soften the background of a BMP mockup in a C# application, applying a Gaussian blur creates a subtle depth effect for presentation slides.
 * 2. When generating printable marketing material, developers can use this code to blur a BMP image’s background so that overlaid text remains legible without altering the original file format.
 * 3. When preprocessing assets for a game’s level editor, applying a Gaussian blur to BMP textures via Aspose.Imaging helps simulate depth‑of‑field without requiring external graphics tools.
 * 4. When automating the creation of thumbnail previews for a digital asset management system, developers can blur the BMP source to produce a visually appealing placeholder while the full‑resolution image loads.
 * 5. When building a C# batch‑processing pipeline that prepares UI screenshots, using the GaussianBlurFilterOptions on BMP files ensures consistent background softening across all generated images.
 */