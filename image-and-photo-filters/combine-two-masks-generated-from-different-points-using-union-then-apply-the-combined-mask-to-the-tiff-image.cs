using System;
using System.IO;
using Aspose.Imaging;
using Aspose.Imaging.MagicWand;
using Aspose.Imaging.MagicWand.ImageMasks;

class Program
{
    static void Main()
    {
        // Hardcoded input and output paths
        string inputImagePath = "input\\source.tif";
        string outputImagePath = "output\\result.tif";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputImagePath))
            {
                Console.Error.WriteLine($"File not found: {inputImagePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputImagePath) ?? ".");

            // Load the TIFF image
            using (RasterImage image = (RasterImage)Image.Load(inputImagePath))
            {
                // Create first mask using magic wand at point (100, 100)
                ImageBitMask mask1 = MagicWandTool.Select(image, new MagicWandSettings(100, 100));

                // Create second mask using magic wand at point (200, 200)
                ImageBitMask mask2 = MagicWandTool.Select(image, new MagicWandSettings(200, 200));

                // Combine the two masks using Union
                ImageBitMask combinedMask = mask1.Union(mask2);

                // Apply the combined mask to the image
                combinedMask.ApplyTo(image);

                // Save the modified image
                image.Save(outputImagePath);
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
 * 1. When a developer needs to remove or highlight multiple separate regions (e.g., stains or logos) in a high‑resolution TIFF scan by selecting each area with a magic wand and merging the selections with a Union mask.
 * 2. When an application must create a composite mask from two user‑clicked points on a satellite TIFF image to isolate overlapping land parcels for further analysis.
 * 3. When a batch‑processing tool has to combine two automatically detected defect areas in a scanned document TIFF and apply the combined mask to erase them in one operation.
 * 4. When a medical imaging system wants to select two distinct tissue regions in a pathology TIFF slide, merge the selections, and apply the mask to adjust contrast only within the combined area.
 * 5. When a GIS developer needs to union two polygonal selections on a georeferenced TIFF map and apply the resulting mask to clip the map to those combined zones.
 */