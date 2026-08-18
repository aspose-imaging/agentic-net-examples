// HOW-TO: Crop TGA Image To Circular Region And Save As PNG In C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tga";
            string outputPath = "output.png";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the TGA image as a raster image
            using (Image img = Image.Load(inputPath))
            {
                RasterImage raster = (RasterImage)img;

                // Determine center of the image
                int centerX = raster.Width / 2;
                int centerY = raster.Height / 2;
                int radius = 100;

                // Create a circular mask and apply it to the raster image
                CircleMask mask = new CircleMask(centerX, centerY, radius);
                mask.ApplyTo(raster);

                // Save the result as PNG
                raster.Save(outputPath, new PngOptions());
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
 * 1. When you need to extract a round thumbnail from a TGA sprite sheet for use in a game UI.
 * 2. When preparing circular profile pictures from high‑resolution TGA assets for a web application.
 * 3. When converting legacy TGA graphics into PNG format while masking out everything outside a specific radius.
 * 4. When generating circular masks for scientific visualizations that require precise pixel‑level cropping.
 * 5. When automating batch processing of TGA files to create round icons for mobile app resources.
 */
