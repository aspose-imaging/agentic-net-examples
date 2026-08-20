// HOW-TO: Combine Magic Wand and Polygon Masks Using Union in C# (Aspose.Imaging for .NET)
using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.FileFormats.Png;
using Aspose.Imaging.ImageOptions;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputPath = "input.png";
        string outputPath = "output.png";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Load the source image
            using (RasterImage image = (RasterImage)Image.Load(inputPath))
            {
                // Create a mask using Magic Wand tool at a reference point (example: 100,100)
                ImageBitMask magicMask = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

                // Create a manually defined polygon mask.
                // For demonstration, a rectangle mask is used to represent a polygon area.
                RectangleMask polygonMask = new RectangleMask(200, 150, 300, 200);

                // Combine the two masks using Union to form a composite selection
                ImageBitMask compositeMask = magicMask.Union(polygonMask);

                // Apply the composite mask to the image
                compositeMask.Apply();

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
 * 1. When you need to automatically select a region with the Magic Wand tool and then add a manually drawn polygon to refine the selection before saving a PNG in C#.
 * 2. When you want to create a composite mask that combines a color‑based selection and a geometric shape to isolate objects for background removal using Aspose.Imaging.
 * 3. When you are building an image‑processing pipeline that requires merging a Magic Wand selection with a rectangular (or polygon) mask to apply effects only to the combined area.
 * 4. When you need to programmatically edit scanned documents by selecting irregular areas with Magic Wand and adding precise polygon boundaries for OCR preprocessing.
 * 5. When you are developing a C# application that must generate a masked PNG by uniting automatically detected regions and custom‑drawn shapes for product photo compositing.
 */
