// HOW-TO: Resize JPEG to 800x600 and Apply Magic Wand Selection in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Jpeg;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.jpg";
            string outputPath = "output.jpg";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the JPEG image as a RasterImage
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Resize to 800x600 using default resampling
                image.Resize(800, 600);

                // Apply Magic Wand selection with threshold 40 at point (100, 100)
                MagicWandTool
                    .Select(image, new MagicWandSettings(100, 100) { Threshold = 40 })
                    .Apply();

                // Save the processed image
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
 * 1. When you need to downscale a high‑resolution photo to a standard 800×600 size before performing region selection for further editing.
 * 2. When you want to automatically isolate a specific area of a JPEG using the Magic Wand tool with a custom threshold to create masks or cutouts.
 * 3. When preparing images for web galleries where each picture must be resized and a particular object selected for overlay or annotation.
 * 4. When building a batch‑processing pipeline that resizes user‑uploaded JPEGs and extracts a region based on color similarity for automated cropping.
 * 5. When integrating image analysis into a C# application that requires both size normalization and selective pixel grouping for downstream computer‑vision tasks.
 */
