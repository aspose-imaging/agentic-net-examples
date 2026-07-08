using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.png";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the image as a raster image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Build a mask using Magic Wand, refine it with Subtract and Feathering, then apply
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100))                     // Initial selection point
                    .Subtract(new MagicWandSettings(150, 120) { Threshold = 30 })      // Remove unwanted region via magic wand
                    .Subtract(new RectangleMask(200, 200, 50, 50))                     // Remove a rectangular area
                    .GetFeathered(new FeatheringSettings() { Size = 5 })              // Feather the mask edges
                    .Apply();                                                          // Apply the refined mask to the image

                // Save the resulting image
                image.Save(outputPath);
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
 * 1. When a developer needs to remove a cluttered background from a PNG product photo by selecting the object with Magic Wand, subtracting stray areas, and feathering the mask to create a smooth edge for online catalogs.
 * 2. When a developer wants to isolate a portrait subject, uses Magic Wand to select the person, subtracts unwanted clothing regions, and applies feathering so the mask blends naturally before saving as JPEG.
 * 3. When a developer is preparing a GIS map overlay, they employ Magic Wand to trace a complex coastline, subtract overlapping water polygons, and feather the mask to achieve a seamless transition with the base map.
 * 4. When a developer creates a marketing banner, they use Magic Wand to pick a background, subtract a rectangular logo area, and feather the mask so the logo appears integrated without harsh borders.
 * 5. When a developer cleans scanned documents, they apply Magic Wand to select ink stains, subtract them from the page mask, and feather the edges to retain crisp text while exporting to PDF.
 */