using System;
using System.IO;
using Aspose.Imaging;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "template.png";
            string outputPath = "output.png";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the PNG image
            using (Image image = Image.Load(inputPath))
            {
                // Cast to RasterImage to access filtering capabilities
                RasterImage raster = (RasterImage)image;

                // Apply a motion Wiener filter (size 7, smooth factor 1.0, angle 30 degrees)
                raster.Filter(
                    raster.Bounds,
                    new Aspose.Imaging.ImageFilters.FilterOptions.MotionWienerFilterOptions(7, 1.0, 30.0));

                // Save the processed image
                raster.Save(outputPath);
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
 * 1. When generating product catalog thumbnails, a developer can load a PNG template, apply a motion blur filter to simulate motion, and save the result for web display.
 * 2. When creating dynamic game UI elements, a programmer may need to load a PNG asset, add a motion Wiener blur at a specific angle to convey speed, and save the modified image for use in the game engine.
 * 3. When preparing marketing banners that require a subtle motion effect, a developer can use C# and Aspose.Imaging to load the PNG background, apply a 7‑pixel motion blur at 30°, and output the final PNG.
 * 4. When automating the preprocessing of scanned documents that include moving objects, a developer can load each PNG page, apply a motion blur filter to smooth motion artifacts, and save the cleaned image.
 * 5. When building an image‑processing pipeline for a photo‑editing web service, a C# backend can load a user‑provided PNG, apply a motion Wiener filter to achieve a directional blur, and store the processed PNG for download.
 */